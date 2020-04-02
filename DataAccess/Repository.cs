using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public partial class Repository<T> : IRepository<T> where T : class
    {
        DBEntities context;
        DbSet<T> _dbSet;
        public Repository()
        {
            context = new DBEntities();
            _dbSet = context.Set<T>();

        }

        public DataSet Query(string query)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"];
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {
                SqlCommand command = new SqlCommand(query, conn);
                //adp to fetch data
                SqlDataAdapter adp = new SqlDataAdapter(command);

                //table to hold data
                DataSet ds = new DataSet();

                adp.Fill(ds);
                return ds;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        public bool ExecuteQuery(string query)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"];
            SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction trans = null;
            bool result = false;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                
                  
                SqlCommand command = new SqlCommand(query, conn);
                command.Transaction = trans;
                result = command.ExecuteNonQuery() >= 0;
               


                if (result == false)
                {
                    trans.Rollback();
                }
                trans.Commit();
                return result;


            }
            catch (Exception ex)
            {

                trans.Rollback();
                throw ex;
            }
            finally
            {
                
                conn.Close();
            }

        }

        public ICollection<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public T GetById(object Id)
        {

            try
            {
                return _dbSet.Find(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Update(T entity)
        {
            try
            {

                context.Entry(entity).State = EntityState.Modified;
                context.ChangeTracker.DetectChanges();
                var tt = context.ChangeTracker.HasChanges();
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
