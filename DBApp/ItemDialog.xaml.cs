using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
using DBApp.DBContexts;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace DBApp
{
    public partial class ItemDialog : Window
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string SelectedGroup { get; private set; }

        private readonly CollegeDbContext _dbContext;

        public ItemDialog(string firstname = "", string lastname = "", DateTime? birthDate = null, string selectedGroup = "")
        {
            InitializeComponent();
            _dbContext = new CollegeDbContext();

            FirstNameTB.Text = firstname;
            LastNameTB.Text = lastname;
            BirthDateDP.SelectedDate = birthDate ?? DateTime.Today;

            LoadGroups();
            GroupCB.SelectedItem = selectedGroup;
        }

        public void LoadGroups()
        {
            List<string> groups = _dbContext.Groupes.Select(g => g.GroupName).ToList();

        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTB.Text) ||
                string.IsNullOrWhiteSpace(LastNameTB.Text) ||
                BirthDateDP.SelectedDate == null ||
                GroupCB.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            FirstName = FirstNameTB.Text; 
            LastName = LastNameTB.Text;
            BirthDate = BirthDateDP.SelectedDate;
            SelectedGroup = GroupCB.SelectedItem.ToString();

            DialogResult = true;
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
