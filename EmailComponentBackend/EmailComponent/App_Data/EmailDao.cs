using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using EmailComponent.Dtos;
using EmailComponent.Models;
using EmailComponent.Utils;

namespace EmailComponent.App_Data
{
    public class EmailDao
    {
        public async Task SendEmail(Email email)
        {
            var procedureBuilder = new ProcedureBuilder(Helper.MyConnectionString);
            
            await procedureBuilder.AddProcedureName("InsertEmail")
                .AddParameter("subject", email.Subject)
                .AddParameter("message", email.Message)
                .AddParameter("is_readed", email.IsReaded)
                .AddParameter("sender_id", email.SenderId)
                .AddParameter("receiver_id", email.ReceiverId)
                .AddParameter("date", email.Date)
                .AddParameter("conversation_id", email.ConversationId)
                .BuildNonQueryAsync();
        }
        
        
        public async Task<int> GetIdOfReceiver(string receiverEmail)
        {
            var procedureBuilder = new ProcedureBuilder(Helper.MyConnectionString);

            var result = await procedureBuilder.AddProcedureName("GetIdOfReceiver")
                .AddParameter("receiver_email", receiverEmail)
                .BuildScalarAsync<int>();
            
            return result;
        }


        public async Task<List<EmailReceived>> GetEmailsForUser(int id)
        {
            var procedureBuilder = new ProcedureBuilder(Helper.MyConnectionString);
            
            var result = await procedureBuilder.AddProcedureName("RetrieveEmailsForUser")
                .AddParameter("user_id", id)
                .BuildReaderForList(new EmailReceived());

            return result;
        }

        public async Task DeleteEmail(string conversationId)
        {
            var procedureBuilder = new ProcedureBuilder(Helper.MyConnectionString);

            await procedureBuilder.AddProcedureName("UnassignEmail")
                .AddParameter("@conversation_id", conversationId)
                .BuildNonQueryAsync();
        }


        public async Task ReadEmail(int emailId)
        {
            var procedureBuilder = new ProcedureBuilder(Helper.MyConnectionString);

            await procedureBuilder.AddProcedureName("ReadEmail")
                .AddParameter("email_id", emailId)
                .BuildNonQueryAsync();
        }
    }
}