using AutoMapper;
using HMS_ERP.Dtos;
using HMS_ERP.Models;

namespace HMS_ERP.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            //source -> target
            CreateMap<Patient, PatientReadDto>();
            CreateMap<Patient, PatientLoginDto>();
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();
        }
    }
}
