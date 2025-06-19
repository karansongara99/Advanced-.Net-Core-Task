using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Employee_Management_System.Models
{
    public class EmployeeModel
    {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            [Newtonsoft.Json.JsonIgnore]
            public string PhoneNumber { get; set; }
            public bool IsActive { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Include)]
            public DateTime DateOfBirth { get; set; }
    }
}
