using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models
{

    [Table("customers")]
    
    public class Customer
    {
        public int id {get; set;}
        public DateTime customer_create_date { get; set; }
        public string company_name { get; set; }
        public string name_company_contact { get; set; }
        public string company_phone { get; set; }
        public string contact_email { get; set; }
        public string company_desc { get; set; }
        public string full_name_STA { get; set; }
        public string tech_authority_phone { get; set; }
        public string tech_manager_email { get; set; }
        public long address_id { get; set; }
      
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }


    
}   