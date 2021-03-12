using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService

    {
        IUserDal _userDal;
        public UserManager(IUserDal user)
        {
            _userDal = user;
        }
        public List<Users> GetAll()
        {
            return _userDal.GetAll();
        }
        public  void Add(Users user)
        {
            
            _userDal.Add(user);
        }
    }
}
