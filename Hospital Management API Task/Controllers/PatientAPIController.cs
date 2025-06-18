using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        public readonly ClassTaskContext _context;
        public PatientAPIController(ClassTaskContext context)
        {
            _context = context;
        }

        #region GetAllPatientData
        [HttpGet]
        public IActionResult GetPatientData()
        {
            var patient = _context.PatientMasters.ToList();
            return Ok(patient);
        }
        #endregion

        #region GetByIDPatientData
        [HttpGet("{id}")]
        public IActionResult PatientGetByID(int id)
        {
            var patient = _context.PatientMasters.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        #endregion

        #region DeleteByIDPatientData
        [HttpDelete("{id}")]
        public IActionResult PatientGetByIDDelete(int id)
        {
            var patient = _context.PatientMasters.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            _context.PatientMasters.Remove(patient);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region InsertPatientData
        [HttpPost]
        public IActionResult PatientInsert(PatientMaster Patient)
        {
            _context.PatientMasters.Add(Patient);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region UpdateByIDPatientData
        [HttpPut("{id}")]
        public IActionResult UpdatePatientData(PatientMaster patient, int id)
        {
            if (id != patient.PatientID)  // Ensure route ID matches the student ID 
            {
                return BadRequest();
            }
            var existingPatient = _context.PatientMasters.Find(id);
            if (existingPatient == null)
            {
                return NotFound();
            }
            existingPatient.PatientID = patient.PatientID;
            existingPatient.PatientName = patient.PatientName;
            existingPatient.ContactNo = patient.ContactNo;
            existingPatient.Age = patient.Age;
            existingPatient.EarlierOperation = patient.EarlierOperation;
            existingPatient.BloodGroup = patient.BloodGroup;


            _context.PatientMasters.Update(existingPatient);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
