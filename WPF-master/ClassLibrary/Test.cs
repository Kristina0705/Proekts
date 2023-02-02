using System.Collections.Generic;

namespace ClassLibrary
{
	public class Test
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Opisanie { get; set; }
		public int Tip { get; set; }

		public virtual ICollection<Question> Questions { get; set; }
		public List<Result> Results { get; set; }

		public Test()
		{
			//
			Questions = new List<Question>();
		}
		public override string ToString() => Name;
	}
}
