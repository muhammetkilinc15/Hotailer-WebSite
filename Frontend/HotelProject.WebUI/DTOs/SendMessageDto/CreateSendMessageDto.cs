namespace HotelProject.WebUI.DTOs.SendMessageDto
{
    public class CreateSendMessageDto
    {
        //public int SendMessageId { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;

        public string ReiverName { get; set; } = string.Empty;
        public string ReiverMail { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
