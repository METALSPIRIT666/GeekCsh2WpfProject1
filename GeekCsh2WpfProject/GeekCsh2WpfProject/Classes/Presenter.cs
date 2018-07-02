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
                    CurrentDepartment.Members;
        }

        public void DepSelectionChanged()
        {
            CurrentDepartment = viev.lbDepartment.SelectedItem as Department;
            viev.lbEmployee.ItemsSource = CurrentDepartment != null ?
                CurrentDepartment.Members : null;
            viev.lbEmployee.SelectedIndex = 0;
        }

        public void DepModify()
        {
            new DepartmentModify1(CurrentDepartment).ShowDialog();
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
            if (CurrentDepartment == null) viev.lbDepartment.SelectedIndex = 0;
            CurrentDepartment.Members.Add(newEmp);
            viev.lbEmployee.SelectedItem = newEmp;
            viev.lbEmployee.Focus();
            new EmployeeModify(model.Departments,
                newEmp, viev.lbDepartment.SelectedIndex).ShowDialog();
        }

        public void DepDelete()
        {
            int ind = viev.lbDepartment.SelectedIndex;
            model.Departments.Remove(CurrentDepartment);
            viev.lbDepartment.SelectedIndex = ind > 0 ? --ind : ind;
            if (model.Departments.Count == 0) viev.btnEmpAdd.IsEnabled = false;
        }

        public void EmpDelete()
        {
            int ind = viev.lbEmployee.SelectedIndex;
            CurrentDepartment.Members.Remove(viev.lbEmployee.SelectedItem as Employee);
            viev.lbEmployee.SelectedIndex = ind > 0 ? --ind : ind;
        }

        public void ProvideInfo()
        {
            MessageBox.Show("DoubleClick on item to edit." +
                    " DELETE key on item to remove.", "INFO",
                        MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
