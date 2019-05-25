using System.Collections.Generic;
using System.Device.Location;
using System.Linq;

namespace Airbox.Infrastructure.Repositories
{
    //Currently injecting Data class to get data, should be connecting to DB
    public class UserRepository : IUserRepository
    {
        private readonly Data _userData;

        public UserRepository(Data userData)
        {
            _userData = userData;
        }

        public bool UpdateUserLocation(int userId, GeoCoordinate location)
        {
            if (!UserExists(userId)) return false;

            _userData.UserData.First(x => x.UserId == userId).CurrentLocation = location;

            if (_userData.UserData.First(x => x.UserId == userId).LocationHistory == null)
            {
                _userData.UserData.First(x => x.UserId == userId).LocationHistory = new List<GeoCoordinate>
                {
                    new GeoCoordinate
                    {
                        Longitude = location.Longitude,
                        Latitude = location.Latitude
                    }
                };
            }
            //Don't add duplicate location to the history
            else if (_userData.UserData.First(x => x.UserId == userId).LocationHistory
                         .FirstOrDefault(x => x.Longitude.Equals(location.Longitude)
                                              && x.Latitude.Equals(location.Latitude)) == null)
            {
                _userData.UserData.First(x => x.UserId == userId).LocationHistory.Add(location);
            }

            return true;
        }

        public GeoCoordinate GetUserLocation(int userId)
        {
            return _userData.UserData.FirstOrDefault(x => x.UserId == userId)?.CurrentLocation;
        }

        public IEnumerable<GeoCoordinate> GetUserLocationHistory(int userId)
        {
            return _userData.UserData.FirstOrDefault(x => x.UserId == userId)?.LocationHistory;
        }

        public Dictionary<int, GeoCoordinate> GetLocationsForAllUsers()
        {
            return _userData.UserData.Where(x => x.CurrentLocation != null)
                .ToDictionary(user => user.UserId, user => user.CurrentLocation);
        }

        public Dictionary<int, GeoCoordinate> GetLocationsForAllUsersWithinArea(GeoCoordinate location, double radius)
        {
            return _userData.UserData.Where(user => user.CurrentLocation != null && user.CurrentLocation.GetDistanceTo(location) <= radius)
                .ToDictionary(user => user.UserId, user => user.CurrentLocation);
        }

        public bool UserExists(int userId)
        {
            return _userData.UserData.FirstOrDefault(x => x.UserId == userId) != null;
        }
    }
}
