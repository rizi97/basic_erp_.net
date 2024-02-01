using AutoMapper;
using HMS_ERP.Dtos;
using HMS_ERP.Models;

namespace HMS_ERP.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorReadDto>();
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
        }
    }
}
