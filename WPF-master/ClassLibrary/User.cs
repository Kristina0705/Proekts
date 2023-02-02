namespace WPF.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

		public bool IsStudent => this is Student;
	}
}
