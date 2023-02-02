using ClassLibrary;

using System.Collections.Generic;
using System.Linq;

namespace WPF.Models
{
	public class DBManager
	{
		private readonly Context uc = new Context();

		public List<Test> GetTests() => uc.Tests.ToList();

		public List<Question> GetQuestions() => uc.Questions.ToList();

		public List<Question> GetQuestionsFromTest(Test test) => test.Questions.ToList();

		public void AddResult(Result result)
		{
			uc.Results.Add(result);
			uc.SaveChanges();
		}
		//
		public List<Student> GetStudents() => uc.Students.ToList();

		public List<Result> GetRes(int id_st) => uc.Results.Where(b => b.StudentId == id_st).Where(res=>res.Comment!=null).ToList();
		public Test GetTests(Result r) => uc.Tests.Where(b => b.Id == r.TestId).FirstOrDefault();
	}
}
