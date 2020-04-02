using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StudentBusiness
    {
        DataAccess.IRepository<Domain.Students> _repository;
        public StudentBusiness()
        {
            _repository = new Repository<Students>();
        }

        public Domain.Students GetById(int id) 
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
           
        }
        public bool Delete(int id) 
        {
            try
            {
                Students entity = _repository.GetById(id);
                _repository.Delete(entity);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool Save(Students students)
        {
            try
            {
                _repository.Add(students);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }
        public bool Update(Students students)
        {
            try
            {
                Students entity = GetById(students.Id);
                entity.firstName = students.firstName;
                entity.lastName = students.lastName;
                entity.gender = students.gender;
                entity.age = students.age;
                entity.phoneNumber = students.phoneNumber;

                _repository.Update(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }
        public ICollection<Students> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
