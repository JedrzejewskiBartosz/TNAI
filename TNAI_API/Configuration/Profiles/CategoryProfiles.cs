using AutoMapper;
using TNAI.Dto.Categories;
using TNAI.Model.Entities;

namespace TNAI_API.Configuration.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles() {
            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.ProductsCount, d => d.MapFrom(s => s.Products == null ? 0 : s.Products.Count));
        }
    }
}
