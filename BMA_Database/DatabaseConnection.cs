using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using BMA_Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace BMA_Database
{
    public class DatabaseConnection
    {
        #region Private Properties
        private DatabaseConnection() { }

        private static DatabaseConnection Instance;

        /// <summary>
        /// Open the connection to the database when needed only.
        /// This will keep the connection on and have to close it manually.
        /// </summary>
        public static DatabaseConnection openDatabaseConnection()
        {
            if (Instance == null) Instance = new DatabaseConnection();
            return Instance;
        }
        #endregion

        #region Multiple Connection Strings
        /// <summary>
        /// List of database names 
        /// </summary>
        private static readonly string BMAConnectionString = "BMAConnectionString";
        private static readonly string UserConnectionString = "UserConnectionString";
        #endregion

        private static string getConnectionString(string connectionStringName)
        {
            var appSettingsJson = ConnectionStringProvider.GetAppSettings();
            string connectionString = appSettingsJson[connectionStringName];
            return connectionString;
        }

        #region Database Connection Methods

        #region Acccount

        public static void insertAccount(Account theAccount)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Account_Insert";
                    var parameters = new DynamicParameters();
                    parameters.Add("@username", theAccount?.username);
                    parameters.Add("@password", theAccount?.password);
                    parameters.Add("@account_type", theAccount?.account_type);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void deleteAccount(Account theAccount)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Account_Delete";
                    var parameters = new DynamicParameters();
                    parameters.Add("@username", theAccount?.username);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void updateAccount(Account theAccount)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Account_Update";
                    var parameters = new DynamicParameters();
                    parameters.Add("@username", theAccount?.username);
                    parameters.Add("@password", theAccount?.password);
                    parameters.Add("@account_type", theAccount?.account_type);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static Account retrieveByKeyAccount(string theUserName)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Account_RetrieveByKey";
                    var parameters = new DynamicParameters();
                    parameters.Add("@username", theUserName);
                    var data = connection.Query<Account>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                    if (data.Count != 1) throw (new Exception("Data Retireve Error!!! retrieveByKeyAccount"));
                    return data[0];
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion

        #region Order

        public static void insertOrder(Order theOrder)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Order_Insert";
                    var parameters = new DynamicParameters();
                    parameters.Add("@date", theOrder?.date);
                    parameters.Add("@order_number", theOrder?.order_number);
                    parameters.Add("@order_type", theOrder?.order_type);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void deleteOrder(Order theOrder)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Order_Delete";
                    var parameters = new DynamicParameters();
                    parameters.Add("@date", theOrder?.date);
                    parameters.Add("@order_number", theOrder?.order_number);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void updateOrder(Order theOrder)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Order_Update";
                    var parameters = new DynamicParameters();
                    parameters.Add("@date", theOrder?.date);
                    parameters.Add("@order_number", theOrder?.order_number);
                    parameters.Add("@order_type", theOrder?.order_type);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static Order retrieveByKeyOrder(DateTime theDate, int theOrder_number)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Order_RetrieveByKey";
                    var parameters = new DynamicParameters();
                    parameters.Add("@date", theDate);
                    parameters.Add("@order_number", theOrder_number);
                    var data = connection.Query<Order>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                    if (data.Count != 1) throw (new Exception("Data Retireve Error!!! retrieveByKeyOrder"));
                    return data[0];
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion

        #region Inventory

        public static void insertInventory(Inventory theInventory)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Inventory_Insert";
                    var parameters = new DynamicParameters();
                    parameters.Add("@item_name", theInventory?.item_name);
                    parameters.Add("@amount", theInventory?.amount);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void deleteInventory(Inventory theInventory)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Inventory_Delete";
                    var parameters = new DynamicParameters();
                    parameters.Add("@item_name", theInventory?.item_name);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void updateInventory(Inventory theInventory)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Inventory_Update";
                    var parameters = new DynamicParameters();
                    parameters.Add("@item_name", theInventory?.item_name);
                    parameters.Add("@amount", theInventory?.amount);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static Inventory retrieveByKeyInventory(string theItem_name)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Inventory_RetrieveByKey";
                    var parameters = new DynamicParameters();
                    parameters.Add("@item_name", theItem_name);
                    var data = connection.Query<Inventory>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                    if (data.Count != 1) throw (new Exception("Data Retireve Error!!! retrieveByKeyInventory"));
                    return data[0];
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion

        #region Menu

        public static void insertMenu(Menu theMenu)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Menu_Insert";
                    var parameters = new DynamicParameters();
                    parameters.Add("@number", theMenu?.id);
                    parameters.Add("@amount", theMenu?.name);
                    parameters.Add("@price", theMenu?.price);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void deleteMenu(Menu theMenu)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Menu_delete";
                    var parameters = new DynamicParameters();
                    parameters.Add("@number", theMenu?.id);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void updateMenu(Menu theMenu)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Menu_update";
                    var parameters = new DynamicParameters();
                    parameters.Add("@number", theMenu?.id);
                    parameters.Add("@amount", theMenu?.name);
                    parameters.Add("@price", theMenu?.price);
                    connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static Menu retrieveByKeyMenu(int menu_id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(getConnectionString(BMAConnectionString)))
                {
                    string sql = "sp_Inventory_RetrieveByKey";
                    var parameters = new DynamicParameters();
                    parameters.Add("@number", menu_id);
                    var data = connection.Query<Menu>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                    if (data.Count != 1) throw (new Exception("Data Retireve Error!!! retrieveByKeyMenu"));
                    return data[0];
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion

        #endregion
    }
}