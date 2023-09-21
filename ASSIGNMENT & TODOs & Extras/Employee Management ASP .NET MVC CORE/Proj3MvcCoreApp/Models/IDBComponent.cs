namespace Proj3MvcCoreApp.Models
    {
    public interface IDBComponent
        {
        List<Employee> GetAllEmployees();
        void AddEmployee (Employee employee);
        void DeleteEmployee (int id);
        void UpdateEmployee (Employee employee);
        Employee GetEmployee(int id);
        List<Dept> GetAllDepts();
        Dept GetDept(int id);
        }

    public class DbComponent : IDBComponent
        {
        private readonly MyDbContext _dbContext;
        public DbComponent(MyDbContext context)
            {
            _dbContext = context;
            }

        public void AddEmployee(Employee employee)
            {
            _dbContext.EmpTable2s.Add(employee);
            _dbContext.SaveChanges();
            }

        public void DeleteEmployee(int id)
            {
            var selected = _dbContext.EmpTable2s.Find(id);
            if (selected != null)
                {
                _dbContext.EmpTable2s.Remove(selected);
                _dbContext.SaveChanges ();
                }
            else
                {
                throw new Exception("No REcord Found to delete");
                }
        }

        public List<Dept> GetAllDepts()
            {
                return _dbContext.Departments.ToList();
            }

        public List<Employee> GetAllEmployees()
            {
            return _dbContext.EmpTable2s.ToList();
            }

        public Dept GetDept(int id)
            {
            return _dbContext.Departments.Find(id) ?? throw new Exception("Dept not found");
            }

        public Employee GetEmployee(int id)
            {
            return _dbContext.EmpTable2s.Find(id) ?? throw new Exception("Employee Not found");
            }

        public void UpdateEmployee(Employee employee)
            {
            var emp = _dbContext.EmpTable2s.Find(employee.Id);
            if(emp != null)
                {
                emp.Salary = employee.Salary;
                emp.Address = employee.Address;
                emp.Name = employee.Name;
                emp.DeptId = employee.DeptId;
                _dbContext.SaveChanges();
                }
            else
                {
                throw new Exception("Employee not found to update");
                }
            }
        }
    }
