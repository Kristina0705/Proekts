using System.Data.Entity;

using WPF.Models;

namespace WPF
{
	public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
	{
		protected override void Seed(Context context)
		{
			Psychologist psychologist = new Psychologist() { Login = "11111", Password = "11111" };
			context.Psychologists.Add(psychologist);
			context.SaveChanges();

			//Test test = new Test() { Id = 3, Name = "Астения Малковой 2", Tip = 2 };
			//context.Tests.Add(test);
			//context.SaveChanges();

			//Question vopros = new Question() { };
			//context.Questions.Add(vopros);
			//context.SaveChanges();
		}
	}
}
