namespace FluentApiTests.DB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SchoolDbContext : DbContext
    {
        // Your context has been configured to use a 'SchoolDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FluentApiTests.DB.SchoolDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SchoolDbContext' 
        // connection string in the application configuration file.
        public SchoolDbContext()
            : base("name=SchoolDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SchoolDbContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("school");

            modelBuilder.Entity<Student>().HasKey(student => student.IdNumber);
        }
    }

    public partial class Student
    {
        public int IdNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}