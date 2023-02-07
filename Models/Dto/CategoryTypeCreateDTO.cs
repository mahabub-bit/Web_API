using System.ComponentModel.DataAnnotations;

namespace Project_01.Models.Dto
{
    public class CategoryTypeCreateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public string CatTypeName { get; set; }
        public string CatTypeDesc2 { get; set; }
        public string CatTypeDesc3 { get; set; }
        public string CatTypeDesc4 { get; set; }
    }
}
