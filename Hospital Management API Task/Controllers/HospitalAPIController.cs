using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalAPIController : ControllerBase
    {
        public readonly ClassTaskContext _context;
        public HospitalAPIController(ClassTaskContext context)
        {
            _context = context;
        }

        #region GetAllHospitalData
        [HttpGet]
        public IActionResult GetHospitalData()
        {
            var hospital = _context.HospitalMasters.ToList();
            return Ok(hospital);
        }
        #endregion

        #region GetByIDHospitalaData
        [HttpGet("{id}")]
        public IActionResult HospitalGetByID(int id)
        {
            var hospital = _context.HospitalMasters.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return Ok(hospital);
        }
        #endregion

        #region DeleteByIDHospitalaData
        [HttpDelete("{id}")]
        public IActionResult HospitalGetByIDDelete(int id)
        {
            var hospital = _context.HospitalMasters.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }
            _context.HospitalMasters.Remove(hospital);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region InsertHospitalData
        [HttpPost]
        public IActionResult HospitalInsert(HospitalMaster hospital)
        {
            _context.HospitalMasters.Add(hospital);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region UpdateByIDHospitalData
        [HttpPut("{id}")]
        public IActionResult UpdateHospitalData(HospitalMaster hospital,int id)
        {
            if (id != hospital.HospitalId)  // Ensure route ID matches the student ID 
            {
                return BadRequest();
            }
            var existingHospital = _context.HospitalMasters.Find(id);
            if (existingHospital == null)
            {
                return NotFound();
            }
            existingHospital.HospitalName = hospital.HospitalName;
            existingHospital.HospitalAddress = hospital.HospitalAddress;
            existingHospital.ContactNumber = hospital.ContactNumber;
            existingHospital.EmailAddress = hospital.EmailAddress;
            existingHospital.OwnerName = hospital.OwnerName;
            existingHospital.OpeningDate = hospital.OpeningDate;
            existingHospital.TotalStaffs = hospital.TotalStaffs;
            existingHospital.SundayOpen = hospital.SundayOpen;

            _context.HospitalMasters.Update(existingHospital);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
