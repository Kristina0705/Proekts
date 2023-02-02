using System.Windows;
using System.Windows.Media;

using WPF.Models;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		public string Login { get; private set; }

		public Registration()
		{
			InitializeComponent();
		}
		private void Button_Click_Reg(object sender, RoutedEventArgs e)
		{
			string login = Text_login.Text;
			string password = Text_password.Password;
			//Проверка на правильность ввода
			if (login.Length < 5 || login.Length > 10)
			{
				//Подсказка при наведении мышкой на объект
				Text_login.ToolTip = "Логин должен представлять последовательность от 5 до 10 символов";
				Text_login.BorderBrush = Brushes.Red;
				return;
			}
			if (password.Length < 5 || password.Length > 10)
			{
				Text_password.ToolTip = "Пароль должен представлять последовательность от 5 до 10 символов";
				Text_password.BorderBrush = Brushes.Red;
				return;
			}
			if (!Text_email.Text.Contains("@"))
			{
				Text_email.ToolTip = "Адрес электронной почты должен содержать @";
				Text_email.BorderBrush = Brushes.Red;
				return;
			}
			//На случай, если заполнено все верно, прозрачный фон у всех полей
			Text_login.ToolTip = "";
			Text_login.BorderBrush = Brushes.Black;
			Text_name.ToolTip = "";
			Text_name.BorderBrush = Brushes.Black;
			Text_password.ToolTip = "";
			Text_password.BorderBrush = Brushes.Black;

			//Сам процесс регистрации
			using (Context db = new Context())
			{
				Student students = new Student() { Name = Text_name.Text, Familiya = Text_familia.Text, Login = Text_login.Text, Password = Text_password.Password, DateOfBeth = datePicker1.Text, Email = Text_email.Text.Trim() };
				db.Students.Add(students);
				db.SaveChanges();
			}
			Login = login;
			Close();
			//Всплывающее окно
			MessageBox.Show("Регистрация прошла успешно");
		}
		private void Exit(object sender, RoutedEventArgs e)
		{
			Login = null;
			Close();
		}
	}
}
