using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataAcess;
using ProdigiousTest.Model.Entities;

namespace ProdigiousTest.Model.Managers
{
    public class CityManager : BaseManager
    {
        CityDTO cityDTO;

        public CityManager()
        {
            cityDTO = new CityDTO();
        }

        public IList<City> GetAll()
        {
            CityDA cityDA = new CityDA();
            List<CityDA> citysDA = cityDA.GetAll();
            return CityDTO.Transform(citysDA);
        }
    }
}
