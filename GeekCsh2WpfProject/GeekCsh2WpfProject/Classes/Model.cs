using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekCsh2WpfProject
{
    public class Model
    {
        public ObservableCollection<Department> Departments { get; set; }

        public Model()
        {
            Departments = new ObservableCollection<Department>()
            {
                new Department() {Name = "Programmers", Members =
                    new ObservableCollection<Employee>()
                    {
                        new Employee() {Age = 25, Salary = 80000},
                        new Employee() {Age = 35, Salary = 850000},
                        new Employee() {Age = 23, Salary = 90000},
                        new Employee() {Age = 26, Salary = 100000},
                        new Employee() {Age = 21, Salary = 60000}
                    }},
                new Department() {Name = "Workers", Members =
                    new ObservableCollection<Employee>()
                    {
                        new Employee() {Age = 46, Salary = 30000},
                        new Employee() {Age = 28, Salary = 30000},
                        new Employee() {Age = 52, Salary = 40000},
                        new Employee() {Age = 35, Salary = 45000}
                    }},
                new Department() {Name = "Managers", Members =
                    new ObservableCollection<Employee>()
                    {
                        new Employee() {Age = 25, Salary = 40000},
                        new Employee() {Age = 28, Salary = 50000},
                        new Employee() {Age = 28, Salary = 60000},
                        new Employee() {Age = 32, Salary = 55000},
                        new Employee() {Age = 24, Salary = 35000}
                    }},
            };
        }
    }
}
