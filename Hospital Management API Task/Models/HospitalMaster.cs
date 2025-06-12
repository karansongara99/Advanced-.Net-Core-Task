using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Models;

public partial class HospitalMaster
{
    public int HospitalId { get; set; }

    public string? HospitalName { get; set; }

    public string? HospitalAddress { get; set; }

    public string? ContactNumber { get; set; }

    public string? EmailAddress { get; set; }

    public string? OwnerName { get; set; }

    public DateTime? OpeningDate { get; set; }

    public int? TotalStaffs { get; set; }

    public bool? SundayOpen { get; set; }
}
