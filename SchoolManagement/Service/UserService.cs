
using Schoolmanagement.Users;

namespace Schoolmanagement.UserService;

class StudentService{

    List<Student> AllStudents= new List<Student>();
    public void addNewStudent(){
        string? FirstName,LastName;
        int Percentage,Standered;

        try
        {
            Console.Write("Firstname:");
            FirstName=Console.ReadLine();

            Console.Write("Lastname:");
            LastName=Console.ReadLine();

            Console.Write("Percentage:");
            Percentage=Convert.ToInt32(Console.ReadLine());

            Console.Write("Standered:");
            Standered=Convert.ToInt32(Console.ReadLine());

            if(FirstName==null || LastName==null){
                Console.WriteLine("Invalid inputs");
                return;
            }

            Student s=new Student(FirstName,LastName,Percentage,Standered);

            AllStudents.Add(s);
            Console.WriteLine("Student Added Successfully:");
            Console.WriteLine(s.ToString());

        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    public void getStudentById(){
        try
        {
            int id;
            Console.Write("Enter the id:");
            id=Convert.ToInt32(Console.ReadLine());
            bool flag=false;
            foreach(Student s in AllStudents){
                if(s.uuid==id){
                    Console.WriteLine(s.ToString());
                    flag=true;
                    break;
                }
            }
            if(!flag){
                Console.WriteLine($"Student with id {id} is not found");
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}

class TeacherService{
    List<Teacher> AllTeachers= new List<Teacher>();
    public void addNewTeacher(){
        string? FirstName,LastName,Subject;
        int Salary;
        try
        {
            Console.Write("Firstname:");
            FirstName=Console.ReadLine();

            Console.Write("Lastname:");
            LastName=Console.ReadLine();

            Console.Write("Lastname:");
            Subject=Console.ReadLine();

            Console.Write("Standered:");
            Salary=Convert.ToInt32(Console.ReadLine());

            if(FirstName==null || LastName==null || Subject==null){
                Console.WriteLine("Invalid inputs");
                return;
            }
            Teacher t=new Teacher(FirstName,LastName,Salary,Subject);

            AllTeachers.Add(t);
            System.Console.WriteLine("Teacher added Successfully");
            Console.WriteLine(t.ToString());

        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    public void getTeacherById(){
        try
        {
            int id;
            Console.Write("Enter the id:");
            id=Convert.ToInt32(Console.ReadLine());
            bool flag=false;
            foreach(Teacher t in AllTeachers){
                if(t.uuid==id){
                    Console.WriteLine(t.ToString());
                    flag=true;
                    break;
                }
            }
            if(!flag){
                Console.WriteLine($"Teacher with id {id} is not found");
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}