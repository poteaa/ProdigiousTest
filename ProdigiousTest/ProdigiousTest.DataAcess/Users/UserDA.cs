using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataBase;
using System.Data.Entity;

namespace ProdigiousTest.DataAcess
{
    public class UserDA : BaseDA<UserDA>
    {
        static readonly string TKN = "TKN";
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string Login()
        {
            string token = string.Empty;
            IQueryable<UserTable> usersDB = entities.Users.Where(u => u.UserName == UserName && u.Password == Password);
            if (usersDB != null && usersDB.Count() > 0)
            {
                token = TKN + usersDB.First().Password;
            }

            return token;
        }

        public bool ValidateToken(string token)
        {
            this.Password = token.Substring(TKN.Length + 1);
            UserTable userDB = entities.Users.Where(u => u.UserName == UserName && u.Password == Password).FirstOrDefault();
            return userDB != null;
        }

        public UserDA Get(string userName, string pass)
        {
            UserTable userDB = entities.Users.Where(u => u.UserName == userName && u.Password == pass).FirstOrDefault();
            return Transform(userDB);
        }
        public override List<UserDA> GetAll()
        {
            var usersDB = entities.Users.ToList();
            return Transform(usersDB);
        }
        private UserDA Transform(UserTable userDB)
        {
            return new UserDA
            {
                Id = userDB.Id,
                Name = userDB.Name,
                Age = userDB.Age,
                CityId = userDB.CityId
            };
        }
        private List<UserDA> Transform(List<UserTable> UserDB)
        {
            var usersDA = from user in UserDB
                          select new UserDA
                          {
                              Id = user.Id,
                              Name = user.Name,
                              Age = user.Age,
                              CityId = user.CityId
                          };

            return usersDA.ToList();
        }
    }
}
