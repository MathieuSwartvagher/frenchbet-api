using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IFrenchBet
    {
        //Communities
        List<Community> GetCommunities();
        Community GetCommunityByName(string ComName);


        //User
        List<User> GetUsers();
        User GetUserByName(string UsrName);
    }
}
