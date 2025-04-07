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
using System.Xml.Linq;
using DBApp.dbEntityClasses;

namespace DBApp.Windows
{
    
    /// <summary>
    /// Логика взаимодействия для AddSubject.xaml
    /// </summary>
    public partial class AddSubject : Window
    {
        readonly public Database database = new();
        public AddSubject()
        {
            InitializeComponent();
        }

        private void AddSubject_btn_Click(object sender, RoutedEventArgs e)
        {
            string subjectName = NameTB.Text;

            if (string.IsNullOrWhiteSpace(subjectName))
            {
                MessageBox.Show("Имя не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            database.AddSubject(subjectName);

            Subject subject = new()
            {
                SubjectName = subjectName
            };

            MessageBox.Show("Предмет добавлен успешно");

            this.DialogResult = true;
            Close();
        }
    }
}
