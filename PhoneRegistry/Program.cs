using System.Collections;
using System.IO;

namespace PhoneReg;

class User{
    public string name;
    public int number;

    public User(string name,int number){
        this.name=name;
        this.number=number;
    }

    public override string ToString()
    {
        return $"Name:{name} Contact:{number}";
    }
}

class Phonbook{
    private Dictionary<int,User> AllUsers=new Dictionary<int, User>();

    public void addUser(User u){
        AllUsers.Add(u.number,u);
    }

    public User? getUserByNumber(int number){
        if(AllUsers.ContainsKey(number))
        return AllUsers[number];
        return null;
    }

    public void PrintAllUsers(){
        foreach(KeyValuePair<int,User> k in AllUsers){
            Console.WriteLine(k.Value.ToString());
        }
    }
}

class FileManger{
    public static void LoadContacts(string filePath, Phonbook pb){
        StreamReader sr=new StreamReader(filePath);
        string? line=sr.ReadLine();
        while(line!=null){
            // Console.WriteLine(line);
            string[] words=line.Split(' ');
            pb.addUser(new User($"{words[0]} {words[1]}",Convert.ToInt32(words[2])));
            // System.Console.WriteLine("\n\n");
            line=sr.ReadLine();
        }
        sr.Close();
    }

    public static void ReadContacts(string filePath, Phonbook pb){
        StreamReader sr=new StreamReader(filePath);

        string? line=sr.ReadLine();

        while(line!=null){
            int number=Convert.ToInt32(line);
            User? u=pb.getUserByNumber(number);
            if(u!=null){
                Console.WriteLine(u.name);
            }
            else{
                Console.WriteLine(number);
            }
            line=sr.ReadLine();
        }
        sr.Close();
    }
}

class Program{

    public static void Main(string[] args){

        Phonbook pb=new Phonbook();

        //read the file
        string Contacts="/home/dnyaneshwar/C#/PhoneRegistry/Contacts.txt";
        string Recents="/home/dnyaneshwar/C#/PhoneRegistry/Recents.txt";
        string Favorites="/home/dnyaneshwar/C#/PhoneRegistry/Favorite.txt";

        //Load contacts
        FileManger.LoadContacts(Contacts,pb);

        Console.WriteLine("\n\nAll Users");
        pb.PrintAllUsers();

        Console.WriteLine("\n\nRecents contact");
        FileManger.ReadContacts(Recents,pb);

        Console.WriteLine("\n\nFavorites Contacts");
        FileManger.ReadContacts(Favorites,pb);

    }
}