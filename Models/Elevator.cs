using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models
{

    [Table("elevators")]
    public class Elevator
    {
        [Key]
        public long id {get; set;}
        public int column_id {get; set; }
        [ForeignKey("column_id")]
        public string status {get; set; }
     
    }
}
