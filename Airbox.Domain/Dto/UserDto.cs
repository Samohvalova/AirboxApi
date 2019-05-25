using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;

namespace Airbox.Domain.Dto
{
    public class UserDto
    {
        [Required]
        public int UserId { get; set; }

        public GeoCoordinate CurrentLocation { get; set; }

        public IList<GeoCoordinate> LocationHistory { get; set; }
    }
}
