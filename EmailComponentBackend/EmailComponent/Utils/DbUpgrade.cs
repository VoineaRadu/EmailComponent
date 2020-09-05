using System.Data.SqlClient;
using System.IO;

namespace EmailComponent.Utils
{
    public class DbUpgrade
    {
        private readonly string root = "E:/EmailComponent/EmailComponentBackend/EmailComponent/Sql/";

        public void Upgrade()
        {
            if (DatabaseExists()) return;

            CreateDb();
            ExecQuery(root + "Querys/CreateTableUsers.sql");
            ExecQuery(root + "Querys/CreateTableEmails.sql");
            ExecQuery(root + "Procedures/InsertEmail.sql");
            ExecQuery(root + "Procedures/InsertUser.sql");
            ExecQuery(root + "Procedures/GetIdOfReceiver.sql");
            ExecQuery(root + "Procedures/ReadEmail.sql");
            ExecQuery(root + "Procedures/RetrieveEmailsForUser.sql");
            ExecQuery(root + "Procedures/UnassignEmail.sql");
            ExecQuery(root + "Querys/CreateUsers.sql");
            ExecQuery(root + "Querys/CreateEmails.sql");
            DropProcedure();
        }

        private void CreateDb()
        {
            //Create procedure
            var procedureBuilder = new ProcedureBuilder(Helper.MasterConnectionString);
            var query = File.ReadAllText(root + "Procedures/CreateDatabase.sql");
            procedureBuilder.AddQueryString(query)
                .BuildNonQuery();


            // Execute procedure
            procedureBuilder = new ProcedureBuilder(Helper.MasterConnectionString);
            procedureBuilder.AddProcedureName("CreateDatabase")
                .AddParameter("db_name", Helper.DbName)
                .BuildNonQuery();
        }


        private async void ExecQuery(string filepath)
        {
            var procedureBuilder = new ProcedureBuilder(Helper.MyConnectionString);
            var query = File.ReadAllText(filepath);

            await procedureBuilder.AddQueryString(query)
                .BuildNonQueryAsync();
        }


        private bool DatabaseExists()
        {
            string query = "SELECT database_id FROM sys.databases WHERE Name = " + "'" + Helper.DbName + "'";
            var connection = new SqlConnection(Helper.MasterConnectionString);
            var sqlCommand = new SqlCommand(query, connection);

            connection.Open();
            var result = sqlCommand.ExecuteScalar();
            connection.Close();

            return result != null;
        }

        private async void DropProcedure()
        {
            var procedureBuilder = new ProcedureBuilder(Helper.MasterConnectionString);

            await procedureBuilder.AddQueryString("DROP PROCEDURE CreateDatabase")
                .BuildNonQueryAsync();
        }
    }
}