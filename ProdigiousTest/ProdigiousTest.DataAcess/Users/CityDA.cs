using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataBase;
using System.Data.Entity;

namespace ProdigiousTest.DataAcess
{
    public class CityDA : BaseDA<CityDA>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public override List<CityDA> GetAll()
        {
            var citysDB = entities.Cities.ToList();
            return Transform(citysDB);
        }
        private CityDA Transform(CityTable cityDB)
        {
            return new CityDA
            {
                Id = cityDB.Id,
                Name = cityDB.Name
            };
        }
        private List<CityDA> Transform(List<CityTable> CityDB)
        {
            var citysDA = from city in CityDB
                    select new CityDA
                    {
                        Id = city.Id,
                        Name = city.Name
                    };

            return citysDA.ToList();
        }
    }
}
