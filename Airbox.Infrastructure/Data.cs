using System.Collections.Generic;
using System.Device.Location;
using Airbox.Domain.Dto;

namespace Airbox.Infrastructure
{
    public class Data
    {
        public IList<UserDto> UserData;

        public Data()
        {
            UserData = GetData();
        }

        private IList<UserDto> GetData()
        {
            var data = new List<UserDto>
            {
                new UserDto
                {
                    UserId = 1,
                    CurrentLocation = new GeoCoordinate
                    {
                        Latitude = 51.605235,
                        Longitude = -1.445168
                    },
                    LocationHistory = new List<GeoCoordinate>
                    {
                        new GeoCoordinate
                        {
                            Latitude = 51.588625,
                            Longitude = -1.426459
                        },
                        new GeoCoordinate
                        {
                            Latitude = 51.751402,
                            Longitude = -1.257365
                        },
                        new GeoCoordinate
                        {
                            Latitude = 51.605235,
                            Longitude = -1.445168
                        }
                    }
                },
                new UserDto
                {
                    UserId = 2,
                    CurrentLocation = new GeoCoordinate
                    {
                        Latitude = 51.500152,
                        Longitude = -0.126236
                    },
                    LocationHistory = new List<GeoCoordinate>
                    {
                        new GeoCoordinate
                        {
                            Latitude = 51.605235,
                            Longitude = -1.445168
                        },
                        new GeoCoordinate
                        {
                            Latitude = 51.500152,
                            Longitude = -0.126236
                        }
                    }
                },
                new UserDto
                {
                    UserId = 3,
                    CurrentLocation = new GeoCoordinate
                    {
                        Latitude = 12.497050,
                        Longitude = 99.699979
                    },
                    LocationHistory = new List<GeoCoordinate>
                    {
                        new GeoCoordinate
                        {
                            Latitude = 15.660392,
                            Longitude = 101.520053
                        },
                        new GeoCoordinate
                        {
                            Latitude = 13.753939,
                            Longitude = 100.501289
                        },
                        new GeoCoordinate
                        {
                            Latitude = 12.497050,
                            Longitude = 99.699979
                        }
                    }
                },
                new UserDto
                {
                    UserId = 4,
                    CurrentLocation = new GeoCoordinate
                    {
                        Latitude = 40.755931,
                        Longitude = -73.984606
                    },
                    LocationHistory = new List<GeoCoordinate>
                    {
                        new GeoCoordinate
                        {
                            Latitude = 40.755931,
                            Longitude = -73.984606
                        }
                    }
                },
                new UserDto
                {
                    UserId = 5
                }
            };

            return data;
        }
    }
}
