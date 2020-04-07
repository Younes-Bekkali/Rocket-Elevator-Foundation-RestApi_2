using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("buildings")]
    public class Building {
        [Key]
        public long id { get; set; }
        public long customer_id {get; set;}
        public long address_id {get;set;}
        public string admin_full_name {get; set;}
        public string admin_email {get;set;}
        public string admin_phone {get;set;}
        public string tech_full_name {get;set;}
        public string tech_email {get;set;}
        public string tech_phone {get;set;}
    }
}