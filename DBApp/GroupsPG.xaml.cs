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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBApp.DBContexts;

namespace DBApp
{
    public partial class GroupsPG : Page
    {
        private readonly CollegeDbContext _dbContext;
        public GroupsPG()
        {
            InitializeComponent();
            _dbContext = new CollegeDbContext();
            LoadGroupData();
        }

        private void LoadGroupData()
        {
            var group = _dbContext.Groupes.ToList();
            GroupsDG.ItemsSource = group;
        }
    }
}
