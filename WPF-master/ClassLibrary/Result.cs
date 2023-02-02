using System;
using System.Collections.Generic;

using WPF.Models;

namespace ClassLibrary
{
	public class Result
	{

		public int Id { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
		//Навигационное свойство
		public int TestId { get; set; }
		public Test Test { get; set; }

		public string Comment { get; set; }

		public Result()
		{
			Pairs = new List<Pair>();
		}

		public virtual ICollection<Pair> Pairs { get; set; }
		public override string ToString() => TestId.ToString();
	}
}
