using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using Airbox.Domain.Dto;
using Airbox.Infrastructure.Repositories;

namespace Airbox.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UpdateUserLocation(int userId, LocationDto location)
        {
            return _userRepository.UpdateUserLocation(userId, new GeoCoordinate(location.Latitude, location.Longitude));
        }

        public LocationDto GetUserLocation(int userId)
        {
            var userCurrentGeoCoordinate = _userRepository.GetUserLocation(userId);
            return userCurrentGeoCoordinate == null ? null : new LocationDto
            {
                Longitude = userCurrentGeoCoordinate.Longitude,
                Latitude = userCurrentGeoCoordinate.Latitude
            };
        }

        public IEnumerable<LocationDto> GetUserLocationHistory(int userId)
        {
            return _userRepository.GetUserLocationHistory(userId)?.Select(history => new LocationDto
            {
                Longitude = history.Longitude,
                Latitude = history.Latitude
            }).ToList();
        }

        public Dictionary<int, LocationDto> GetLocationsForAllUsers()
        {
            return _userRepository.GetLocationsForAllUsers()?.ToDictionary(dictionary => dictionary.Key, dictionary =>
               new LocationDto
               {
                   Longitude = dictionary.Value.Longitude,
                   Latitude = dictionary.Value.Latitude
               });
        }

        public Dictionary<int, LocationDto> GetLocationsForAllUsersWithinArea(LocationDto location, double radius)
        {
            return _userRepository.GetLocationsForAllUsersWithinArea(new GeoCoordinate(location.Latitude, location.Longitude), radius)
                ?.ToDictionary(dictionary => dictionary.Key, dictionary =>
                new LocationDto
                {
                    Longitude = dictionary.Value.Longitude,
                    Latitude = dictionary.Value.Latitude
                });
        }

        public bool UserExists(int userId)
        {
            return _userRepository.UserExists(userId);
        }
    }
}
