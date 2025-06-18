namespace Hospital_Management_System.Models
{
    public class PatientMaster
    {
            public int PatientID { get; set; }
            public string? PatientName { get; set; }
            public string? ContactNo { get; set; }
            public int? Age { get; set; }
            public bool? EarlierOperation { get; set; }
            public string? BloodGroup { get; set; }
    }
}
