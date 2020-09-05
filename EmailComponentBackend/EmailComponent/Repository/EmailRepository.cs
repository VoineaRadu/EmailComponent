using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailComponent.App_Data;
using EmailComponent.Dtos;
using EmailComponent.Models;
using EmailComponent.Utils;

namespace EmailComponent.Repository
{
    public class EmailRepository
    {
        private EmailDao _emailDao;

        public EmailRepository()
        {
            _emailDao = DataContext.GetInstance()._emailDao;
        }

        public async Task SendEmail(Email email)
        {
            email.Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            email.IsReaded = false;
            email.ConversationId = Guid.NewGuid().ToString();

            await _emailDao.SendEmail(email);
        }

        public async Task ReplayToEmail(Email email)
        {
            email.Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            email.IsReaded = false;

            await _emailDao.SendEmail(email);
        }

        public async Task<int> GetIdOfReceiver(string receiverEmail)
        {
            return await _emailDao.GetIdOfReceiver(receiverEmail);
        }

        public async Task<List<EmailReceived>> GetEmailConversations(int id)
        {
            var emails = await _emailDao.GetEmailsForUser(id);
            var emailConversations = new List<EmailReceived>();

            var conversationsIds = new HashSet<string>();

            foreach (var email in emails)
            {
                conversationsIds.Add(email.ConversationId);
            }

            for (int i = emails.Count - 1; i >= 0; i--)
            {
                if (conversationsIds.Contains(emails[i].ConversationId))
                {
                    emailConversations.Add(emails[i]);
                    conversationsIds.Remove(emails[i].ConversationId);
                }
            }

            return emailConversations;
        }

        public async Task DeleteEmail(string conversationId)
        {
           await _emailDao.DeleteEmail(conversationId);
        }
        
        public async Task ReadEmail(int emailId)
        {
            await _emailDao.ReadEmail(emailId);
        }
    }
}    