namespace SalesPlatform_Application.Dtos.Chat
{
    public class MessageDto
    {
        public string SenderId { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
    }
}
