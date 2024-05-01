using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.GuestDto
{
    public class GuestUpdateDto
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Suname { get; set; }
        public string City { get; set; }
    }
}
