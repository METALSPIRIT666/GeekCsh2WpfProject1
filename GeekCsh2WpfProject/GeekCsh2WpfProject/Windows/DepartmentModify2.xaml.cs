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

namespace GeekCsh2WpfProject
{
    /// <summary>
    /// Логика взаимодействия для DepartmentModify2.xaml
    /// </summary>
    public partial class DepartmentModify2 : Window
    {
        public DepartmentModify2(Department dep)
        {
            InitializeComponent();
            lbEmployee.ItemsSource = dep.Members;
            btnClose.Click += delegate { Close(); };
            btnEmpAdd.Click += delegate
            {
                Employee newEmp = new Employee();
                dep.Members.Add(newEmp);
                new EmployeeBasicModify(newEmp).ShowDialog();
            };
            lbEmployee.MouseDoubleClick += delegate
            {
                new EmployeeBasicModify(lbEmployee.SelectedItem as Employee).ShowDialog();
            };
        }
    }
}
