using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public  class UserBusiness
    {
        DataAccess.IRepository<User> _repository;
        public UserBusiness()
        {
            _repository = new Repository<User>();
        }

        public ICollection<User> GetAll() 
        {
            try
            {
              return   _repository.GetAll();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public User GetById(string username)
        {
            try
            {
                return _repository.GetById(username);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
