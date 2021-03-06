﻿using System;
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
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly string _tableName;
        private readonly DatabaseHelper _databaseHelper;

        public GenericRepositoryAsync(string tableName)
        {
            _tableName = tableName;
            _databaseHelper = new DatabaseHelper(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        /// <summary>
        /// Get a IEnumerable list of type T where T can be any class on the MainDbContext (a database table)
        /// </summary>
        /// <returns>IEnumerable list of type T</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    return await db.QueryAsync<T>("select *from " + _tableName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get a single object of type T where T can be any class on the MainDbContext (a database table)
        /// </summary>
        /// <returns>single object of type T</returns>
        public async Task<T> GetById(int id)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    return await db.QueryFirstAsync<T>("select * from " + _tableName + " where id = @id", new { id = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert a object type of T 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Scope Identity of the inserted record</returns>
        public async Task<int> Insert(T obj)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    long ret = await db.InsertAsync<T>(obj);
                    return Convert.ToInt32(ret.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update a given T type of object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>boolean type contain whether the record updated or not</returns>
        public async Task<bool> Update(T obj)
        {

            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    return await db.UpdateAsync<T>(obj);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete a record using primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>boolean type contain whether the record deleted or not</returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {

                    var result = await db.ExecuteAsync("delete from customers where id = " + id.ToString());
                    if (result == 1)
                    {
                        return true;
                    }
                    else {
                        return false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
