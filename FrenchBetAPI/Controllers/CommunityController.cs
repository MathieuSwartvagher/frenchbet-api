using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models.Models;
using Models.Interfaces;

namespace FrenchBet.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CommunityController : ControllerBase
    {
        private readonly IFrenchBet _FrenchBet;

        public CommunityController(IFrenchBet frenchBetRepo)
        {
            _FrenchBet = frenchBetRepo;
        }

        [HttpGet]
        public List<Community> Get()
        {
            try
            {
                return _FrenchBet.GetCommunities();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public Community GetUser([FromBody]Community community)
        {
            try
            {
                return _FrenchBet.GetCommunityByName(community.ComName);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
