
namespace Tajriba;


class Program
{
    static void Main(string[] args)
    {
        var dog = new Animal("Bulduq");
        Console.WriteLine(dog.Name);
    }
}

public class Animal
{
    public string Name { get; set; }
    public Animal(string name)
    {
        Name = name;
    }


    public void Ovoz()
    {
        Console.WriteLine($"{Name} ->  ovoz chiqaryapti ");
    }
}

public class Dog : Animal
{

}