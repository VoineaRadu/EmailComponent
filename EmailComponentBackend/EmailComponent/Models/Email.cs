using System;

namespace EmailComponent.Models
{
    [Serializable]
    public class Email
    {
        public int EmailId { get; set; }
        
        public string Subject { get; set; }
        
        public string Message { get; set; }

        public bool IsReaded { get; set; }
        
        public long Date { get; set; }
        
        public string ConversationId { get; set; }
        
        public int SenderId { get; set; }
        
        public int ReceiverId { get; set; }
    }
}