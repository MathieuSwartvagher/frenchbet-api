using Models.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class FrenchBetRepo : IFrenchBet
    {
        private readonly frenchbetContext _frenchbetContext;

        public FrenchBetRepo(frenchbetContext frenchbetContext)
        {
            _frenchbetContext = frenchbetContext;
        }

        public List<Community> GetCommunities()
        {
            try
            {
                return _frenchbetContext.Communities.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Community GetCommunityByName(string ComName)
        {
            try
            {
                return _frenchbetContext.Communities.Where(x => x.ComName.ToLower().Equals(ComName.ToLower())).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetUserByName(string UsrName)
        {
            try
            {
                return _frenchbetContext.Users.Where(x => x.UsrName.ToLower().Equals(UsrName.ToLower())).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return _frenchbetContext.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
