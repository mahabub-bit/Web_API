using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models
{
    public class Category
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }
       
        [ForeignKey("Company")]
        [Required]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
    }
}
