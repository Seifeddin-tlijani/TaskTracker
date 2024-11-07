using AutoMapper;
using TaskTrack.DAL.Entities;
using TaskTrack.Models;

namespace TaskTrack.DAL.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<Entities.Task, TaskModel>().ReverseMap();
            CreateMap<Team, TeamModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Comment, CommentModel>().ReverseMap();
        }




    }
}
