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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeekCsh2WpfProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Department> departments = new ObservableCollection<Department>()
        {
            new Department() {Id = 1, Name = "Programmers", Members = 
                new ObservableCollection<Employee>()
                {
                    new Employee() {Id = 1, Name = "Empl1", Age = 25, Salary = 80000},
                    new Employee() {Id = 3, Name = "Empl3", Age = 35, Salary = 100000},
                    new Employee() {Id = 4, Name = "Empl4", Age = 21, Salary = 60000}
                }},
            new Department() {Id = 2, Name = "Workers", Members =
                new ObservableCollection<Employee>()
                {
                    new Employee() {Id = 2, Name = "Empl2", Age = 46, Salary = 25000},
                    new Employee() {Id = 5, Name = "Empl5", Age = 28, Salary = 20000}
                }},
        };
        
        public MainWindow()
        {
            InitializeComponent();
            cbDepartment.ItemsSource = departments;
            lbDepartment.ItemsSource = departments;
            cbDepartment.SelectionChanged += cbDepartmentSelectionChanged;
            lbDepartment.MouseDoubleClick += lbDepartmentDoubleClick;
            cbDepartment.SelectedIndex = 0;
        }

        private void cbDepartmentSelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.ItemsSource != null)
                lbEmployee.ItemsSource = departments.ElementAt(cmb.SelectedIndex).Members;
        }

        private void lbDepartmentDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DepartmentModify1 depMod = new DepartmentModify1();
            depMod.Owner = this;
            depMod.lblDepName.Content = lbDepartment.SelectedItem.ToString();
            depMod.tbId.Text = lbDepartment.SelectedItem.ToString().Split('\t')[0];
            depMod.tbName.Text = lbDepartment.SelectedItem.ToString().Split('\t')[1];
            depMod.Show();
            depMod.btnAccept.Click += delegate
            {
                int a = lbDepartment.SelectedIndex;
                int b = cbDepartment.SelectedIndex;
                departments.ElementAt(a).Id = depMod.Id;
                departments.ElementAt(a).Name = depMod.Name;
                lbDepartment.ItemsSource = null;
                lbDepartment.ItemsSource = departments;
                cbDepartment.ItemsSource = null;
                cbDepartment.ItemsSource = departments;
                cbDepartment.SelectedIndex = b;

            };

        }

        
    }
}
