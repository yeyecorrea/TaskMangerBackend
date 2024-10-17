using AutoMapper;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskedDto, Tasked>();
            CreateMap<TagDto, Tag>();
            CreateMap<CommentDto, Comment>();

        }
    }
}
