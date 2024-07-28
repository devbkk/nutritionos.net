namespace NutriCare.Api.Interfaces
{
  public interface ITokenService
  {
    public string GenerateToken(string userId, string userEmail);
  }
}

