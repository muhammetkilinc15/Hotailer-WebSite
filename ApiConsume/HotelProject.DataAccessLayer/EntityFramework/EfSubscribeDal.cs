﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concreate;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
	{
		public EfSubscribeDal(Context context) : base(context)
		{
		}
	}
}
