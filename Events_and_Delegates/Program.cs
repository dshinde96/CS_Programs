
namespace Events_and_Delegates;

class TempEventArgs:EventArgs{
    public double CurrentTemp{get;init;}

    public TempEventArgs(double curretnTemp){
        CurrentTemp=curretnTemp;
    }
}

// public delegate void CriticalTempReachedDel(Object s,double t);

class TempSensor{
    private double _temp;


    // public CriticalTempReachedDel CriticalTempReached;

    //Instead of defining the delegate and then declaring its instance varible, we can direclt declare the event with eventhandler
    // public event EventHandler<double>CriticalTempReached;
    public event EventHandler<TempEventArgs>CriticalTempReached;
    public double Temp{
        get=>_temp;
        set{
            _temp=value;
            if(value>80){
                //Invoke events only if there are subscribers
                CriticalTempReached?.Invoke(this,new TempEventArgs(value));
            }
            else{
                Console.WriteLine("Normal Temp");
            }
        }
    }

    public void notifyAll(Object sender,TempEventArgs t){
        Console.WriteLine($"\n\nAlert: Critical temp reached:{t.CurrentTemp}");
    }
}

class CoolingSys{
    public void ActivateCoolingSystem(Object sender,TempEventArgs t){
        Console.WriteLine($"Activating cooling sys");
    }
}
class Program{
    public static void Main(string[] args){
        TempSensor s=new TempSensor();
        CoolingSys c=new CoolingSys();

        s.CriticalTempReached+=s.notifyAll;
        s.CriticalTempReached+=c.ActivateCoolingSystem;  //When an Critical temp reached event is fired, it will execute the method call ActivateCoolingSys

        while(true){
            s.Temp=Convert.ToInt32(Console.ReadLine());
        }

    }
}






// class Program{

//     public delegate void workPerformed(int houres,string worktype);
//     public static void Main(string[] args){
//         workPerformed del=new workPerformed(workEventhandler);
//         // del(10,"Dancing");
//         del.Invoke(10,"Dancing");
//     }

//     public static void workEventhandler(int houres,string worktype){
//         Console.WriteLine($"{worktype} is performed for ${houres} hrs.");
//     }
// }