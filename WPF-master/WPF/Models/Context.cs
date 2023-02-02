using ClassLibrary;

using System.Data.Entity;

using WPF.Models;

namespace WPF
{
	public class Context : DbContext
	{
		public Context(DbSet<User> users)
		{
			Users = users;
		}

		public Context()
: base("DBConnectionNew")
		{
			Database.SetInitializer<Context>(new ContextInitializer());
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Psychologist> Psychologists { get; set; }

		public DbSet<Student> Students { get; set; }
		public DbSet<Test> Tests { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Result> Results { get; set; }
	}
}
