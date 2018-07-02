using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeekCsh2WpfProject
{
    public class Presenter
    {
        private MainWindow viev;
        private Model model;

        private Department CurrentDepartment { get; set; }

        public Presenter(MainWindow mW)
        {
            viev = mW;
            model = new Model();
        }

        public void Init()
        {
            viev.lbDepartment.ItemsSource = model.Departments;
            viev.lbDepartment.SelectedIndex = 0;
            viev.lbEmployee.SelectedIndex = 0;
            CurrentDepartment = viev.lbDepartment.SelectedItem as Department;
            viev.lbDepartment.Focus();

            viev.lbEmployee.ItemsSource =
                    model.Departments.ElementAt(viev.lbDepartment.SelectedIndex).Members;
        }

        public void DepSelectionChanged()
        {
            viev.lbEmployee.ItemsSource = viev.lbDepartment.SelectedItem != null ?
                model.Departments.ElementAt(
                    viev.lbDepartment.SelectedIndex).Members : null;
        }

        public void DepModify()
        {
            new DepartmentModify1(viev.lbDepartment.SelectedItem as Department).ShowDialog();
        }

        public void EmpModify()
        {
            new EmployeeModify(model.Departments, viev.lbEmployee.SelectedItem as Employee,
                        viev.lbDepartment.SelectedIndex).ShowDialog();
        }

        public void DepAdd()
        {
            Department newDep = new Department();
            model.Departments.Add(newDep);
            viev.lbDepartment.SelectedItem = newDep;
            viev.lbDepartment.Focus();
            new DepartmentModify1(newDep).ShowDialog();
            viev.btnEmpAdd.IsEnabled = true;
        }

        public void EmpAdd()
        {
            Employee newEmp = new Employee();
            if (viev.lbDepartment.SelectedItem != null) viev.lbDepartment.SelectedIndex = 0;
            model.Departments.ElementAt(
                viev.lbDepartment.SelectedIndex).Members.Add(newEmp);
            viev.lbEmployee.SelectedItem = newEmp;
            viev.lbEmployee.Focus();
            new EmployeeModify(model.Departments,
                newEmp, viev.lbDepartment.SelectedIndex).ShowDialog();
        }

        public void DepDelete()
        {
            int ind = viev.lbDepartment.SelectedIndex;
            model.Departments.Remove(viev.lbDepartment.SelectedItem as Department);
            viev.lbDepartment.SelectedIndex = --ind;
            if (model.Departments.Count == 0) viev.btnEmpAdd.IsEnabled = false;
        }

        public void EmpDelete()
        {
            model.Departments.ElementAt(viev.lbEmployee.SelectedIndex).Members.Remove(
                viev.lbEmployee.SelectedItem as Employee);
        }

        public void ProvideInfo()
        {
            MessageBox.Show("DoubleClick on item to edit." +
                    " DELETE key on item to remove.", "INFO",
                        MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
