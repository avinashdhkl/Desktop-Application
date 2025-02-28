using DataAccessSqlLite.SqlLite;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;
using System.Data;
using WinFormsBusiness.Services.Customer;
using WinFormsBusiness.Services.Location;
using Serilog.Sinks.SQLite;
using System.Data.SQLite;
using WinFormsCommon.ApiServices;
using WinFormsBusiness.Services.Dashoard;


namespace WinFormsCustom
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new List<SqlColumn>
                {
                    new SqlColumn { ColumnName = "UnqiueNo",  DataType = SqlDbType.NVarChar },
                    new SqlColumn { ColumnName = "Method", DataType = SqlDbType.NVarChar },
                    new SqlColumn { ColumnName = "Action", DataType = SqlDbType.NVarChar },
                    new SqlColumn { ColumnName = "DB", DataType = SqlDbType.NVarChar },
                    new SqlColumn { ColumnName = "Messages", DataType = SqlDbType.NVarChar },
                    new SqlColumn { ColumnName = "Param", DataType = SqlDbType.NVarChar },
                    new SqlColumn { ColumnName = "Response", DataType = SqlDbType.NVarChar },

                }
            };


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()              
                .WriteTo.MSSqlServer(
                connectionString: ConfigurationManager.ConnectionStrings["Logconnectionstring"]?.ConnectionString,
                schemaName: "Logs",
                tableName: "Tbl_Logs",
                autoCreateSqlTable: true,
                columnOptions: columnOptions
                )                         
                .CreateLogger();
            ApplicationConfiguration.Initialize();
            var service = new ServiceCollection()
                .AddSingleton<ICustomerServices, CustomerServices>()
                .AddSingleton<ILocationService, LocationService>()
                .AddSingleton<ISqlLiteDataAccess, SqlLiteDataAccess>()
                .AddSingleton<IApiServices, ApiServices>()
                .AddSingleton<IDashboardServices, DashoardServices>()
                .BuildServiceProvider();
            Application.Run(new Dashoard(service.GetService<IDashboardServices>(), service.GetService<ICustomerServices>(), service.GetService<ILocationService>()));
           

        }
    }
}