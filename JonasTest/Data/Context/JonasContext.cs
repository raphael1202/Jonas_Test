using Data.Entities;
using System.Data.Entity;

namespace Data.Context
{
    public class JonasContext : DbContext
    {
        public JonasContext()
            : base("name=CnnTest")
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<MultipleChoice> MultipleChoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("Questions");

            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);

            modelBuilder.Entity<Question>()
                .Property(q => q.Text)
                .IsRequired();

            modelBuilder.Entity<Question>()
                .Property(q => q.Type)
                .IsRequired();

            

            modelBuilder.Entity<MultipleChoice>().ToTable("MultipleChoices");

            modelBuilder.Entity<MultipleChoice>()
                .HasKey(q => q.Id);

            modelBuilder.Entity<MultipleChoice>()
                .Property(q => q.Text)
                .IsRequired();

            modelBuilder.Entity<MultipleChoice>()
               .HasRequired(q => q.Question);
        }
    }
}