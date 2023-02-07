using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models
{
    public class Company
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }
        public string CState { get; set; }
        public string CPostalCode { get; set; }
        public string CBusinessPhone { get; set; }
        public string CGST { get; set; }
        public string CBank { get; set; }
        public string CBankAccount { get; set; }
        public string CBankBranch { get; set; }
        public string CIFSC { get; set; }
        public string CC1 { get; set; }
        public Nullable<System.DateTime> CC2 { get; set; }
        public Nullable<int> CC3 { get; set; }
        public string CC4 { get; set; }

        
        
    }
}
