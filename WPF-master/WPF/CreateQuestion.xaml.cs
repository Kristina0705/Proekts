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
	/// Логика взаимодействия для CreateQuestion.xaml
	/// </summary>
	public partial class CreateQuestion : Window
	{
		public Question Question { get; private set; }
		public CreateQuestion()
		{
			InitializeComponent();
			Question = null;
		}

		private void AddHandler(object senler, EventArgs eventArgs)
		{
			Question question = new Question();
			if (qustion.Text.Trim().Length == 0)
			{
				MessageBox.Show("Введите текст вопроса");
				return;
			}
			question.Vopros = qustion.Text.Trim();
			for (int i = 1; i < 5; i++)
			{
				TextBox ans = (TextBox)FindName("ans" + i);
				TextBox score = (TextBox)FindName("score" + i);
				if (ans != null && score != null && ans.Text.Trim().Length > 0 && int.TryParse(score.Text, out int s))
				{
					question.Answers.Add(new Answer { Ball = s, Title = ans.Text, Question = question });
				}
			}
			if (question.Answers.Count < 2)
			{
				MessageBox.Show("Введите хотябы два ответа");
				return;
			}
			Question = question;
			Close();
		}
	}
}
