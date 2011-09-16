using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace BigApp.Domain.Concrete
{
    public class BigAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<BigApp.Domain.Concrete.BigAppContext>());
        public BigAppContext() {
         
        }
        public DbSet<BigApp.Domain.Entities.Tag> Tags { get; set; }
        public DbSet<BigApp.Domain.Entities.Group> Groups { get; set; }

        public DbSet<BigApp.Domain.Entities.Project> Projects { get; set; }

        

        public DbSet<BigApp.Domain.Entities.Attachment> Attachments { get; set; }
    }
}