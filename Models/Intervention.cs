using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models
{

    [Table("interventions")]
    public class Intervention
    {
        public long id { get; set; }
        public string status { get; set; }
        public long battery_id { get; set; }
        public long author { get; set; }
        public long customer_id { get; set; }
        public long building_id { get; set; }
        public long column_id { get; set; }
        public long? elevator_id { get; set; }
        public long employee_id { get; set; }
        public DateTime? start_intervention { get; set; }
        public DateTime? end_intervention { get; set; }
        public String result { get; set; } 
        public String report { get; set; } 

    }
}   