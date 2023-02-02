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
	/// Логика взаимодействия для CreateTest.xaml
	/// </summary>
	public partial class CreateTest : Window
	{
		private readonly Test test = new Test();
		public CreateTest()
		{
			InitializeComponent();
			dataGrid.ItemsSource = test.Questions;
		}

		private void CreateQuestionHamdler(object sender, EventArgs eventArgs)
		{
			CreateQuestion createQuestion = new CreateQuestion();
			createQuestion.ShowDialog();
			if (createQuestion.Question != null)
			{
				test.Questions.Add(createQuestion.Question);
				createQuestion.Question.Test = test;
				dataGrid.Items.Refresh();
			}
		}

		private void SaveHandler(object sender, EventArgs eventArgs)
		{
			if (test.Questions.Count == 0)
			{
				MessageBox.Show("В тесте должен быть хотя бы один вопрос");
				return;
			}
			if(testName.Text.Trim().Length == 0)
			{
				MessageBox.Show("Введите название теста");
				return;
			}
			test.Name = testName.Text.Trim();
			test.Opisanie = testDesc.Text.Trim();
			using (Context db = new Context())
			{
				try
				{
					db.Tests.Add(test);
					db.SaveChanges();
					Close();
				}
				catch (Exception)
				{
					MessageBox.Show("Не удаёться подключиться к базе данных");
				}
			}
		}
	}
}
