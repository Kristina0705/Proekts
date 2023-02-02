using System.Collections.Generic;

namespace ClassLibrary
{
	public class Question
	{
		public int Id { get; set; }

		public string Vopros { get; set; }

		public int TestId { get; set; }
		public Test Test { get; set; }

		public virtual ICollection<Answer> Answers { get; set; }
		public virtual ICollection<Pair> Pairs { get; set; }

		public Question()
		{
			Answers = new List<Answer>();
			Pairs = new List<Pair>();
		}

		public override string ToString() => Vopros;
	}
}
