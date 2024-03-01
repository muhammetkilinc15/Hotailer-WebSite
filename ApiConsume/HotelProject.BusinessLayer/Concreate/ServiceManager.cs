﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concreate
{
	public class ServiceManager : IServiceService
	{
		private readonly IServiceDal _serviceDal;

		public ServiceManager(IServiceDal serviceDal)
		{
			_serviceDal = serviceDal;
		}

		public void TAdd(Service entity)
		{
			_serviceDal.Insert(entity);
		}

		public void TDelete(Service entity)
		{
			_serviceDal.Delete(entity);
		}

		public Service TGetByID(int id)
		{
			return _serviceDal.GetByID(id);
		}

		public List<Service> TGetList()
		{
			return _serviceDal.GetList();
		}

		public void TUpdate(Service entity)
		{
			_serviceDal.Update(entity);
		}
	}
}
