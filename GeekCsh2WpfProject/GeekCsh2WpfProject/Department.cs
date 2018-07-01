using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GeekCsh2WpfProject
{
    public class Department : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Id}\t{Name}";
        }
    }
}
