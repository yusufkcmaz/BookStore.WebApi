using BookStore.BusinessLayer.Abstract;
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
        private readonly IWriterService _writerService;

        public WriterManager(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public void TAdd(Writer entity)
        {
            _writerService.TAdd(entity);
        }

        public void TDelete(int id)
        {
            _writerService.TDelete(id);
        }

        public List<Writer> TGetAll()
        {
            return _writerService.TGetAll();    
        }

        public Writer TGetById(int id)
        {
            return _writerService.TGetById(id);
        }

        public void TUpdate(Writer entity)
        {
            return _writerService.TUpdate(entity);
        }
    }
}
