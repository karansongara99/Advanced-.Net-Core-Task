using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAPIController : ControllerBase
    {
        public readonly ClassTaskContext _context;
        public DoctorAPIController(ClassTaskContext context)
        {
            _context = context;
        }

        #region GetAllDoctorData
        [HttpGet]
        public IActionResult GetDoctorData()
        {
            var doctor = _context.DoctorMasters.ToList();
            return Ok(doctor);
        }
        #endregion

        #region GetByIDDoctorData
        [HttpGet("{id}")]
        public IActionResult DoctorGetByID(int id)
        {
            var doctor = _context.DoctorMasters.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        #endregion

        #region DeleteByIDDoctorData
        [HttpDelete("{id}")]
        public IActionResult DoctorGetByIDDelete(int id)
        {
            var doctor = _context.DoctorMasters.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            _context.DoctorMasters.Remove(doctor);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region InsertDoctorData
        [HttpPost]
        public IActionResult DoctorInsert(DoctorMaster doctor)
        {
            _context.DoctorMasters.Add(doctor);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region UpdateByIDDoctorData
        [HttpPut("{id}")]
        public IActionResult UpdateDoctorData(DoctorMaster doctor, int id)
        {
            if (id != doctor.DoctorID)  // Ensure route ID matches the student ID 
            {
                return BadRequest();
            }
            var existingDoctor = _context.DoctorMasters.Find(id);
            if (existingDoctor == null)
            {
                return NotFound();
            }
            existingDoctor.DoctorID = doctor.DoctorID;
            existingDoctor.DoctorName = doctor.DoctorName;
            existingDoctor.Degree = doctor.Degree;
            existingDoctor.Experience = doctor.Experience;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.Age = doctor.Age;
            existingDoctor.DOB = doctor.DOB;
          

            _context.DoctorMasters.Update(existingDoctor);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
