using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    List<Dog> list = new List<Dog>();
    Weiner_Dog f = new Weiner_Dog("Neoidk", 59, 59, 59, "Male", 100, "Weiner_Dog");

    static void Main()
    {
        Program p = new Program();
        p.Running();
    }


    private int HandleInput(string message)

    {
        while (true)
        {
            try
            {
                Console.WriteLine(message);
                return int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: Wrong format.", e.GetType().Name);
                Console.WriteLine($"{e.GetType().Name}: Wrong format.");
            }
        }
    }

    private string HandleInput(string message, out string input)
    {
        while (true)
        {
            try
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                return input;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: Wrong format.", e.GetType().Name);
                Console.WriteLine($"{e.GetType().Name}: Wrong format.");
            }
        }
    }

    private void Running()
    {

        bool run = true;

        while (run == true)
        {
            Console.WriteLine("Welcome to my dog registry, type !Help to get the commands so you can start your journey");

            string input = Console.ReadLine();

            if (input == "!Help")
            {
                Console.WriteLine("\n List of commands:\n !Help\n !Add dog\n !Remove dog\n !Print\n !Search\n !Exit\n");
            }

            if (input.ToLower() =="!add dog")
            {
                Add();
            }
            if (input.ToLower() == "!print")
            {
                Print();
            }
            if (input.ToLower() == "!exit")
            {
                Environment.Exit(0);
            }
            if (input.ToLower() == "!search")
            {
                Dog dog = Search();
                if (dog != null)
                {
                    Console.WriteLine(dog.GetAsString());
                    bool running = true;
                    while (running == true)
                    {
                        Console.WriteLine("\n You can now choose if you want to !Edit or !Remove the dog from the registry");
                        input = Console.ReadLine();
                        if (input.ToLower() == "!edit")
                        {
                            int index = 0;
                            for(int i = 0; i < list.Count; i++)
                            {
                                if(list[i] == dog)
                                {
                                    index = i;
                                }
                            }
                            Console.WriteLine("What do you want to edit about the dog?");

                            string choice = Console.ReadLine();

                            switch (choice.ToLower())
                            {
                                case "exit":
                                    running = false;
                                    break;
                                case "name":
                                    HandleInput("What do you want to change it to?", out string name);
                                    list[index].name = name;
                                    break;
                                case "age":
                                    int age = HandleInput("What do you want to change it to?");
                                    list[index].age = age;
                                    break;
                                case "withers":
                                    int withers = HandleInput("What do you want to change it to?");
                                    list[index].withers = withers;
                                    break;
                                case "length":
                                    int length = HandleInput("What do you want to change it to?");
                                    list[index].length = length;
                                    break;
                                case "gender":
                                    HandleInput("What do you want to change it to?", out string gender);
                                    list[index].gender = gender;
                                    break;
                                case "weight":
                                    int weight = HandleInput("What do you want to change it to?");
                                    list[index].weight = weight;
                                    break;
                                case "breed":
                                    HandleInput("What do you want to change it to?", out string breed);
                                    if (breed.ToLower() == "labrador")
                                    {
                                        list[index] = new Labrador(dog.name, dog.age, dog.withers, dog.length, dog.gender, dog.weight, breed);
                                    }

                                    if (breed.ToLower() == "weiner_dog")
                                    {
                                        list[index] = new Weiner_Dog(dog.name, dog.age, dog.withers, dog.length, dog.gender, dog.weight, breed);
                                    }

                                    if (breed.ToLower() == "poodle")
                                    {
                                        list[index] = new Poodle(dog.name, dog.age, dog.withers, dog.length, dog.gender, dog.weight, breed);
                                    }
                                    break;
                            }

                        }
                         else if(input.ToLower() == "!exit")
                        {
                            running = false;
                        }
                        else if (input.ToLower() == "!remove")
                        {
                            int index = 0;
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] == dog)
                                {
                                    index = i;
                                }
                            }
                            list.RemoveAt(index);
                        }

                    }
                }
            }
            else if (input == " "){
                Console.WriteLine("You have entered a invalid command");
            }
        }
    }
    void Add() {

        Console.WriteLine("Please Enter the dogs information in the order that will be presented to you\n");
        HandleInput("Breed: ", out string Breed);
        HandleInput("Name: ", out string Name);
        int Age = HandleInput("Age: ");
        int Length = HandleInput("Length: ");
        int Withers = HandleInput("Withers: ");
        int Weight = HandleInput("Weight: ");
        HandleInput("Gender", out string Gender);

        Dog dog = null;


        if (Breed.ToLower() == "labrador")
        {
            dog = new Labrador(Name.ToLower(), Age, Withers, Length, Gender, Weight, Breed);
        }
        if (Breed.ToLower() == "weiner_dog")
        {
            dog = (new Weiner_Dog(Name, Age, Withers, Length, Gender, Weight, Breed));
        }
        if (Breed.ToLower() == "poodle")
        {
            dog = (new Poodle(Name, Age, Withers, Length, Gender, Weight, Breed));
        }
            

        int count = 0;
        foreach (Dog d in list)
        {
            if (d.Compare(dog))
            {
                count++;
            }
        }
        if (count == 0)
            list.Add(dog);
        else
            Console.WriteLine("The dog you tried to add already exist");
    }
    void Print()
    {
        list.Sort();
        foreach (Dog dog in list)
        {
            Console.WriteLine(dog.GetAsString());
        }
    }
    Dog Search()
    {
        Console.WriteLine("Put in the information about the dog that you want to search for");
        HandleInput("Breed: ", out string Breed);
        List<Dog> SearchDog = new List<Dog>();

        foreach (Dog dog in list)
        {
            if (Breed == dog.breed)
            {
                SearchDog.Add(dog);
            }
        }
        if (SearchDog.Count == 1)
        {
            return SearchDog[0];
        }

        HandleInput("Name: ", out string Name);

        for (int i = SearchDog.Count - 1; i >= 0; i--)
        {
            if (Name != SearchDog[i].name)
            {
                SearchDog.RemoveAt(i);
            }
        }
        if (SearchDog.Count == 1)
        {
            return SearchDog[0];
        }

        int Age = HandleInput("Age: ");

        for (int i = SearchDog.Count - 1; i >= 0; i--)
        {
            if (Age != SearchDog[i].age)
            {
                SearchDog.RemoveAt(i);
            }
        }
        if (SearchDog.Count == 1)
        {
            return SearchDog[0];
        }

        int Length = HandleInput("Length: ");

        for (int i = SearchDog.Count - 1; i >= 0; i--)
        {
            if (Length != SearchDog[i].length)
            {
                SearchDog.RemoveAt(i);
            }
        }
        if (SearchDog.Count == 1)
        {
            return SearchDog[0];
        }

        int Withers = HandleInput("Withers: ");

        for (int i = SearchDog.Count - 1; i >= 0; i--)
        {
            if (Withers != SearchDog[i].length)
            {
                SearchDog.RemoveAt(i);
            }
        }

        if (SearchDog.Count == 1)
        {
            return SearchDog[0];
        }
        int Weight = HandleInput("Weight: ");

        for (int i = SearchDog.Count - 1; i >= 0; i--)
        {
            if (Withers != SearchDog[i].length)
            {
                SearchDog.RemoveAt(i);
            }
        }
        HandleInput("Gender: ", out string Gender);

        for (int i = SearchDog.Count - 1; i >= 0; i--)
        {
            if (Gender != SearchDog[i].gender)
            {
                SearchDog.RemoveAt(i);
            }
        }
        return null;
    }
    
}





