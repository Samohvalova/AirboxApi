using System.Collections.Generic;
using System.Device.Location;

namespace Airbox.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        bool UpdateUserLocation(int userId, GeoCoordinate location);
        GeoCoordinate GetUserLocation(int userId);
        IEnumerable<GeoCoordinate> GetUserLocationHistory(int userId);
        Dictionary<int, GeoCoordinate> GetLocationsForAllUsers();
        Dictionary<int, GeoCoordinate> GetLocationsForAllUsersWithinArea(GeoCoordinate location, double radius);
        bool UserExists(int userId);
    }
}
