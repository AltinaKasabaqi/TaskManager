using AutoMapper;
using TaskManager.Models;

namespace TaskManager.Helpers
{
      public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Entities.Task, CreateTaskModel>()
                .ReverseMap();
        }
    }
}

