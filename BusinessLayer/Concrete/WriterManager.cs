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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TAdd(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _writerDal.Delete(id);  
        }

        public List<Writer> TGetAll()
        {
            return _writerDal.GetAll(); 
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public void TUpdate(Writer entity)
        {
           _writerDal.Update(entity);
        }
    }
}
