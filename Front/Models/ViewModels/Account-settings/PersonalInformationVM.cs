using System;
using System.Collections.Generic;

namespace Front.Models.ViewModels.Account_settings
{

    public class PersonalInformationVM
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Ic { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string EmergencyContactEmail { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string PersonalPhoto { get; set; }
        public string About { get; set; }
        
    }
    public class PersonalInfoName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class PersonalInfoEmail
    {
        public string Email { get; set; }
    }
}
