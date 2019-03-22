using SportEvents.Services.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportEvents.Web.Server.Models.InputModels
{
    public class EventInputModel : IValidatableObject
    {
        [Required]
        public int EventID { get; set; }

        [Required]
        public string EventName { get; set; }

        [Range(1, double.MaxValue)]
        public double? OddsForFirstTeam { get; set; }

        [Range(1, double.MaxValue)]
        public double? OddsForDraw { get; set; }

        [Range(1, double.MaxValue)]
        public double? OddsForSecondTeam { get; set; }

        [Required]
        public DateTime EventStartDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTimeExtentions.EndOfDateTime(new DateTime()) > this.EventStartDate)
            {
                yield return new ValidationResult("Event start date should be after or equal 23:59 from today!");
            }
        }
    }
}