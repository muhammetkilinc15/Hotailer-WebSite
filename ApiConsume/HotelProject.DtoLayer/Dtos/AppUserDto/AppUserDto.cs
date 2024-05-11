using HotelProject.DtoLayer.Dtos.WorkLocationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.AppUserDto
{
    public class AppUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int WorkLocationId { get; set; }
        public ResultWorkLocationDto WorkLocation { get; set; }

    }
}
