namespace CleanArcMvc.API.DTO;

public class UserToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
