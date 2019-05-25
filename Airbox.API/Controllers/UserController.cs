using System;
using System.Linq;
using System.Net;
using Airbox.API.Services;
using Airbox.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Airbox.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Updates user current location
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="location">Location</param>
        /// <returns>True or false whether user location has been updated</returns>
        [HttpPut("location/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult UpdateUserLocation(int userId, LocationDto location)
        {
            try
            {
                if (!_userService.UserExists(userId))
                {
                    return Ok($"No user with userId - {userId} has been found");
                }

                return _userService.UpdateUserLocation(userId, location) ?
                    Ok($"Current location for userId - {userId} has been updated") :
                    Ok($"Current location for userId - {userId} has not been updated");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to perform action due to: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets user current location
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>User current location</returns>
        [HttpGet("location/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetUserLocation(int userId)
        {
            try
            {
                if (!_userService.UserExists(userId))
                {
                    return Ok($"No user with userId - {userId} has been found");
                }

                var userLocation = _userService.GetUserLocation(userId);
                return userLocation == null ?
                    Ok($"No current location for userId - {userId} has been found") :
                    Ok(userLocation);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to perform action due to: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets user location history
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>User location history</returns>
        [HttpGet("location/history/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetUserLocationHistory(int userId)
        {
            try
            {
                if (!_userService.UserExists(userId))
                {
                    return Ok($"No user with userId - {userId} has been found");
                }

                var userLocationHistory = _userService.GetUserLocationHistory(userId);
                return userLocationHistory == null ?
                    Ok($"No location history for userId - {userId} has been found") :
                    Ok(userLocationHistory);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to perform action due to: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets current locations for all users
        /// </summary>
        /// <returns>List of users with their current location</returns>
        [HttpGet("location/all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetLocationsForAllUsers()
        {
            try
            {
                var userLocations = _userService.GetLocationsForAllUsers();
                return !userLocations.Any() ? Ok($"No users have been found") : Ok(userLocations);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to perform action due to: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets current locations for all users within an area
        /// </summary>
        /// <param name="location">Location area, specify Longitude & Latitude</param>
        /// <param name="radius">Radius in meters from location</param>
        /// <returns>List of users with current location being within the area</returns>
        [HttpGet("location/all/area")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetLocationsForAllUsersWithinArea(LocationDto location, double radius)
        {
            try
            {
                var users = _userService.GetLocationsForAllUsersWithinArea(location, radius);
                return !users.Any() ? Ok($"No users have been found with the current location within the area") : Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to perform action due to: {ex.Message}");
            }
        }
    }
}
