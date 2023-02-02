namespace WPF.Models
{
	public class Student : User
	{
		public string Name { get; set; }

		public string Familiya { get; set; }

		public string DateOfBeth { get; set; }
		public string Email { get; set; }

		public string DisplayName => Name + " " + Familiya;
	}
}
