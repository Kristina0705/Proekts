using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

using WPF.Models;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void Registr(object sender, RoutedEventArgs e)
		{
			//Открытие формы регистрации
			Registration registration = new Registration();
			Hide();//Прячем 
			registration.ShowDialog();//Дожидаемя результата
			string login = registration.Login;
			if (login != null)
			{
				Login.Text = login;
			}
			Show();//Показываем
		}
		private void TryLogin(object sender, RoutedEventArgs e)
		{
			string login = Login.Text.Trim();
			string password = Text_password.Password.Trim();
			Text_password.Password = "";
			//Проверка на правильность ввода
			if ((login.Length < 5) || (login.Length > 10))
			{
				//Подсказка при наведении мышкой на объект
				Login.ToolTip = "Логин должен представлять последовательность от 5 до 10 символов";
				Login.BorderBrush = Brushes.Red;
				return;
			}
			if ((password.Length < 5) || (password.Length > 10))
			{
				Text_password.ToolTip = "Пароль должен представлять последовательность от 5 до 10 символов";
				Text_password.BorderBrush = Brushes.Red;
				return;
			}
			//На случай, если заполнено все верно, прозрачный фон у всех полей
			Login.ToolTip = "";
			Login.BorderBrush = Brushes.Black;
			Text_password.ToolTip = "";
			Text_password.BorderBrush = Brushes.Black;
			//Процесс авторизации
			//Student autStudent = null;
			User user = null;
			using (Context db1 = new Context())
			{
				//Обращение к базе данных, поиск нужной строки
				//Обращение к методу, которые вернет либо найденную строчку либо значение по умолчанию
				//autStudent = db1.Students.Where(b=>b.Login_student==login&&b.Password_student==password)
				//    .FirstOrDefault();
				try
				{
					user = db1.Users.Where(b => b.Login == login && b.Password == password)
						.FirstOrDefault();
				}
				catch (Exception)
				{
					MessageBox.Show("Не удаёться подключиться к базе данных");
					return;
				}
			}
			password = null;
			//Смогли ли найти пользователя? Проверка
			if (user == null)
			{
				MessageBox.Show("Такого пользователя не существует");
				return;
			}
			Hide();
			App.Current.Resources["User"] = user.Login;
			Window window = user.IsStudent ? (Window)new Lichny_kabinet() : new Kabinet();
			window.ShowDialog();
			Show();
		}
	}
}
