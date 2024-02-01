using AutoMapper;
using HMS_ERP.Data;
using HMS_ERP.Dtos;
using HMS_ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace HMS_ERP.Controllers.Common
{
    [ApiController]
    [Route("/api/appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _repository;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<AppointmentReadDto>> GetAllAppointments([FromQuery] int page, [FromQuery] int limit)
        {
            if (limit < 0 || page < 0)
                return NotFound("Kindly enter greater than poistive zero number or make it empty.");

            var data = _repository.GetAllAppointements(page, limit);

            if (!data.Any())
                return NotFound();


            return Ok(_mapper.Map<IEnumerable<AppointmentReadDto>>(data));
        }


        [HttpGet("doctor/{id}")]
        public ActionResult<IEnumerable<AppointmentDoctorReadDtoWrapper>> GetAllDoctorRecords(int id)
        {
            var data = _repository.GetAllDoctorRecords(id);

            if (!data.Any())
                return NotFound();


            var appointmentModel = _mapper.Map<IEnumerable<AppointmentDoctorReadDto>>(data);

            var doctorName = appointmentModel.FirstOrDefault()?.Doctor?.DoctorName;
            var doctorGender = appointmentModel.FirstOrDefault()?.Doctor?.DoctorGender;


            var wrapper = new AppointmentDoctorReadDtoWrapper
            {
                TotalAppointments = appointmentModel.Count(),
                DoctorName = doctorName,
                DoctorGender = doctorGender,
                Appointments = appointmentModel
            };

            return Ok(wrapper);
        }


        [HttpGet("patient/{id}")]
        public ActionResult<AppointmentPatientReadDtoWrapper> GetAllPatientRecords(int id)
        {
            var data = _repository.GetAllPatientRecords(id);

            if (!data.Any())
                return NotFound();


            var appointmentModel = _mapper.Map<IEnumerable<AppointmentPatientReadDto>>(data);


            var patientName = appointmentModel.FirstOrDefault()?.Patient?.PatientName;
            var patientDescription = appointmentModel.FirstOrDefault()?.Patient?.PatientDescription;
            var patientGender = appointmentModel.FirstOrDefault()?.Patient?.PatientGender;


            var wrapper = new AppointmentPatientReadDtoWrapper
            {
                TotalAppointments = appointmentModel.Count(),
                PatientName = patientName,
                PatientDescription = patientDescription,
                PatientGender = patientGender,
                Appointments = appointmentModel
            };

            return Ok(wrapper);
        }



        [HttpPost]
        public ActionResult<AppointmentReadDto> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
        { 
            var appointmentModel = _mapper.Map<Appointment>(appointmentCreateDto);

            appointmentModel.DateTime = DateTime.Now;

            _repository.CreateAppointment(appointmentModel);

            return Ok(_mapper.Map<AppointmentReadDto>(appointmentModel));
        }


        //[HttpDelete("{id}")]
        //public ActionResult DeleteAppointement(int id)
        //{
        //    var appointment = _repository.GetAppointmentById(id);

        //    if (appointment == null) 
        //        return NotFound();


        //    _repository.DeleteAppointment(appointment);

        //    return Ok(new
        //    {
        //        code = 200,
        //        msg = "Successfully deleted appointment-" + id
        //    });
        //}

        [HttpDelete("patient/{id}")]
        public ActionResult DeletePatientAppointements(int id)
        {
            _repository.DeletePatientAppointments(id);

            return Ok(new
            {
                code = 200,
                msg = "Successfully deleted all appointments"
            });
        }
    }
}
