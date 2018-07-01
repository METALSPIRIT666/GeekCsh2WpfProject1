using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace GeekCsh2WpfProject
{
    /// <summary>
    /// Описывает класс департамента.
    /// </summary>
    public class Department : INotifyPropertyChanged
    {
        private static int currentId = 0;

        private int id;
        private string name;
        
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

        public ObservableCollection<Employee> Members { get; set; }

        public Employee this[int index]
        {
            get => Members.ElementAt(index);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Department()
        {
            id = currentId++;
            name = $"Employee_{id}";
        }
    }
}
