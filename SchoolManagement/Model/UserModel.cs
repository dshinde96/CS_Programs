
namespace Schoolmanagement.Users;

class User{
    public static int count;
    protected string FirstName;
    protected string LastName;
    public int uuid{get;init;}

    static User(){
        count=1;
    }
    public User(string FirstName,string LastName){
        this.FirstName=FirstName;
        this.LastName=LastName;
        this.uuid=count;
        count++;
    }

    public string Fullname{get{
        return $"{FirstName} {LastName}";
    }}

}

class Student:User,IDisposable{
    private bool isDisposed=false;
    private int? Percentage;

    private int? Standered;

    public Student(string FirstName,string LastName):base(FirstName,LastName){
        Percentage=null;
    }
    public Student(string FirstName,string LastName,int Percentage,int Standered):base(FirstName,LastName){
        this.Percentage=Percentage;
        this.Standered=Standered;
    }

    public override string ToString()
    {
        return $"\tid:{uuid}\n \tName:{FirstName} {LastName}\n \tPercentage:{Percentage}\n\tStandered:{Standered}";
    }


    public void Dispose(){

        Console.WriteLine("Disposing the student object");

        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing){
        if(!isDisposed){
            if(disposing){
                //Call Dispose for managed res
            }

            //Release unmanged res

            isDisposed=true;
        }
    }

    ~Student(){
        //Now the object is going to dispose by garbage collector. So leave managed res up to garbage collector. We will destroy only unmanaged res
        Dispose(false);
    }
}

class Teacher:User,IDisposable{
    private bool isDisposed=false;

    public int? Salary;
    public string? Subject;


    public Teacher(string FirstName,string LastName):base(FirstName,LastName){
        Salary=null;
        Subject=null;
    }
    public Teacher(string FirstName,string LastName,int Salary,string Subject):base(FirstName,LastName){
        this.Salary=Salary;
        this.Subject=Subject;
    }

    public override string ToString()
    {
        return $"\tid:{uuid}\n \tName:{FirstName} {LastName}\n \tSalary:{Salary}\n\tSubject:{Subject}";
    }


    public void Dispose(){

        Console.WriteLine("Disposing the student object");

        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing){
        if(!isDisposed){
            if(disposing){
                //Call Dispose for managed res
            }

            //Release unmanged res
            
        }
    }

    ~Teacher(){
        Dispose(false);
    }   
}