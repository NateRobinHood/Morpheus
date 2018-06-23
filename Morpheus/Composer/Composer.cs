using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composer.DataModel;

//Entity Framework
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Composer
{
    public class ComposerEngine : DbContext, IDataAccess
    {
        //Connection string information goes into the StartUp Project's(Morpheus) app.config

        public ComposerEngine()
            : base("name=TestingDatabase") //name= is very important, it makes entity framework look in app.config for a connection string
        {

        }

        //DB Sets
        public DbSet<RequestRecord> RequestRecords { get; set; }

        //Private Methods
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = "Composer";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).UserCreated = currentUsername;
                }

                ((BaseEntity)entity.Entity).DateModified = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).UserModified = currentUsername;
            }
        }

        //DbContext Overrides
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        public void AddRequestRecord(RequestRecord requestRecord)
        {
            throw new NotImplementedException();
        }
    }
}
