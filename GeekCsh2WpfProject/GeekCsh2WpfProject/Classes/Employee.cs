using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekCsh2WpfProject
{
    /// <summary>
    /// Описывает класс наемного работника.
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        private static int currentId = 0;

        private int id;
        private string name;
        private int age;
        private Single salary;
        private Department department;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public int Age
        {
            get => age;
            set
            {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
            }
        }
        public Single Salary
        {
            get => salary;
            set
            {
                salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Salary"));
            }
        }
        public Department Department
        {
            get => department;
            set
            {
                department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Department"));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public Employee(Department dep)
        {
            id = currentId++;
            name = $"Employee_{id}";
            age = 21;
            salary = 40000;
            department = dep;
        }

        private Employee()
        {
        }
    }
}
