using AutoMapper;
using HMS_ERP.Data;
using HMS_ERP.Dtos;
using HMS_ERP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HMS_ERP.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUserRepo<Doctor> _repository;
        private readonly IMapper _mapper;

        public DoctorController(IUserRepo<Doctor> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDto>> GetAllDoctors()
        {
            var doctors = _repository.GetAllUsers();

            if (!doctors.Any())
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<DoctorReadDto>>(doctors));
        }


        [HttpGet("{id}")]
        public ActionResult<DoctorReadDto> GetDoctorById(int id)
        {
            var doctor = _repository.GetUserById(id);

            if (doctor == null)
                return NotFound();

            return Ok(_mapper.Map<DoctorReadDto>(doctor));
        }


        [HttpPost]
        public ActionResult<DoctorReadDto> RegisterDoctor(DoctorCreateDto doctorCreateDto)
        {
            var _doctor = _repository.GetUserByEmail(doctorCreateDto.DoctorEmail);

            if (_doctor != null)
                return NotFound(new { code = 404, msg = "Already Doctor exists, please change the email." });


            var doctorModel = _mapper.Map<Doctor>(doctorCreateDto);

            _repository.CreateUser(doctorModel);

            return Ok(_mapper.Map<DoctorReadDto>(doctorModel));
        }


        [HttpPut("{id}")]
        public ActionResult<DoctorReadDto> UpdateDoctor(int id, DoctorUpdateDto doctorUpdateDto)
        {
            var doctorItem = _repository.GetUserById(id);

            if (doctorItem == null)
                return NotFound();


            var doctorModel = _mapper.Map(doctorUpdateDto, doctorItem);

            _repository.UpdateUser(doctorModel);
            _repository.SaveChanges();

            return Ok(_mapper.Map<DoctorReadDto>(doctorModel));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(int id)
        {
            var doctor = _repository.GetUserById(id);
            
            if (doctor == null)
                return NotFound();


            _repository.DeleterUser(doctor);

            return Ok(new
            {
                code = 200,
                msg = "Successfully deleted doctor-" + id
            });
        }

    }
}
