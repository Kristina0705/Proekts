using System.Collections.Generic;
using System.Linq;
using System.Windows;

using WPF.Models;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для Lichny_kabinet.xaml
	/// </summary>
	public partial class Lichny_kabinet : Window
	{
		readonly DBManager db;
		public Lichny_kabinet()
		{
			db = new DBManager();
			InitializeComponent();

			//Вывод приветствия
			string user = (string)App.Current.Resources["User"];
			Student autStudent1 = null;
			using (Context db1 = new Context())
			{
				//Обращение к базе данных, поиск нужной строки
				//Обращение к методу, которые вернет либо найденную строчку либо значение по умолчанию
				autStudent1 = db1.Students.Where(b => b.Login == user)
						.FirstOrDefault();
			}
			User1.Content = "Здравствуйте, " + autStudent1.Name;
			//Вывод названий тестов, которые прошёл пользователь
			List<ClassLibrary.Result> results = db.GetRes(autStudent1.Id);
			foreach (var r in results)
			{
				r.Test = db.GetTests(r);
			}
			ListOfUsers.ItemsSource = results;
		}
		private void ProytiTest(object sender, RoutedEventArgs e)
		{
			Context db1 = new Context();
			//Получение данных в лист из БД
			List<Student> students = db1.Students.ToList();

			string user = (string)App.Current.Resources["User"];
			Student autStudent1 = null;
			autStudent1 = db1.Students.Where(b => b.Login == user)
					.FirstOrDefault();

			ProytiTest proytiTest = new ProytiTest(autStudent1.Id);
			proytiTest.ShowDialog();
		}
		private void Exit(object sender, RoutedEventArgs e) => Close();
	}
}
