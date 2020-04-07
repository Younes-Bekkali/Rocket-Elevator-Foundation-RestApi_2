using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models
{

    [Table("leads")]
    public class Lead
    {
        public int id {get; set;}
        public string full_name { get; set; } 

        public string company_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string project_name { get; set; }
        public string project_desc { get; set; }
        public string department { get; set; }
        public string message { get; set; }

        public byte[] attached_file { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }


    }
}   