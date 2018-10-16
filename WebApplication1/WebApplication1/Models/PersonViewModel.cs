using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
       [required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [required]
        [DataType(DataType.Date)]

        public System.DateTime AddedOn { get; set; }
        [required]
        public string AddedBy { get; set; }
        public string HomeAddress { get; set; }
        [required]
        public string HomeCity { get; set; }
        public string FaceBookAccountId { get; set; }
        public string LinkedInId { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public string ImagePath { get; set; }
        public string TwitterId { get; set; }
        [required]
        public string EmailId { get; set; }

        
    }

    

   
}