using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using EmailComponent.Dtos;
using EmailComponent.Models;
using EmailComponent.Repository;

namespace EmailComponent.Controllers
{ 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/email")]
    public class EmailController: ApiController
    {
        private readonly EmailRepository _emailRepository;

        public EmailController()
        {
            _emailRepository = new EmailRepository();
        }
        
        [HttpPost, Route("sendEmail")]
        public async Task<IHttpActionResult> SendEmail(EmailToSend emailToSend)
        {

            var receiverId = await _emailRepository.GetIdOfReceiver(emailToSend.ReceiverEmail);
            
            var emailToCreate = new Email
            {
                Subject = emailToSend.Subject,
                Message = emailToSend.Message,
                SenderId = emailToSend.SenderId,
                ReceiverId = receiverId
            };
            
            await _emailRepository.SendEmail(emailToCreate);

            return StatusCode((HttpStatusCode) 201);
        }
        
        [HttpPost, Route("replayToMail")]
        public async Task<IHttpActionResult> ReplayToMail(EmailToReplay emailToReplay)
        {
            
            var receiverId = await _emailRepository.GetIdOfReceiver(emailToReplay.ReceiverEmail);
            
            var emailToCreate = new Email
            {
                Subject = emailToReplay.Subject,
                Message = emailToReplay.Message,
                SenderId = emailToReplay.SenderId,
                ConversationId = emailToReplay.ConversationId,
                ReceiverId = receiverId,
            };
            
            await _emailRepository.ReplayToEmail(emailToCreate);

            return StatusCode((HttpStatusCode) 201);
        }
        
        [HttpGet, Route("getEmailsForUser/{id}")]
        public async Task<List<EmailReceived>> GetEmailsConversationsForUser(int id)
        {
            var results = await _emailRepository.GetEmailConversations(id);
            return results;
        }
        
        [HttpDelete, Route("deleteMail/{conversationId}")]
        public async Task<IHttpActionResult> DeleteMail(string conversationId)
        {
            await _emailRepository.DeleteEmail(conversationId);
            
            return StatusCode((HttpStatusCode) 204);
        }
        
        [HttpPost, Route("readEmail")]
        public async Task<IHttpActionResult> ReadEmail([FromBody]int emailId)
        {
            await _emailRepository.ReadEmail(emailId);
            
            return StatusCode((HttpStatusCode) 201);
        }
    }
    
}