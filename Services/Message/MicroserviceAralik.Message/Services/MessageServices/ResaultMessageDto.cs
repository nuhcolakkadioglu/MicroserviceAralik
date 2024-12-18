namespace MicroserviceAralik.Message.Services.MessageServices;

public class ResaultMessageDto
{
    public int Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverdId { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime SendDate { get; set; }
    public string Status { get; set; }
}