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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDAl appUserDAl;

        public AppUserManager(IAppUserDAl appUserDAl)
        {
            this.appUserDAl = appUserDAl;
        }

        public void TAdd(AppUser entity)
        {
            appUserDAl.Insert(entity);
        }

        public void TDelete(AppUser entity)
        {
           appUserDAl.Delete(entity);
        }

        public AppUser TGetByID(int id)
        {
           return appUserDAl.GetByID(id);
        }

        public List<AppUser> TGetList()
        {
            return appUserDAl.GetList();
        }

        public void TUpdate(AppUser entity)
        {
            appUserDAl.Update(entity);
        }

        public List<AppUser> TUserListWithWorkLocation()
        {
           return appUserDAl.UserListWithWorkLocation();
        }
    }
}
