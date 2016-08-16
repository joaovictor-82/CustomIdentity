using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomIdentity.Models.Auth
{
    public class Role : IdentityRole<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRole { get; set; }
        [Required]
        public string NameRole { get; set; }
    }
}
