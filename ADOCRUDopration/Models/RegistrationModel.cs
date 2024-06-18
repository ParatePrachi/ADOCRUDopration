using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADOCRUDopration.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public int State  { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Hobbies { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }

    public class StateModel
    {
        public int StateId { get; set; } 
        public string StateName { get; set; }   
    }
    public class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StaeId { get; set; }
    }
}