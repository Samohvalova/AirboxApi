using System.Collections.Generic;
using Airbox.Domain.Dto;

namespace Airbox.API.Services
{
    public interface IUserService
    {
        bool UpdateUserLocation(int userId, LocationDto location);
        LocationDto GetUserLocation(int userId);
        IEnumerable<LocationDto> GetUserLocationHistory(int userId);
        Dictionary<int, LocationDto> GetLocationsForAllUsers();
        Dictionary<int, LocationDto> GetLocationsForAllUsersWithinArea(LocationDto location, double radius);
        bool UserExists(int userId);
    }
}