namespace ClassLibrary
{
	public class Pair
	{
		public int Id { get; set; }

		public virtual Result Result { get; set; }

		public virtual Question Question { get; set; }

		public virtual Answer Answer { get; set; }

		public Pair()
		{
		}
	}
}
