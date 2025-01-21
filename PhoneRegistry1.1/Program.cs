
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
    public Collection<User> fileterFromDB();
}

class Contacts:IPhonebook
{

     private Dictionary<int, User> _allContacts = new Dictionary<int, User>();

    //read contacts from file
    public Contacts(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string s in lines)
        {
            string[] contacts = s.Split(" ");
            _allContacts[Convert.ToInt32(contacts[2])] = new User(Convert.ToInt32(contacts[2]), $"{contacts[0]} {contacts[1]}");
        }
    }

    public Collection<User> fileterFromDB()
    {
        throw new NotImplementedException();
    }

    public Collection<User> filterFromFile(string filePath)
    {
        Collection<User> Contacts=new Collection<User>();
        string[] lines = File.ReadAllLines(filePath);
        foreach (string s in lines)
        {
            if (_allContacts.ContainsKey(Convert.ToInt32(s)))
            {
                Contacts.Add(_allContacts[Convert.ToInt32(s)]);
            }
            else
            {
                Contacts.Add(new User(Convert.ToInt32(s)));
            }
        }

        return Contacts;
    }

    public Collection<User> getAllContacts(){
        Collection<User> c=new Collection<User>();

        foreach(KeyValuePair<int,User> k in _allContacts){
            c.Add(k.Value);
        }
        return c;
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
        // Recents r=new Recents(C);

        Collection<User>RecentContacts=C.filterFromFile(recentsFilePath);
        Console.WriteLine($"\n\n\t All recnet contacts:");
        foreach(User u in RecentContacts){
            Console.WriteLine(u.ToString());
        }


        string favoritesFilePath="/home/dnyaneshwar/C#/PhoneRegistry/Recents.txt";
        // Favorites f=new Favorites(C);

        Collection<User>favoriteContacts=C.filterFromFile(favoritesFilePath);
        Console.WriteLine($"\n\n\t All favorte contacts:");
        foreach(User u in favoriteContacts){
            Console.WriteLine(u.ToString());
        }
    }
}