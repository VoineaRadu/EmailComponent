namespace EmailComponent.Dtos
{
    public class EmailToSend
    {
        public string Subject { get; set; }
        
        public string Message { get; set; }
        
        public int SenderId { get; set; }
        
        public string ReceiverEmail { get; set; }
    }
}