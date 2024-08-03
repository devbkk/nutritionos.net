using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriCare.Core.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 

        [Column("is_active")]
        public bool IsActive { get; set; } = true;
 
        public User()
        {
          this.UserId = Guid.NewGuid();
          this.Username = string.Empty;
          this.PasswordHash = string.Empty;
          this.Email = string.Empty;
          this.CreatedAt = DateTime.UtcNow;
          this.UpdatedAt = DateTime.UtcNow;
          this.IsActive = false;
        }

        public User(string _username, string _password, string _email) : this()
        {
          this.UserId = Guid.NewGuid();
          this.Username = _username;
          this.PasswordHash = _password;
          this.Email = _email;
        }
    }
}
