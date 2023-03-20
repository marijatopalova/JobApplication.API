using AutoMapper;
using JobApplication.API.DTOs.Requests;
using JobApplication.API.DTOs.Responses;
using JobApplication.API.Enums;
using JobApplication.API.Models;

namespace JobApplication.API.Profiles
{
    public class JobPostProfile : Profile
    {
        public JobPostProfile()
        {
            CreateMap<JobPost, JobPostResponse>()
                .ForMember(dest =>
                    dest.IndustryName,
                    opt => opt.MapFrom(src => src.Industry.Name))
                .ForMember(dest =>
                    dest.SeniorityLevel,
                    opt => opt.MapFrom(src => (int)src.SeniorityLevel))
                .ForMember(dest =>
                    dest.EmploymentType,
                    opt => opt.MapFrom(src => (int)src.EmploymentType))
                .ForMember(dest =>
                    dest.ActiveStatus,
                    opt => opt.MapFrom(src => (int)src.ActiveStatus));

            CreateMap<CreateJobPostRequest, JobPost>()
                .ReverseMap();

            CreateMap<UpdateJobPostRequest, JobPost>()
                .ReverseMap();
        }
    }
}
