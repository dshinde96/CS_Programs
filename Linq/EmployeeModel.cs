namespace Linq;
class Employee{
    public int Id{get;set;}
    public string? Name{get;set;}
    public int Salary{get;set;}
    public bool IsManager{get;set;}

    public string? DeptId{get;set;}

    public override string ToString()
    {
        return $"ID:{Id} Name:{Name} Salary:{Salary} IsManager:{IsManager} DeptID:{DeptId}";
    }
}

class Department{

    public string? Id{get;set;}
    public string? Name{get;set;}

    public override string ToString()
    {
        return $"Id:{Id} Name:{Name}";
    }
}

class Data{
    public static List<Department>GetDepartments(){
        List<Department> AllDepartments=new List<Department>();
        AllDepartments.Add(new Department(){Id="HR",Name="Human Res"});
        AllDepartments.Add(new Department(){Id="FN",Name="Finance"});
        AllDepartments.Add(new Department(){Id="TC",Name="Technoloy"});
        AllDepartments.Add(new Department(){Id="RD",Name="Research And Developemnt"});

        return AllDepartments;
    }
    public static List<Employee> GetEmployees(){
        List<Employee> AllEmployee=new List<Employee>();
        AllEmployee.Add(new Employee(){Id=1,Name="Ram",Salary=50000,IsManager=false,DeptId="FN"});
        AllEmployee.Add(new Employee(){Id=2,Name="Shyam",Salary=100000,IsManager=true,DeptId="HR"});
        AllEmployee.Add(new Employee(){Id=3,Name="adhv",Salary=50000,IsManager=false,DeptId="TC"});
        AllEmployee.Add(new Employee(){Id=3,Name="Bo",Salary=70000,IsManager=false,DeptId="TC"});
        AllEmployee.Add(new Employee(){Id=4,Name="Alice",Salary=30000,IsManager=true,DeptId="MK"});
        return AllEmployee;
    }
}