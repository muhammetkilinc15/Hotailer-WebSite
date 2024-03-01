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
	public class StaffManager : IStaffService
	{
		private readonly IStaffDal _staffDal;

		public StaffManager(IStaffDal staffDal)
		{
			_staffDal = staffDal;
		}

		public void TAdd(Staff entity)
		{
			_staffDal.Insert(entity);
		}

		public void TDelete(Staff entity)
		{
			_staffDal.Delete(entity);
		}

		public Staff TGetByID(int id)
		{
			return _staffDal.GetByID(id);
		}

		public List<Staff> TGetList()
		{
			return _staffDal.GetList();
		}

		public void TUpdate(Staff entity)
		{
			throw new NotImplementedException();
		}
	}
}
