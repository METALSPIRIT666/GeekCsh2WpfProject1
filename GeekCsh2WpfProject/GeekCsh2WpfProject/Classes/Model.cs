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
        private string sql = $@" SELECT * FROM Departments";
        private SqlCommand command;
        private SqlDataReader reader;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = @"(localdb)\MSSQLLocalDB",
            InitialCatalog = "Departments",
        };

        public Model()
        {
            Departments = new ObservableCollection<Department>();
    
            connection = new SqlConnection(connectionStringBuilder.ConnectionString);

            //Считываем базу и формируем коллекцию Departments
            using (connection)
            {
                connection.Open();
                sql = $@" SELECT * FROM Departments";
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Department newDep = new Department();
                    newDep.Id = (int)reader["Id"];
                    newDep.Name = (string)reader["Name"];
                    
                    Departments.Add(newDep);
                }
                reader.Close();
                foreach (Department dep in Departments)
                {
                    sql = $@" SELECT * FROM Employees WHERE DepartmentId = {dep.Id}";
                    command = new SqlCommand(sql, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee newEmp = new Employee(dep);
                        newEmp.Id = (int)reader["Id"];
                        newEmp.Name = (string)reader["Name"];
                        newEmp.Age = (int)reader["Age"];
                        newEmp.Salary = (Single)reader["Salary"];
                        dep.Members.Add(newEmp);
                    }
                    reader.Close();

                }

                //Достаем из базы актуальные значения "незанятых" Id
                sql = @" SELECT IDENT_CURRENT('Departments')";
                command = new SqlCommand(sql, connection);
                Department.currentId = Decimal.ToInt32((decimal)command.ExecuteScalar()) + 1;

                sql = @" SELECT IDENT_CURRENT('Employees')";
                command = new SqlCommand(sql, connection);
                Employee.currentId = Decimal.ToInt32((decimal)command.ExecuteScalar()) + 1;
            }
        }

        public void DepAdd(Department dep)
        {
            using (connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                sql = $@"INSERT INTO Departments (Name) VALUES ('{dep.Name}')";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                sql = $@"SELECT Id FROM Departments WHERE Name = '{dep.Name}'";
                command = new SqlCommand(sql, connection);
                dep.Id = (int)command.ExecuteScalar();
            }
        }

        public void DepEdit(Department dep)
        {
            using (connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                sql = $@"UPDATE Departments SET Name = '{dep.Name}' 
                    WHERE Id = {dep.Id}";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DepDelete(Department dep)
        {
            using (connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                sql = $@"DELETE FROM Departments WHERE Id = {dep.Id}";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public void EmpAdd(Employee emp)
        {
            using (connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                sql = $@"SELECT Id FROM Departments WHERE Name = '{emp.Department.Name}'";
                command = new SqlCommand(sql, connection);
                int depId = (int)command.ExecuteScalar();

                sql = $@"INSERT INTO Employees (Name, Age, Salary, DepartmentId)
                    VALUES ('{emp.Name}', {emp.Age}, {emp.Salary}, {depId})";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                sql = $@"SELECT Id FROM Employees WHERE Name = '{emp.Name}'";
                command = new SqlCommand(sql, connection);
                emp.Id = (int)command.ExecuteScalar();
            }
        }

        public void EmpEdit(Employee emp)
        {
            using (connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                sql = $@"SELECT Id FROM Departments WHERE Name = '{emp.Department.Name}'";
                command = new SqlCommand(sql, connection);
                int depId = (int)command.ExecuteScalar();

                sql = $@"UPDATE Employees SET Name = '{emp.Name}', Age = {emp.Age},
                    Salary = {emp.Salary}, DepartmentId = {depId} WHERE Id = {emp.Id}";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public void EmpDelete(Employee emp)
        {
            using (connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                sql = $@"DELETE FROM Employees WHERE Id = {emp.Id}";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

    }
}
