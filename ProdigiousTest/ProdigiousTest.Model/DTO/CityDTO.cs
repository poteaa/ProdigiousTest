using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProdigiousTest.DataAcess;

namespace ProdigiousTest.Model.Entities
{
    public class CityDTO
    {
        public static City Transform(CityDA cityDA)
        {
            return new City
            {
                Id = cityDA.Id,
                Name = cityDA.Name
            };
        }

        public static CityDA Transform(City city)
        {
            return new CityDA
            {
                Id = city.Id,
                Name = city.Name,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }


        public static List<City> Transform(List<CityDA> citysDA)
        {
            var citys = from cityDA in citysDA
                           select new City
                           {
                               Id = cityDA.Id,
                               Name = cityDA.Name
                           };

            return citys.ToList();
        }

        public static List<CityDA> Transform(List<City> citys)
        {
            var citysDA = from city in citys
                             select new CityDA
                             {
                                 Id = city.Id,
                                 Name = city.Name,
                                 CreatedDate = DateTime.Now,
                                 UpdatedDate = DateTime.Now
                             };

            return citysDA.ToList();
        }
    }
}
