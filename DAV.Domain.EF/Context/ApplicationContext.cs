using DAV.Domain.EF.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAV.Domain.EF.Context
{
    public class ApplicationContext : DbContext
    {
        #region Constructors

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            InstanceId = Guid.NewGuid();
        }

        internal ApplicationContext(DbContextOptions options) : base(options)
        {
            InstanceId = Guid.NewGuid();
        }


        public ApplicationContext() : base()
        {
            InstanceId = Guid.NewGuid();
        }

        #endregion

        #region Properties

        public Guid InstanceId { get; private set; }

        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MappingRegistry.Configure(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        

        #endregion

    }
}
