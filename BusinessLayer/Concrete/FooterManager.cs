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
    public class FooterManager : IFooterService
    {
        private readonly IFooterDal _footerDal;

        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

        public void TAdd(Footer entity)
        {
             _footerDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _footerDal.Delete(id);
        }

        public List<Footer> TGetAll()
        {
            return _footerDal.GetAll();
        }

        public Footer TGetById(int id)
        {
            return _footerDal.GetById(id);
        }

        public void TUpdate(Footer entity)
        {
            _footerDal.Update(entity);
        }
    }
}
