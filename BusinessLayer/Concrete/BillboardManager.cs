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
    public class BillboardManager : IBillboardService
    {
        private readonly IBillboardDal _billboardDal;

        public BillboardManager(IBillboardDal billboardDal)
        {
            _billboardDal = billboardDal;
        }

        public void TAdd(Billboard entity)
        {
            _billboardDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _billboardDal.Delete(id);
        }

        public List<Billboard> TGetAll()
        {
            
            return _billboardDal.GetAll();
        }

        public Billboard TGetById(int id)
        {
           return  _billboardDal.GetById(id);
        }

        public void TUpdate(Billboard entity)
        {
            _billboardDal.Update(entity);
        }
    }
}
