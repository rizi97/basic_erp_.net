using AutoMapper;
using HMS_ERP.Dtos;
using HMS_ERP.Models;

namespace HMS_ERP.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentReadDto>();
            CreateMap<Appointment, AppointmentPatientReadDto>();
            CreateMap<Appointment, AppointmentDoctorReadDto>();
            CreateMap<AppointmentCreateDto, Appointment>();
        }
    }
}
