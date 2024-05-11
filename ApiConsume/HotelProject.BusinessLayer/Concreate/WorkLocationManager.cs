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
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            this.workLocationDal = workLocationDal;
        }

        public void TAdd(WorkLocation entity)
        {
            workLocationDal.Insert(entity);
        }

        public void TDelete(WorkLocation entity)
        {
            workLocationDal.Delete(entity);
        }

        public WorkLocation TGetByID(int id)
        {
            return workLocationDal.GetByID(id);
        }

        public List<WorkLocation> TGetList()
        {
           return workLocationDal.GetList();
        }

        public void TUpdate(WorkLocation entity)
        {
            workLocationDal.Update(entity);
        }
    }
}
