using NutriCare.Api.Models.Response;

namespace NutriCare.Api.Interfaces
{
  public interface IUserService
  {
    public Task<List<UserResponseModel>> GetUsers();
  }
}