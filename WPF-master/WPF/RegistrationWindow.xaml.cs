using System.Windows;

using WPF.Models;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для RegistrationWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
		}

		private void RegistationButton_Click(object sender, RoutedEventArgs e)
		{
			if (loginTextBox.Text == "" || passwordTextBox.Text == "" || imyaTextBox.Text == "" || familiyaTextBox.Text == "" || otchestvoTextBox.Text == "")
			{
				MessageBox.Show("Введены не все данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			using (Context context = new Context())
			{
				Student student = new Student() { Login = loginTextBox.Text, Password = passwordTextBox.Text, Name = imyaTextBox.Text, Familiya = familiyaTextBox.Text };
				context.Students.Add(student);
				context.SaveChanges();
			}
			MessageBox.Show("Данные сохранены.", "Успешно");
		}
	}
}
