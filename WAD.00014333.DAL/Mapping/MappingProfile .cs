using AutoMapper;
using WAD._00014333.DTOs;
using WAD._00014333.Models;

namespace WAD._00014333.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Job, JobDto>();

            CreateMap<CompanyDto, Company>();
            CreateMap<JobDto, Job>();
        }
    }
}
