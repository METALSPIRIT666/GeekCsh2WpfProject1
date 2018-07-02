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
        public EmployeeModify(ObservableCollection<Department> deps,
            Employee empl, int depIndex)
        {
            InitializeComponent();
            cbDepartment.ItemsSource = deps;
            cbDepartment.SelectedIndex = depIndex;
            DataContext = empl;
            btnClose.Click += delegate
            {
                if (cbDepartment.SelectedIndex != depIndex)
                {
                    deps.ElementAt(cbDepartment.SelectedIndex).Members.Add(empl);
                    deps.ElementAt(depIndex).Members.Remove(empl);
                }
                Close();
            };
        }
    }
}
