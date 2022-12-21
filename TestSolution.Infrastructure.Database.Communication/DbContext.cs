using Acv2.SharedKernel.Infraestructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NPoco;
using NPoco.FluentMappings;
using Oracle.ManagedDataAccess.Client;
using TestSolution.Domain.Models;
using TestSolution.Infrastructure.Database.Communication.Mapping.EF;
using TestSolution.Infrastructure.Database.Communication.Mapping.MNpoco;

namespace TestSolution.Infrastructure.Database.Communication
{
    public class DbContext : SharedDbContext
    {
        public string connection;
        //Para usar entity Framework migration
        public DbSet<Register> register { get; set; }
        public DbContext(IConfiguration config, DataBaseConfiguration dataBaseConfiguration, DbContextOptions<SharedDbContext> options) : base(config, dataBaseConfiguration, options)
        {
            //Mapping de NPoco
            var _nconfig = FluentMappingConfiguration.Configure(new RegisterMapping());

            connection = _config.GetConnectionString("Desarrollo");

            //SQL Server
            SetDbFactory(connection, DatabaseType.SqlServer2012, SqlClientFactory.Instance, _nconfig);

            //Oracle
            //SetDbFactory(connection, DatabaseType.SqlServer2012, OracleClientFactory.Instance, _nconfig);

            //Postgre
            //SetDbFactory(connection, DatabaseType.SqlServer2012, Npgsql.NpgsqlFactory.Instance, _nconfig);

            //MySql
            //SetDbFactory(connection, DatabaseType.SqlServer2012, MySql.Data.MySqlClient.MySqlClientFactory.Instance, _nconfig);
        }
        public IDatabase Instance { get { return this.IntanceDataBaseSql; } }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Framework
            base.OnModelCreating(modelBuilder);
            //Para manejar el esquema en caso de ser necesario para algun tipo de base de datos
            //modelBuilder.HasDefaultSchema("Test");

            modelBuilder.ApplyConfiguration(new RegisterMappingEF());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection = _config.GetConnectionString("Produccion");
            connection = _config.GetConnectionString("Desarrollo");

            //SQL Server
            optionsBuilder.SetDataBaseConfiguration(connection, Acv2.SharedKernel.Infraestructure.Enums.DataBaseTypeConfiguration.SQLSERVER);

            //PostgreSQL
            //optionsBuilder.SetDataBaseConfiguration(connection, Acv2.SharedKernel.Infraestructure.Enums.DataBaseTypeConfiguration.POSTGRESQL);

            //Oracle
            //optionsBuilder.SetDataBaseConfiguration(connection, Acv2.SharedKernel.Infraestructure.Enums.DataBaseTypeConfiguration.ORACLE);

            //MySql
            //optionsBuilder.SetDataBaseConfiguration(connection, Acv2.SharedKernel.Infraestructure.Enums.DataBaseTypeConfiguration.MYSQL);
        }
    }
}
