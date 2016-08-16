using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomIdentity.Models.Auth
{
    public class User : IdentityUser<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public override string Email { get; set; }

        public override int Id
        {
            get { return IdUser; }
            set { base.Id = value; }
        }

        public override string UserName
        {
            get { return Login; }
            set { base.UserName = value; }
        }

        public override string PasswordHash
        {
            get { return Password; }
            set { Password = value; }
        }

        public override string NormalizedUserName
        {
            get { return Login.ToUpper(); }
        }

        public override string NormalizedEmail
        {
            get { return Email.ToUpper(); }
        }

        public override string SecurityStamp
        {
            get { return Guid.NewGuid().ToString("D"); }
        }
    }
}
