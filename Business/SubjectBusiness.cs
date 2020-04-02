using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SubjectBusiness
    {
        DataAccess.IRepository<Domain.Subject> _repository;

        public SubjectBusiness()
        {
            _repository = new Repository<Domain.Subject>();



        }
        public Domain.Subject GetById(int id)
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
            bool success = true;
            try
            {
                Subject entity = _repository.GetById(id);
                string query = String.Format("DELETE FROM [MediclassDB].[dbo].[Student_Subject] WHERE SubjectId = {0}", id);
                 success = _repository.ExecuteQuery(query);
                 if (success)
                 {
                     _repository.Delete(entity);
                 }
                 else
                 {
                     return success;
                 }
               

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return success;
        }

        public bool Save(Subject subject)
        {
            try
            {
                _repository.Add(subject);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }

        public List<Students> GetStudentsBySubject(string subjectId)
        {
            List<Students> studentsList = new List<Students>();
            try
            {
                  string query = String.Format("SELECT st.*  FROM [MediclassDB].[dbo].[Student_Subject] sb, [MediclassDB].[dbo].Students st where sb.StudentId = st.Id and sb.SubjectId = {0}", subjectId);
                  DataSet ds = _repository.Query(query);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      foreach (DataRow row in ds.Tables[0].Rows)
                      {
                          Students student = new Students
                          {
                              Id = int.Parse(row[0] + string.Empty),
                              firstName = row[1] + string.Empty,
                              lastName = row[2] + string.Empty,
                              gender = row[3] + string.Empty,
                              age = int.Parse(row[4] + string.Empty),
                              phoneNumber = row[5] + string.Empty
                          };
                          studentsList.Add(student);
                      }
                  }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return studentsList;
        }

        public bool DeleteStudent(int[] student, int subjectId) 
        {
            try
            {

                foreach (var item in student)
                {
                    string query = String.Format("DELETE FROM [MediclassDB].[dbo].[Student_Subject] WHERE StudentId = {0} AND SubjectId = {1}", item, subjectId);
                    bool success = _repository.ExecuteQuery(query);
                    if (!success)
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }
        public bool AddStudent(int[] student, int subjectId)
        {
            try
            {

                foreach (var item in student)
                {
                    string query = String.Format("insert into [MediclassDB].[dbo].[Student_Subject](StudentId,SubjectId)values({0},{1})", item, subjectId);
                    bool success = _repository.ExecuteQuery(query);
                    if (!success)
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }
        public bool Update(Domain.Subject subject)
        {
            try
            {
                Subject entity = GetById(subject.Id);
                entity.Name = subject.Name;
                entity.year = subject.year;


                _repository.Update(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }
        public ICollection<Subject> GetAll()
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
