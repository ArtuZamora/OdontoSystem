using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OdontoSystem.Areas.Identity.Data;

// Add profile data for application users by adding properties to the OdontoSystemUser class
public class OdontoSystemUser : IdentityUser
{
    [PersonalData]
    public string? DUI { get; set; }
    [PersonalData]
    public string? Telephone { get; set; }
    [PersonalData]
    public string? Name { get; set; }
    [PersonalData]
    public string? LastName { get; set; }
    [PersonalData]
    public string? Address { get; set; }
    [PersonalData]
    public string? Speciality { get; set; }



}

