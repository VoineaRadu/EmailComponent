namespace EmailComponent.Dtos
{
    public class EmailToReplay
    {
        public int EmailId { get; set; }
        
        public string Subject { get; set; }
        
        public string Message { get; set; }
        
        public int SenderId { get; set; }
        
        public string ReceiverEmail { get; set; }
        
        public string ConversationId { get; set; }
    }
}