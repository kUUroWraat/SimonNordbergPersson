/*
 * Robin:
 * onödiga using statements.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    List<Dog> list = new List<Dog>();
    /*
     * Robin:
     * Variabel som inte används.
     */
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

    /*
     * Robin:
     * Tror inte det finns några exceptions som kan hända här, så while loopen och
     * try-catch satsen är förmodligen onödiga.
     */
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
        /*
         * Robin:
         * Boolen run används aldrig, förutom i while(run == true)
         */
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
                /*
                * Robin:
                * Hade velat bryta ur allt som finns här till en egen metod för att öka läsbarheten.
                * Även det som händer när man skriver !Edit och !Remove borde kanske brytas ut till
                * egna metoder. Metoden är väldigt lång. vilket gör den svår att följa.
                */
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
                                    /*
                                     * Robin:
                                     * intressant lösning. Man får dock ingen feedback om man skriver in fel.
                                     */
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
                        /*
                         * Robin:
                         * Även detta borde kunna brytas ut.
                         */
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
        /*
         * Robin:
         * Det finns inget som begränsar vad man kan skriva in för kön och ras. Detta leder till en 
         * rad olika problem, både här och i search. Du hade kanske behövt implementera en metod för
         * att kontrollera värdet på input så att man inte kan skriva in t.ex. 'schnauser' eller 
         * 'hund123'. Dessutom så finns det inget som förhindrar att null läggs in i listan om man skriver fel, 
         * vilket leder till att programmet krashar så fort man försöker skapa en till hund eller
         * söka efter en hund.
         */

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
        /*
         * Robin:
         * Man skriver in vikten, men metoden kollar mankhöjden.
         */
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


/*
 * Robin:
 * Det finns ett par logiska problem som leder till att programmet väldigt lätt krashar. Detta leder 
 * till att programmet inte är robust, och därmed inte användarvänligt. Det finns inget som säger
 * till användaren vad det finns för raser, och om man skriver fel så läggs ett null-värde in i 
 * listan, vilket leder till stora problem. Det finns inte heller några begränsningar gällande kön.
 * 
 * Koden i sig hade behövt ses över för att uppnå bättre läsbarhet. Framförallt så hade Running() 
 * kunnat brytas upp i mindre delar för att göra den läsbar. En tydligare uppdelning hade kanske
 * hjälp vid felsökning för att lättare identifiera problem. DU hade kanske behövt en extra dag för
 * att felsöka koden.
 * 
 * Koden är i övrigt relativt konsekvent och tydligt namngiven. En extra tanke hade kunnat ägnas åt
 * att se över var du lägger in tomma rader, då det inte verkar finnas något direkt mönster i hur du 
 * tänkt där. 
 * 
 * Dessa problem gör det svårt att sätta en godkänt överlag, även om den uppnår ett högre betyg
 * i vissa kunskapskrav.
 */


