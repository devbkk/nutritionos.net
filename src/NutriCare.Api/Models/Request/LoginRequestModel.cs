namespace NutriCare.Api.Models.Request
{
  public class LoginRequestModel
  {
    public LoginRequestModel()
    {     
      Username = string.Empty;
      Password = string.Empty;
    }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}