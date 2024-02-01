using AutoMapper;
using HMS_ERP.Controllers.Common;
using HMS_ERP.Data;
using HMS_ERP.Dtos;
using HMS_ERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HMS_ERP.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUserRepo<Patient> _repository;
        private readonly IMapper _mapper;
        private readonly General _generalObj;

        public PatientController(IUserRepo<Patient> repository, IMapper mapper, IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;

            _generalObj = new General(config);
        }


        [AllowAnonymous]
        [HttpPost("LoginPatient")]
        public ActionResult<PatientLoginDto> LoginPatient(PatientLoginDto patient)
        {
            ActionResult response = Unauthorized();

            var ecryptedPass = _generalObj.PasswordEncodeBase64(patient.PatientPassword);
            var _patient = _repository.GetUserByUsernamePassword(patient.PatientName, ecryptedPass);

            if (_patient != null)
            {
                var token = _generalObj.GenerateToken(_patient);
                response = Ok(new { token, data = _mapper.Map<PatientReadDto>(_patient) });
            }

            return response;
        }


        [HttpPost("RegisterPatient")]
        public ActionResult<PatientReadDto> RegisterPatient(PatientCreateDto patientCreateDto)
        {
            var _patient = _repository.GetUserByEmail(patientCreateDto.PatientEmail);
            
            if (_patient != null)
                return NotFound(new { code = 404, msg = "Already Patient exists, please change the email." });


            var patientModel = _mapper.Map<Patient>(patientCreateDto);
            var ecryptedPass = _generalObj.PasswordEncodeBase64(patientModel.PatientPassword);
            patientModel.PatientPassword = ecryptedPass;

            _repository.CreateUser(patientModel);

            return Ok(_mapper.Map<PatientReadDto>(patientModel));
        }


        [HttpPut("{id}")]
        public ActionResult UpdatePatient(int id, PatientUpdateDto patientUpdateDto)
        {
            var patientModelRepo = _repository.GetUserById(id);
            
            if (patientModelRepo == null)
                return NotFound();

            _mapper.Map(patientUpdateDto, patientModelRepo);
            _repository.UpdateUser(patientModelRepo);
            _repository.SaveChanges();

            return Ok(_mapper.Map<PatientReadDto>(patientModelRepo));
        }


        [HttpGet]
        public ActionResult<IEnumerable<PatientReadDto>> GetAllPatients()
        {
            var patients = _repository.GetAllUsers();

            if (!patients.Any())
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<PatientReadDto>>(patients));
        }


        [HttpGet("{id}")]
        public ActionResult<PatientReadDto> GetPatientById(int id)
        {
            var patient = _repository.GetUserById(id);

            if (patient == null)
                return NotFound();

            return Ok(_mapper.Map<PatientReadDto>(patient));
        }


        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            var patient = _repository.GetUserById(id);

            if (patient == null)
                return NotFound();


            _repository.DeleterUser(patient);

            return Ok(new
            {
                code = 200,
                msg = "Successfully deleted patient-" + id
            });
        }

    }
}
