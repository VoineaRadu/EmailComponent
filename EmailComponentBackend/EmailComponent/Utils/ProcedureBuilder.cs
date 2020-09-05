using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EmailComponent.Utils
{
    public class ProcedureBuilder
    {
        private SqlConnection _connection;
        private SqlParameter _parameter;
        private SqlCommand _command;

        public ProcedureBuilder(string connectionString)
        {
            _connection = new SqlConnection(connectionString);

            try
            {
                _connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ProcedureBuilder AddParameter(string valueName, object value)
        {
            _command.Parameters.AddWithValue(valueName, value);

            return this;
        }

        public ProcedureBuilder AddProcedureName(string procedureName)
        {
            _command = new SqlCommand(procedureName, _connection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandTimeout = 300;
            _command.CommandText = "dbo." + procedureName;
            return this;
        }

        public ProcedureBuilder AddQueryString(string queryString)
        {
            _command = new SqlCommand(queryString, _connection);
            _command.CommandTimeout = 300;
            return this;
        }

        public async Task BuildNonQueryAsync()
        {
            await _command.ExecuteNonQueryAsync();

            _connection.Close();
        }

        public void BuildNonQuery()
        {
            _command.ExecuteNonQuery();

            _connection.Close();
        }


        public async Task<T> BuildScalarAsync<T>()
        {
            var result = await _command.ExecuteScalarAsync();

            _connection.Close();

            return (T) result;
        }

        public T BuildReader<T>(T entity)
        {
            SqlDataReader reader = _command.ExecuteReader();

            var newEntity = new object();
            if (reader.Read())
            {
                newEntity = SetProperties(entity, reader);
            }

            _connection.Close();

            return (T) newEntity;
        }

        public async Task<List<T>> BuildReaderForList<T>(T entity)
        {
            SqlDataReader reader = await _command.ExecuteReaderAsync();

            var entityList = new List<T>();

            while (reader.Read())
            {
                var newEntity = (T) SetProperties(entity, reader);
                
                entityList.Add(newEntity);
            }

            _connection.Close();

            return entityList;
        }


        private Object SetProperties(object obj, IDataRecord reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var prop = obj.GetType().GetProperty(ToTitleCase(reader.GetName(i)),
                    BindingFlags.Public | BindingFlags.Instance);
                prop.SetValue(obj, reader[reader.GetName(i)], null);
            }
            
            return DeepCopy(obj);
        }

        public static string ToTitleCase(string str)
        {
            var newString = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    newString.Append(Char.ToUpper(str[i]));
                    continue;
                }

                if (str[i] == '_')
                {
                    i++;
                    newString.Append(Char.ToUpper(str[i]));
                    continue;
                }

                newString.Append(str[i]);
            }

            return newString.ToString();
        }
        
        public static T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Context = new StreamingContext(StreamingContextStates.Clone);
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}