using AutoMapper;
using CareerAdvisor.Application.DTOs;
using CareerAdvisor.Application.DTOs.Requests;
using CareerAdvisor.Application.UserProfiles.Commands;
using CareerAdvisor.Domain.Entities;


namespace CareerAdvisor.Application.Mappings
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<CreateUserProfileCommand, UserProfile>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CreateUserProfileRequest, CreateUserProfileCommand>();

            CreateMap<UserProfile, UserProfileDto>();
        }
    }
}
