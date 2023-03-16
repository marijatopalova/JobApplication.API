using AutoMapper;
using JobApplication.API.DTOs.Responses;
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
                    opt => opt.MapFrom(src => src.Industry.Name));
        }
    }
}
