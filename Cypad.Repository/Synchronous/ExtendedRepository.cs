using Cypad.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Cypad.Repository
{
    public abstract class ExtendedRepository<T> where T : class
    {
        private readonly string _tableName;
        private readonly DatabaseHelper _databaseHelper;

        public ExtendedRepository(string tableName)
        {
            _tableName = tableName;
            _databaseHelper = new DatabaseHelper(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        /// <summary>
        /// Get the List of passing type (T) using a stored procedure
        /// </summary>
        /// <param name="SpName">Stored Procedure to call to get list of object</param>
        /// <returns>Single object of type T</returns>
        public IEnumerable<T> GetListOfObjectsFromStrodProcedure(string SpName)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    return db.Query<T>(SpName,commandType:System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get an object of passing type (T)  using a stored procedure
        /// </summary>
        /// <param name="SpName">Stored Procedure to call to get an object</param>
        /// <returns>Single object of type T</returns>
        public T GetSingleObjectFromStrodProcedure(string SpName)
        {
            try
            {
                using (var db = _databaseHelper.GetDataBaseConnection())
                {
                    return db.QueryFirst<T>(SpName, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }

        /// <summary>
        /// Save T type of object using stored procedure . this must be implemented on the child class. can be used to save or update the record according to the action
        /// </summary>
        /// <param name="SpName">Stored Procedure to call to save T object</param>
        /// <param name="objtoSave">any type of object to save</param>
        /// <returns>Newly saved records primary key</returns>
        public abstract int SaveUsingStrodProcedure(string SpName, Object objtoSave);
       

    }
}
