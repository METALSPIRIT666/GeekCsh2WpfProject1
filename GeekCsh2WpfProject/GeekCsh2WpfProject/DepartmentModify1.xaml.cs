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
    /// Логика взаимодействия для DepartmentModify1.xaml
    /// </summary>
    public partial class DepartmentModify1 : Window
    {
        public DepartmentModify1()
        {
            InitializeComponent();

            btnAccept.Click += btnAcceptClick;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        private void btnAcceptClick(object sender, RoutedEventArgs e)
        {
            Id = int.Parse(tbId.Text);
            Name = tbName.Text;
        }
    }
}
