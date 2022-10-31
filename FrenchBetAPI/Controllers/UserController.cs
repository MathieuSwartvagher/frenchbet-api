using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using Models.Models;
using System.Collections.Generic;

namespace FrenchBetAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IFrenchBet _FrenchBet;

        public UserController(IFrenchBet frenchBetRepo)
        {
            _FrenchBet = frenchBetRepo;
        }

        [HttpGet]
        public List<User> Get()
        {
            try
            {
                return _FrenchBet.GetUsers();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public Community GetUser([FromBody] User user)
        {
            try
            {
                return _FrenchBet.GetCommunityByName(user.UsrName);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
