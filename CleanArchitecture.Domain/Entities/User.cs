using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int id { get; set; }
        public string username { get; set; }
        public string password_salt { get; set; }
        public string password_hash { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public Role role { get; set; }
    }
}
