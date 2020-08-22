
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace CRUDTest.Models
{
    public class CRUDdbContext : DbContext
    {
        public CRUDdbContext()
            : base("name=DbConnectionString")
        {
        }
        public DbSet<CRUDModel> CRUDModels { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CRUDModel>().HasKey(t => t.CrudId); //primary key defination  
            modelBuilder.Entity<CRUDModel>().Property(t => t.CrudId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);  //identity col            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}