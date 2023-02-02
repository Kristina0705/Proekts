using System.Windows;

using System.Linq;

using ClassLibrary;
using System.Collections.Generic;
using WPF.Models;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для Kabinet.xaml
	/// </summary>
	public partial class Kabinet : Window
	{
		private readonly Context db = new Context();
		public Kabinet()
		{
			InitializeComponent();
			Update();
		}
		private void Exit(object sender, RoutedEventArgs e) => Close();
		private void CreateTest(object sender, RoutedEventArgs e)
		{
			CreateTest createTest = new CreateTest();
			createTest.ShowDialog();
			UpdateTestsList();
		}

		private void Update()
		{
			UpdateTestsList();
			UpdatePassedTestsList();
		}

		private void UpdateTestsList()
		{
			Tests.ItemsSource = db.Tests.ToList();
			Tests.Items.Refresh();
		}

		private void UpdatePassedTestsList()
		{
			List<Student> students = db.Students.ToList();
			List<Result> results = db.Results.Where(res => res.Comment == null).ToList();
			foreach (var r in results)
			{
				r.Student = students.FirstOrDefault(s => s.Id == r.StudentId);
			}
			PassedTests.ItemsSource = results;
			PassedTests.Items.Refresh();
		}

		private void PassedTests_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			
			if(PassedTests.SelectedItem != null)
			{
				Result result = (Result)PassedTests.SelectedItem;
				AddComment addComment = new AddComment(result);
				addComment.ShowDialog();
				db.SaveChanges();
			}
			UpdatePassedTestsList();
		}
	}
}
