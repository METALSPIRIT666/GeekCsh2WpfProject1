using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekCsh2WpfProject
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Employee> Members;

        public override string ToString() => $"{Id}\t{Name}";
    }
}
