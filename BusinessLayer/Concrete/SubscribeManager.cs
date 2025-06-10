using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService 
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void TAdd(Subscribe entity)
        {
           
            _subscribeDal.Add(entity);  
        }

        public void TDelete(int id)
        {
            _subscribeDal.Delete(id);
        }

        public List<Subscribe> TGetAll()
        {
            return _subscribeDal.GetAll();
        }

        public Subscribe TGetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public void TUpdate(Subscribe entity)
        {
           _subscribeDal.Update(entity);
        }
    }
}
