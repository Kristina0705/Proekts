using System.Collections.Generic;

namespace ClassLibrary
{
	public class Answer
	{

		public int Id { get; set; }

		public string Title { get; set; }
		//Навигационное свойство
		public virtual ICollection<Pair> Pairs { get; set; }
		public int QuestionId { get; set; }
		public int Ball { get; set; }
		public virtual Question Question { get; set; }
		public Answer()
		{
			Pairs = new List<Pair>();
		}
	}
}
