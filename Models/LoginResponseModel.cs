
using System.ComponentModel.DataAnnotations;

namespace ElipgoBE.Models
{
    public class LoginResponseModel
    {
        public string Role { get; set; }
        public bool Success { get; set; }

        public static LoginResponseModel Map(LoginModel access)
        {
            return new LoginResponseModel()
            {
                Role = access.Role,
                Success = true
            };
        }
    }

    public class LoginModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}