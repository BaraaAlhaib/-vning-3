using System;
using System.Collections.Generic;
using System.Net.Http.Headers;


abstract class UserError
{

    public abstract string UEMessage();
}


class NumericInputError : UserError
{

    public override string UEMessage()
    {
        return "You tried to use a numeric input in a text only field. This fired an error!";
    }
}


class TextInputError : UserError
{

    public override string UEMessage()
    {
        return "You tried to use a text input in a numeric only field. This fired an error!";
    }
}


class Person
{
    private int age;
    private string fname;
    private string lname;
    private double height;
    private double weight;


    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("Invalid age");
            age = value;
        }
    }

    public string FName
    {
        get { return fname; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 10)
                throw new ArgumentException("Invalid first name");
            fname = value;
        }
    }

    public string LName
    {
        get { return lname; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 15)
                throw new ArgumentException("Invalid last name");
            lname = value;
        }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }
}


class PersonHandler
{

    public void SetAge(Person pers, int age)
    {
        pers.Age = age;
    }


    public Person CreatePerson(int age, string fname, string lname, double height, double weight)
    {
        var person = new Person();
        person.Age = age;
        person.FName = fname;
        person.LName = lname;
        person.Height = height;
        person.Weight = weight;
        return person;
    }

}

// 3.3 Arv
abstract class Animal
{

    public string Name { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }


    public Animal(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
    }


    public abstract void DoSound();

    public virtual string Stats()
    {
        return $"Name: {Name}, Weight: {Weight}, Age: {Age}";
    }
}


class Horse : Animal
{
    public string Color { get; set; }


    public Horse(string name, double weight, int age, string color) : base(name, weight, age)
    {
        Color = color;
    }


    public override void DoSound()
    {
        Console.WriteLine("Neigh!");
    }
}

class Dog : Animal
{
    public string Breed { get; set; }


    public Dog(string name, double weight, int age, string breed) : base(name, weight, age)
    {
        Breed = breed;
    }


    public override void DoSound()
    {
        Console.WriteLine("Woof!");
    }
    internal bool NewMethod()
    {

        throw new NotImplementedException();
    }
}


class Hedgehog : Animal
{
    public int NrOfSpikes { get; set; }


    public Hedgehog(string name, double weight, int age, int nrOfSpikes) : base(name, weight, age)
    {
        NrOfSpikes = nrOfSpikes;
    }


    public override void DoSound()
    {
        Console.WriteLine("Squeak!");
    }
}

class Worm : Animal
{
    public bool IsPoisonous { get; set; }


    public Worm(string name, double weight, int age, bool isPoisonous) : base(name, weight, age)
    {
        IsPoisonous = isPoisonous;
    }


    public override void DoSound()
    {
        Console.WriteLine("...");
    }
}

class Bird : Animal
{
    public double WingSpan { get; set; }


    public Bird(string name, double weight, int age, double wingSpan) : base(name, weight, age)
    {
        WingSpan = wingSpan;
    }


    public override void DoSound()
    {
        Console.WriteLine("Chirp chirp!");
    }
}


class Pelican : Bird
{
    public bool CanDive { get; set; }


    public Pelican(string name, double weight, int age, double wingSpan, bool canDive) : base(name, weight, age, wingSpan)
    {
        CanDive = canDive;
    }
}

class Flamingo : Bird
{
    public string Color { get; set; }


    public Flamingo(string name, double weight, int age, double wingSpan, string color) : base(name, weight, age, wingSpan)
    {
        Color = color;
    }
}

class Swan : Bird
{
    public bool IsMajestic { get; set; }


    public Swan(string name, double weight, int age, double wingSpan, bool isMajestic) : base(name, weight, age, wingSpan)
    {
        IsMajestic = isMajestic;
    }
}

interface IPerson
{
    void Talk();
}


class Wolfman : Wolf, IPerson
{
    public Wolfman(string name, double weight, int age) : base(name, weight, age)
    {
    }


    public void Talk()
    {
        Console.WriteLine("I am a Wolfman!");
    }
}


class Wolf : Animal
{

    public Wolf(string name, double weight, int age) : base(name, weight, age)
    {
    }

    public override void DoSound()
    {
        Console.WriteLine("Howl!");
    }
}

class Program
{
    static void Main(string[] args)
    {

        List<UserError> errors = new List<UserError>
        {
            new NumericInputError(),
            new TextInputError()
        };


        foreach (var error in errors)
        {
            Console.WriteLine(error.UEMessage());
        }


        var personHandler = new PersonHandler();

        var person1 = personHandler.CreatePerson(30, "John", "Doe", 180, 75);
        var person2 = personHandler.CreatePerson(25, "Jane", "Smith", 165, 60);



        // 3.3 Arv
 
        List<Animal> animals = new List<Animal>
        {
            new Horse("Spirit", 500, 5, "Brown"),
            new Dog("Buddy", 25, 3, "Golden Retriever"),
            new Hedgehog("Sonic", 0.5, 2, 100),
            new Worm("Slimey", 0.1, 1, true),
            new Bird("Tweety", 0.2, 1, 0.3),
            new Pelican("Percy", 4, 4, 1.5, true),
            new Flamingo("Fiona", 3, 3, 1, "Pink"),
            new Swan("Sam", 6, 5, 1.2, true),
            new Wolfman("Wolfy", 80, 30)
        };

 
        foreach (var animal in animals)
        {
            Console.WriteLine($"Name: {animal.Name}, Weight: {animal.Weight}, Age: {animal.Age}");
            animal.DoSound();

        
            if (animal is IPerson person)
            {
                person.Talk();
            }

          
            Console.WriteLine(animal.Stats());
        }

    
        foreach (var animal in animals)
        {
            if (animal is Dog)
            {
                Console.WriteLine(animal.Stats());
            }
        }

   
        foreach (var animal in animals)
        {
            if (animal is Dog dog)
            {
                Console.WriteLine(dog.NewMethod());
            }
        }
    }
}