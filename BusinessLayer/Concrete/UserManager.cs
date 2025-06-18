using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class UserManager: IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TAdd(AppUser entity)
        {
           _userDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _userDal.Delete(id);
        }

        public List<AppUser> TGetAll()
        {
            return _userDal.GetAll();
        }

        public AppUser TGetById(int id)
        {
           return _userDal.GetById(id);
        }

        public void TUpdate(AppUser entity)
        {
            
            _userDal.Update(entity);    
        }
    }
}
