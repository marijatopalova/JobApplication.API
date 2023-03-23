using AutoMapper;
using JobApplication.API.DTOs.Requests;
using JobApplication.API.DTOs.Responses;
using JobApplication.API.Models;

namespace JobApplication.API.Profiles
{
    public class JobApplyProfile : Profile
    {
        public JobApplyProfile()
        {
            CreateMap<CreateCandidateRequest, Candidate>()
                .ReverseMap();

            CreateMap<CandidateResponse, Candidate>()
                .ReverseMap();
        }
    }
}
