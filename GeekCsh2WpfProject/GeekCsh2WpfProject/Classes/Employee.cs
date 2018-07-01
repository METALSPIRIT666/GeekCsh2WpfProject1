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
        private double salary;

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
        public double Salary
        {
            get => salary;
            set
            {
                salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Salary"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Employee()
        {
            id = currentId++;
            name = $"Employee_{id}";
        }
    }
}
