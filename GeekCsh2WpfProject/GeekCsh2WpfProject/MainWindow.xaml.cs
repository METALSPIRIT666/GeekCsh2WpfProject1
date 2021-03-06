﻿using System;
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
        Presenter p;
        public MainWindow()
        {
            InitializeComponent();
            p = new Presenter(this);

            p.Init();

            lbDepartment.SelectionChanged += delegate { p.DepSelectionChanged(); };
            lbDepartment.MouseDoubleClick += delegate { p.DepModify(); };
            lbEmployee.MouseDoubleClick += delegate { p.EmpModify(); };
            btnDepAdd.Click += delegate { p.DepAdd(); };
            btnEmpAdd.Click += delegate { p.EmpAdd(); };
            btnInfo.Click += delegate { p.ProvideInfo(); };
            lbDepartment.KeyDown += (s, e) => p.LbDepKeyPressed(e);
            lbEmployee.KeyDown += (s, e) => p.LbEmpKeyPressed(e);
            KeyDown += (s, e) => p.WindowKeyPressed(e); 
        }
    }
}
