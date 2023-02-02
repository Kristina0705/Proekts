using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ClassLibrary;

namespace WPF
{
	/// <summary>
	/// Логика взаимодействия для AddComment.xaml
	/// </summary>
	public partial class AddComment : Window
	{
		private readonly Result result;
		public AddComment(Result result)
		{
			InitializeComponent();
			this.result = result;
			Pairs.ItemsSource = result.Pairs;
			score.Text = result.Pairs.Sum(p => p.Answer.Ball).ToString();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (comment.Text.Trim().Length==0)
			{
				MessageBox.Show("Комментарий не может быть пустым");
				return;
			}
			result.Comment = comment.Text.Trim();
			Close();
		}
	}
}
