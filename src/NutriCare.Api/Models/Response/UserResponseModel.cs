namespace NutriCare.Api.Models.Response
{
    public class UserResponseModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public UserResponseModel()
        {
          Username = string.Empty;
          Email = string.Empty;
        }
    }
}
