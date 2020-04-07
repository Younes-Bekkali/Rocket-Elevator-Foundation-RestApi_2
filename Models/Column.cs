using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models
{

    [Table("columns")]
    public class Column
    {
        public int id {get; set;}
        public string column_type {get; set;}
        public int number_floors {get; set;}
        public string status {get; set;}
        public string info {get; set;}
        public string notes {get; set;}
        public long battery_id { get; set;} 
    }
}   