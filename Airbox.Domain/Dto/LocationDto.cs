using System.ComponentModel.DataAnnotations;

namespace Airbox.Domain.Dto
{
    public class LocationDto
    {
        [Range(-90, 90, ErrorMessage = "Value for latitude must be between -90 and 90.")]
        [Required]
        public double Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Value for longitude must be between -180 and 180.")]
        [Required]
        public double Longitude { get; set; }
    }
}
