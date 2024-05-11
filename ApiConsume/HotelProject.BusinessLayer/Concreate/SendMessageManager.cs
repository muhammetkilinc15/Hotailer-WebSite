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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            this.sendMessageDal = sendMessageDal;
        }

        public void TAdd(SendMessage entity)
        {
            sendMessageDal.Insert(entity);
        }

        public void TDelete(SendMessage entity)
        {
            sendMessageDal.Delete(entity);
        }

        public SendMessage TGetByID(int id)
        {
            return sendMessageDal.GetByID(id);
        }

        public List<SendMessage> TGetList()
        {
            return sendMessageDal.GetList();
        }

		public int TGetSendMessageCount()
		{
			return sendMessageDal.GetSendMessageCount();
		}

		public void TUpdate(SendMessage entity)
        {
            sendMessageDal.Update(entity);
        }
    }
}
