﻿using HotelProject.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IAppUserDAl : IGenericDal<AppUser>
    {
        List<AppUser> UserListWithWorkLocation();
    }
}
