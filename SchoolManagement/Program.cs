using Schoolmanagement.UserService;
namespace Schoolmanagement;

class Program
{
    public static void Main(string[] args)
    {
        StudentService studentService = new StudentService();
        TeacherService teacherService = new TeacherService();
        try
        {
            int choice;
            Console.WriteLine($"\n\nEnter Your Choice\n\t1. Add new Student. \n\t2. Add New Teacher. \n\t3. Get Student by id. \n\t4. Get Teacher by id. \n\n Enter 0 to exit");
            choice = Convert.ToInt32(Console.ReadLine());

            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        studentService.addNewStudent();
                        break;
                    case 2:
                        studentService.getStudentById();
                        break;
                    case 3:
                        teacherService.addNewTeacher();
                        break;
                    case 4:
                        teacherService.getTeacherById();
                        break;
                    default :
                        Console.WriteLine("\n Invalid input");
                        break;
                }
                Console.WriteLine($"\n\n\t1. Add new Student. \n\t2. Add New Teacher. \n\t3. Get Student by id. \n\t4. Get Teacher by id. \n\n Enter 0 to exit");
                choice = Convert.ToInt32(Console.ReadLine());
            }
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}
