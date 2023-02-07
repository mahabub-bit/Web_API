using AutoMapper;
using Project_01.Models;
using Project_01.Models.Dto;

namespace Project_01
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Company, CompanyCreateDTO>().ReverseMap();
            CreateMap<Company, CompanyUpdateDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<CategoryType, CategoryTypeDTO>().ReverseMap();
            CreateMap<CategoryType, CategoryTypeCreateDTO>().ReverseMap();
            CreateMap<CategoryType, CategoryTypeUpdateDTO>().ReverseMap();
        }
    }
}
