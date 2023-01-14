namespace LPPMaUI.Models.DTOs;

public class ChatDTO
{
    public string ReceiverName { get; set; } = default!;
    public string ProductImage { get; set; } = default!;
    public string LastMessage { get; set; } = default!;
    public bool IsRead { get; set; } = default!;
}