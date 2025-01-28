using System.Linq;
using System.Reflection.Metadata.Ecma335;
namespace Linq;

class Program{
    public static void Main(string[] args){
        List<Employee>AllEmp=Data.GetEmployees();
        List<Department>AllDept=Data.GetDepartments();


        //Query syntax is easier to read and understand, so try to use query syntax whenever possible. In case of aggrigate function like sum, average, min, max, we can use Method syntax

        // var AvgSalary=AllEmp.Average(emp=>emp.Salary);
        // System.Console.WriteLine(AvgSalary);


        //Method syntax-> filter operation
        // var filteredEmp= AllEmp.Select(emp=>new {
        //                     Name=emp.Name,
        //                     Salary=emp.Salary,
        //                     IsManager=emp.IsManager,
        //                     DeptId=emp.DeptId
        // }).Where(emp=>emp.IsManager==false);

        //Query Syntax-> filter operation
        // var filteredEmp=from emp in AllEmp
        //                 where emp.IsManager is true
        //                 select new {
                            // Name=emp.Name,
                            // Salary=emp.Salary,
                            // IsManager=emp.IsManager,
                            // DeptId=emp.DeptId
        //                 };

        // foreach(var e in filteredEmp){
        //     Console.WriteLine($"name:{e.Name} Salary:{e.Salary} IsManager:{e.IsManager} Department:{e.DeptId}");
        // }
        // var filteredEmp=AllEmp;

        //Query Syntax-> join Operation
        // var filteredEmp=from emp in AllEmp
        //                 join d in AllDept
        //                 on emp.DeptId equals d.Id
        //                 select new{
        //                     Name=emp.Name,
        //                     Salary=emp.Salary,
        //                     IsManager=emp.IsManager,
        //                     Department=d.Name
        //                 };

        //Method syntax-> Join operation
        // var filteredEmp=AllEmp.Join(AllDept,
        //     employee=>employee.DeptId,
        //     department=>department.Id,
        //     (employee,department)=>new{
        //         Name=employee.Name,
        //         Department=department.Name
        //     }
        // );
        // foreach(var e in filteredEmp){
        //     Console.WriteLine($"name:{e.Name} Department:{e.Department}");
        // }


        //Method syntax-> Outer join
        // var DepartmentsWithEmployee=AllDept.GroupJoin(AllEmp,
        //     department=>department.Id,
        //     employee=>employee.DeptId,
        //     (department,employees)=>new{
        //         employees,
        //         department=department.Name
        //     }
        // );

        // foreach(var d in DepartmentsWithEmployee){
        //     Console.WriteLine($"Department:{d.department}\n\t Employees:");
        //     foreach(var e in d.employees){
        //         Console.WriteLine(e.Name);
        //     }

        // }


        // var empCountByDept=AllEmp.GroupBy((emp)=>emp.DeptId).Select(dept=>new {department=dept.Key,Eployees=dept.Count()});
        // foreach(var i in empCountByDept){
        //     Console.WriteLine(i.ToString());
        // }


        var emp=AllEmp.Select(e=>new {name=e.Name,Salary=e.Salary}).OrderBy(emp=>emp.Salary);
        Console.WriteLine(emp.GetType());
        foreach(var e in emp){
            Console.WriteLine(e.ToString());
        }
                        
    }
}