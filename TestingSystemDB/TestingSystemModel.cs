namespace TestingSystemDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class TestingSystemModel : DbContext
    {
        public TestingSystemModel()
            : base("name=TestingSystemModel")
        {
        }

        public  DbSet<Discipline> Disciplines { get; set; }
        public  DbSet<Question> Questions { get; set; }
        public  DbSet<Test> Tests { get; set; }
        public  DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Discipline>()
                .HasMany(e => e.questions)
                .WithRequired(e => e.discipline)
                .HasForeignKey(e => e.discipline_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.question_text)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.questions)
                .WithMany(e => e.tests)
                .Map(m => m.ToTable("test_questions", "testing_system"));

            modelBuilder.Entity<User>()
                .Property(e => e.nickname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.tests)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
