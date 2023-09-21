using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj3MvcCoreApp.Models
    {
    [Table("EmpTable2")]
    public class Employee
        {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is mandatory")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is must")]
        [Range(10000, 50000, ErrorMessage = "Salary should be b/w 10000 to 50000")]
        public int Salary { get; set; }
        public int DeptId {  get; set; }

        }
    [Table("Department")]
    public class  Dept
    {
        [Key]
        public int Id { get; set; }
        public string DeptName { get; set; } = string.Empty;
    }
    public class MyDbContext : DbContext
        {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
            { 

            }
        public DbSet<Employee> EmpTable2s { get; set;}
        public DbSet<Dept> Departments { get; set;}
        }
}
