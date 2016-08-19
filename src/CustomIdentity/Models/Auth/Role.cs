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

        public override int Id
        {
            get { return IdRole; }
            set { base.Id = value; }
        }

        public override string Name
        {
            get { return NameRole; }
            set { base.Name = value; }
        }

        public override string NormalizedName
        {
            get { return NameRole.ToUpper(); }
        }
    }
}
