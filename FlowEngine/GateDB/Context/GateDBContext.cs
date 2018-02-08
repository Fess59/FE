using FessooFramework.Tools.Helpers;
using GateDB.Models;
using GateDB.Models.FlowInstances;
using GateDB.Models.FlowInstancesParameters;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace GateDB.Context
{
    #region Configuration
    //Add-migration DB_1 -ConfigurationTypeName GateDB.Context.ConfigurationDefaultDB
    // Update-database
    internal sealed class ConfigurationDefaultDB : DbMigrationsConfiguration<GateDBContext>
    {
        public ConfigurationDefaultDB() { AutomaticMigrationsEnabled = true; }
        protected override void Seed(GateDBContext context) { }
    }
    #endregion
    #region Context

    /// <summary>   A gate database context. </summary>
    ///
    /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>

    public class GateDBContext : DbContext
    {
        /// <summary>   Gets or sets the flow instances. </summary>
        ///
        /// <value> The flow instances. </value>

        public DbSet<FlowInstance> FlowInstances { get; set; }

        /// <summary>   Gets or sets options for controlling the flow instance. 
        ///             Параметры для выполенения работ над объектом и шагом текущего потока</summary>
        ///
        /// <value> Options that control the flow instance. </value>

        public DbSet<FlowInstanceParameters> FlowInstanceParameters { get; set; }

        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>

        public GateDBContext()
        {
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = true;
            base.Database.Connection.ConnectionString = EntityHelper.CreateRemoteSQL("GateDB", "192.168.26.116", @"ExtUser", "123QWEasd");
        }

        /// <summary>
        ///     This method is called when the model for a derived context has been initialized, but
        ///     before the model has been locked down and used to initialize the context.  The default
        ///     implementation of this method does nothing, but it can be overridden in a derived class
        ///     such that the model can be further configured before it is locked down.
        /// </summary>
        ///
        /// <remarks>
        ///     Typically, this method is called only once when the first instance of a derived context
        ///     is created.  The model for that context is then cached and is for all further instances
        ///     of the context in the app domain.  This caching can be disabled by setting the
        ///     ModelCaching property on the given ModelBuidler, but note that this can seriously degrade
        ///     performance. More control over caching is provided through use of the DbModelBuilder and
        ///     DbContextFactory classes directly.
        /// </remarks>
        ///
        /// <param name="modelBuilder"> The builder that defines the model for the context being created. </param>

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        /// <summary>
        ///     Disposes the context. The underlying
        ///     <see cref="T:System.Data.Entity.Core.Objects.ObjectContext" /> is also disposed if it was
        ///     created is by this context or ownership was passed to this context when this context was
        ///     created. The connection to the database (<see cref="T:System.Data.Common.DbConnection" />
        ///     object) is also disposed if it was created is by this context or ownership was passed to
        ///     this context when this context was created.
        /// </summary>
        ///
        /// <remarks>   AM Kozhevnikov, 01.02.2018. </remarks>
        ///
        /// <param name="disposing">    <c>true</c> to release both managed and unmanaged resources;
        ///                             <c>false</c> to release only unmanaged resources. </param>

        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }
    }
    #endregion
}
