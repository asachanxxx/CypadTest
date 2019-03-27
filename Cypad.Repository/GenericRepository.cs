using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cypad.Helper;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Cypad.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class 
    {
        private readonly string _tableName;
        private readonly DatabaseHelper _databaseHelper;

        public GenericRepository(string tableName)
        {
            _tableName = tableName;
            _databaseHelper = new DatabaseHelper(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    return db.Query<T>("select *from " + _tableName);
                }
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        public T GetById(int id)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    return db.QueryFirst<T>("select *from " + _tableName + "where id = @id" , new { id  = id});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(T obj)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    db.Insert<T>(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T obj)
        {

            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    db.Update<T>(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    db.Delete<T>(GetById(id));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
