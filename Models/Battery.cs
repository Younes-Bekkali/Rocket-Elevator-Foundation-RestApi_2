using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("batteries")]
    public class Battery {
        [Key]
        public long id { get; set; }
        public long building_id { get; set; }
        [ForeignKey("building_id")]
        public long employee_id { get; set; }
        [ForeignKey("employee_id")]
        public string battery_type { get; set; }
        public string status { get; set; }
        // public DateTime date_commission { get; set; }
        // public DateTime date_last_inspect { get; set; }
        // public DateTime date_commision { get; set; }
        // public string info { get; set; }
        // public string notes { get; set;}
        // public DateTime created_at { get; set;}
        // public DateTime updated_at { get; set;} 
    }
}