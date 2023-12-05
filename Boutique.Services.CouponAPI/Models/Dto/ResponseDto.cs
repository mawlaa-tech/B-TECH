namespace Boutique.Services.CouponAPI.Models.Dto;

public class ResponseDto
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Messqge { get; set; } = "";
} 
