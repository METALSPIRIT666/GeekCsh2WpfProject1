using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GeekCsh2WpfProject
{
    /// <summary>
    /// Логика взаимодействия для EmployeeModify.xaml
    /// </summary>
    public partial class EmployeeModify : Window
    {
        public EmployeeModify(ObservableCollection<Department> departments)
        {
            InitializeComponent();

            Departments = departments;
            cbDepartment.ItemsSource = Departments;
            cbDepartment.SelectedIndex = 0;
        }

        public ObservableCollection<Department> Departments;
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        private void btnAcceptClick(object sender, RoutedEventArgs e)
        {
            Id = int.Parse(tbId.Text);
            Age = int.Parse(tbAge.Text);
            Name = tbName.Text;
            Salary = double.Parse(tbSalary.Text);
            Close();
        }
    }
}
