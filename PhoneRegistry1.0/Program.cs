
using System.Collections.ObjectModel;

namespace PhoneBookRepo;

class User
{
    private int _number;
    private string? _name;

    public User(int number, string name)
    {
        _name = name;
        _number = number;
    }

    public User(int number){
        _number=number;
    }

    public override string ToString()
    {
        return _name!=null? $"{_name} {_number}":$"{_number}";
    }
}

interface IPhonebook
{
    public Collection<User> filterFromFile(string filePath);
}

class Contacts
{

     public Dictionary<int, User> AllContacts = new Dictionary<int, User>();

    //read contacts from file
    public Contacts(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string s in lines)
        {
            string[] contacts = s.Split(" ");
            AllContacts[Convert.ToInt32(contacts[2])] = new User(Convert.ToInt32(contacts[2]), $"{contacts[0]} {contacts[1]}");
        }
    }

    public Collection<User> getAllContacts(){
        Collection<User> c=new Collection<User>();

        foreach(KeyValuePair<int,User> k in AllContacts){
            c.Add(k.Value);
        }
        return c;
    }

}

class Recents : IPhonebook
{
    Dictionary<int,User>AllContacts=new Dictionary<int, User>();

    public Recents(Contacts c){
        this.AllContacts=c.AllContacts;
    }
    public Collection<User> filterFromFile(string filePath)
    {
        Collection<User> Recents=new Collection<User>();
        string[] lines = File.ReadAllLines(filePath);
        foreach (string s in lines)
        {
            if (AllContacts.ContainsKey(Convert.ToInt32(s)))
            {
                Recents.Add(AllContacts[Convert.ToInt32(s)]);
            }
            else
            {
                Recents.Add(new User(Convert.ToInt32(s)));
            }
        }

        return Recents;
    }
}

class Favorites : IPhonebook
{
    Dictionary<int,User>AllContacts=new Dictionary<int, User>();

    public Favorites(Contacts c){
        this.AllContacts=c.AllContacts;
    }
    public Collection<User> filterFromFile(string filePath)
    {
        Collection<User> Favorites=new Collection<User>();
        string[] lines = File.ReadAllLines(filePath);
        foreach (string s in lines)
        {
            if (AllContacts.ContainsKey(Convert.ToInt32(s)))
            {
                Favorites.Add(AllContacts[Convert.ToInt32(s)]);
            }
            else
            {
                Favorites.Add(new User(Convert.ToInt32(s)));
            }
        }

        return Favorites;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        string contacts = "/home/dnyaneshwar/C#/PhoneRegistry/Contacts.txt";
        Contacts C = new Contacts(contacts);

        Collection<User>AllContacts=C.getAllContacts();

        Console.WriteLine($"\n\n\t All saved Contacts:");
        foreach(User u in AllContacts){
            Console.WriteLine(u.ToString());
        }

        string recentsFilePath="/home/dnyaneshwar/C#/PhoneRegistry/Favorite.txt";
        Recents r=new Recents(C);

        Collection<User>RecentContacts=r.filterFromFile(recentsFilePath);
        Console.WriteLine($"\n\n\t All recnet contacts:");
        foreach(User u in RecentContacts){
            Console.WriteLine(u.ToString());
        }


        string favoritesFilePath="/home/dnyaneshwar/C#/PhoneRegistry/Recents.txt";
        Favorites f=new Favorites(C);

        Collection<User>favoriteContacts=f.filterFromFile(favoritesFilePath);
        Console.WriteLine($"\n\n\t All favorte contacts:");
        foreach(User u in favoriteContacts){
            Console.WriteLine(u.ToString());
        }





    }
}