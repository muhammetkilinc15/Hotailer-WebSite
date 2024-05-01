using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concreate
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            this.guestDal = guestDal;
        }

        public void TAdd(Guest entity)
        {
            guestDal.Insert(entity);
        }

        public void TDelete(Guest entity)
        {
            guestDal.Delete(entity);
        }

        public Guest TGetByID(int id)
        {
            return guestDal.GetByID(id);
        }

        public List<Guest> TGetList()
        {
            return guestDal.GetList();
        }

        public void TUpdate(Guest entity)
        {
            guestDal.Update(entity);
        }
    }
}
