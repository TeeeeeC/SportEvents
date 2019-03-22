using System;
using System.ComponentModel.DataAnnotations;

namespace SportEvents.Data.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [MaxLength(100, ErrorMessage = "Max length is 100 symbols!")]
        public string EventName { get; set; }

        [Range(1, double.MaxValue)]
        public double? OddsForFirstTeam { get; set; }

        [Range(1, double.MaxValue)]
        public double? OddsForDraw { get; set; }

        [Range(1, double.MaxValue)]
        public double? OddsForSecondTeam { get; set; }

        [Required]
        public DateTime EventStartDate { get; set; }
    }
}
