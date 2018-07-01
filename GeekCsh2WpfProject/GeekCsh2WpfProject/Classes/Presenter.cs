using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekCsh2WpfProject
{
    public class Presenter
    {
        private Model model;
        private MainWindow viev;

        public Presenter(MainWindow mW)
        {
            viev = mW;
            model = new Model();
        }

        public void Init()
        {
            viev.cbDepartment.ItemsSource = model.Departments;
            viev.lbDepartment.ItemsSource = model.Departments;

            viev.cbDepartment.SelectedIndex = 0;
            viev.lbEmployee.ItemsSource =
                    model.Departments.ElementAt(viev.cbDepartment.SelectedIndex).Members;
        }

        public void DepSelectionChanged()
        {
            viev.lbEmployee.ItemsSource =
                model.Departments.ElementAt(viev.cbDepartment.SelectedIndex).Members;
        }

        public void DepModify()
        {
            new DepartmentModify1(viev.lbDepartment.SelectedItem as Department).ShowDialog();
        }

        public void EmpModify()
        {
            new EmployeeModify(model.Departments, viev.lbEmployee.SelectedItem as Employee,
                        viev.cbDepartment.SelectedIndex).ShowDialog();
        }

        public void DepAdd()
        {
            Department newDep = new Department();
            model.Departments.Add(newDep);
            new DepartmentModify1(newDep).ShowDialog();
        }
    }
}
