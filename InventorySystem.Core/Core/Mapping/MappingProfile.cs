using AutoMapper;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;

namespace RecruitmentManager.Core.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ArticleCreateDto, Article>();
            CreateMap<Article, ArticleCreateDto>();

            CreateMap<MovementCreateDto, Movement>();
            CreateMap<Movement, MovementCreateDto>();
        }
    }
}
