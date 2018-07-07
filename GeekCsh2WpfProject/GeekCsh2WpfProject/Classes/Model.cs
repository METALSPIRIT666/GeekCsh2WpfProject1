using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekCsh2WpfProject
{
    public class Model
    {
        public ObservableCollection<Department> Departments { get; set; }

        private SqlConnection connection;
        private SqlDataAdapter employeeAdapter;
        private SqlDataAdapter departmentAdapter;
        private DataTable departmentTable;
        private DataTable employeeTable;

        public Model()
        {
            //Departments = new ObservableCollection<Department>()
            //{
            //    new Department() {Name = "Programmers", Members =
            //        new ObservableCollection<Employee>()
            //        {
            //            new Employee() {Age = 25, Salary = 80000},
            //            new Employee() {Age = 35, Salary = 850000},
            //            new Employee() {Age = 23, Salary = 90000},
            //            new Employee() {Age = 26, Salary = 100000},
            //            new Employee() {Age = 21, Salary = 60000}
            //        }},
            //    new Department() {Name = "Workers", Members =
            //        new ObservableCollection<Employee>()
            //        {
            //            new Employee() {Age = 46, Salary = 30000},
            //            new Employee() {Age = 28, Salary = 30000},
            //            new Employee() {Age = 52, Salary = 40000},
            //            new Employee() {Age = 35, Salary = 45000}
            //        }},
            //    new Department() {Name = "Managers", Members =
            //        new ObservableCollection<Employee>()
            //        {
            //            new Employee() {Age = 25, Salary = 40000},
            //            new Employee() {Age = 28, Salary = 50000},
            //            new Employee() {Age = 28, Salary = 60000},
            //            new Employee() {Age = 32, Salary = 55000},
            //            new Employee() {Age = 24, Salary = 35000}
            //        }},
            //};

            Departments = new ObservableCollection<Department>();

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "Departments",
            };
            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            employeeAdapter = new SqlDataAdapter();
            employeeAdapter.TableMappings.Add("Employees", "Employees");
            departmentAdapter = new SqlDataAdapter();
            //departmentAdapter.TableMappings.Add("Departments", "Departments");

            #region Employee commands

            // select
            SqlCommand command =
                new SqlCommand("SELECT Id, Name, Age, Salary, DepartmentId FROM Employees",
                connection);
            employeeAdapter.SelectCommand = command;

            // insert
            command = new SqlCommand(@"INSERT INTO Employees (Name, Age, Salary, DepartmentId) 
                          VALUES (@Name, @Age, @Salary, @DepartmentId); SET @Id = @@IDENTITY;",
                          connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Age", SqlDbType.Int, -1, "Age");
            command.Parameters.Add("@Salary", SqlDbType.Decimal, -1, "Salary");
            command.Parameters.Add("@DepartmentId", SqlDbType.Int, -1, "DepartmentId");

            SqlParameter param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

            param.Direction = ParameterDirection.Output;
            employeeAdapter.InsertCommand = command;

            // update
            command = new SqlCommand(@"UPDATE Employees SET Name = @Name,
Age = @Age, Salary = @Salary, DepartmentId = @DepartmentId WHERE Id = @Id", connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Age", SqlDbType.Int, -1, "Age");
            command.Parameters.Add("@Salary", SqlDbType.Decimal, -1, "Salary");
            command.Parameters.Add("@DepartmentId", SqlDbType.Int, -1, "DepartmentId");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

            param.SourceVersion = DataRowVersion.Original;

            employeeAdapter.UpdateCommand = command;

            //delete
            command = new SqlCommand("DELETE FROM Employees WHERE Id = @Id", connection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            employeeAdapter.DeleteCommand = command;

            #endregion

            #region Department commands

            // select
            command = new SqlCommand("SELECT Id, Name FROM dbo.Departments", connection);
            departmentAdapter.SelectCommand = command;

            // insert
            command = new SqlCommand(@"INSERT INTO dbo.Departments (Name) 
                          VALUES (@Name); SET @Id = @@IDENTITY;",
                          connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            departmentAdapter.InsertCommand = command;

            // update
            command = new SqlCommand(@"UPDATE dbo.Departments SET Name = @Name
WHERE Id = @Id", connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            departmentAdapter.UpdateCommand = command;

            //delete
            command = new SqlCommand("DELETE FROM dbo.Departments WHERE Id = @Id", connection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            departmentAdapter.DeleteCommand = command;

            #endregion

            employeeTable = new DataTable();
            departmentTable = new DataTable();
            employeeAdapter.Fill(employeeTable);
            departmentAdapter.Fill(departmentTable);

            //Заполнение коллекции Department данными из бд
            for (int i = 0; i < departmentTable.Rows.Count; i++)
            {
                DataRow dr = departmentTable.Rows[i];
                Department newDep = new Department();
                newDep.Id = (int)dr["Id"];
                newDep.Name = (string)dr["Name"];
                Departments.Add(newDep);
            }
            for (int i = 0; i < employeeTable.Rows.Count; i++)
            {
                DataRow dr = employeeTable.Rows[i];
                Employee newEmp = new Employee(Departments.ElementAt((int)dr["DepartmentId"] - 1));
                newEmp.Id = (int)dr["Id"];
                newEmp.Name = (string)dr["Name"];
                newEmp.Age = (int)dr["Age"];
                newEmp.Salary = (Single)dr["Salary"];
                Departments.ElementAt((int)dr["DepartmentId"] - 1).Members.Add(newEmp);
            }
        }

        public void DepAdd(Department dep)
        {
            Departments.Add(dep);
            DataRow newRow = departmentTable.NewRow();
            newRow["Id"] = dep.Id;
            newRow["Name"] = dep.Name;
            departmentTable.Rows.Add(newRow);
            departmentAdapter.Update(departmentTable);
        }

        public void EmpAdd(Employee emp)
        {
            DataRow newRow = employeeTable.NewRow();
            newRow["Id"] = emp.Id;
            newRow["Name"] = emp.Name;
            newRow["Age"] = emp.Age;
            newRow["Salary"] = emp.Salary;
            newRow["DepartmentId"] = Departments.IndexOf(emp.Department) + 1;
            employeeTable.Rows.Add(newRow);
            employeeAdapter.Update(employeeTable);
        }

    }
}
