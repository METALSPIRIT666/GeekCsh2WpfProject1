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
    /// Логика взаимодействия для DepartmentModify1.xaml
    /// </summary>
    public partial class DepartmentModify1 : Window
    {
        public DepartmentModify1(Department dep)
        {
            InitializeComponent();
            this.DataContext = dep;
            btnClose.Click += delegate { Close(); };
            KeyDown += (s, e) => { if (e.Key == Key.Enter ||
                e.Key == Key.Escape) Close(); };
        }
    }
}
