using System;

namespace EmailComponent.Dtos
{
    [Serializable]
    public class EmailReceived
    {
        public int EmailId { get; set; }
        
        public string Subject { get; set; }
        
        public string Message { get; set; }
        
        public bool IsReaded { get; set; }
        
        public long Date { get; set; }
        public string ConversationId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

    }
    
}