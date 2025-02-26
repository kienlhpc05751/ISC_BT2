using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISC_BT2.Models
{
    public class AllowAccess
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public string TableName { get; set; }  
        public string AccessProperties { get; set; }  

        public Role Role { get; set; }
    }
}
