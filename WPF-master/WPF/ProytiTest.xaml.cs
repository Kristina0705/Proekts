using ClassLibrary;

using System.Windows;

using WPF.Models;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для ProytiTest.xaml
	/// </summary>
	public partial class ProytiTest : Window
	{
		readonly int id_st;
		readonly DBManager db;
		public ProytiTest(int autStudent1)
		{
			InitializeComponent();
			id_st = autStudent1;
			db = new DBManager();

			foreach (Test i in db.GetTests())
			{
				ListOfUsers.Items.Add(i);
			}
		}
		private void SamTest(object sender, RoutedEventArgs e)
		{
			SamTest test = new SamTest((Test)ListOfUsers.SelectedItem, id_st, db);
			test.ShowDialog();

		}
		private void Exit(object sender, RoutedEventArgs e) => Close();
	}
}
