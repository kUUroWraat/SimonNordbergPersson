/*
 * Robin:
 * Onödiga using statements.
 */
using System;
using System.Collections.Generic;
using System.Text;



abstract class Dog : IComparable<Dog>
{
    protected string Name;
    protected int Age;
    protected int Withers;
    protected int Length;
    protected string Gender;
    protected int Weight;
    protected string Breed;

    /*
     * Robin:
     * Varför finns Breed som en variabel här? Är inte subklasserna i sig raserna?
     */
    public Dog(string Name, int Age, int withers, int Length, string Gender, int Weight, string Breed)
    {
        
        this.Name = Name;
        this.Age = Age;
        this.Withers = withers;
        this.Length = Length;
        this.Gender = Gender;
        this.Weight = Weight;
        this.Breed = Breed;
    }

    public abstract double GetAsTailLength();
    
    public virtual string GetAsString()
    {
        return "Name: " + FirstCharToUpper(Name) + "\n" + "Age: " + Age + "\n" +
        "Withers: " + Withers + "\n" + "Length: " + Length + "\n"
        + "Gender: " + Gender + "\n" + "Weight: " + Weight + "\n" + "Breed: "
        + Breed + "\n" +"TailLength: " + GetAsTailLength() + " cm" + "\n";
    }
    public bool Compare(Dog d)                                       // Här har jag repeterande if satser för att kolla alla 
    {
        if(Name != d.Name)
        
            return false;
        if(Breed != d.Breed)
            return false;
        if (Age != d.Age)
            return false;
        if (Length != d.Length)
            return false;
        if (Withers != d.Withers)
            return false;
        if (Weight != d.Weight)
            return false;

        return true;
    }

    private string FirstCharToUpper(string str)
    {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }

    public int CompareTo(Dog d)
    {
        return this.Name.CompareTo(d.Name);
    }
    public string breed
    {
        get
        {
            return Breed;
        }
        set
        {
            Breed = value;
        }
    }
    public string name
    {
        get
        {
            return Name;

        }
        set
        {
            Name = value;
        }
    }
    public int age
    {
        get
        {
            return Age;

        }
        set
        {
            Age = value;
        }
    }
    public int length
    {
        get
        {
            return Length;

        }
        set
        {
            Length = value;
        }
    }
    public int withers
    {
        get
        {
            return Withers;

        }
        set
        {
            Withers = value;
        }
    }
    public int weight
    {
        get
        {
            return Weight;

        }
        set
        {
            Weight = value;
        }
    }
    public string gender
    {
        get
        {
            return Gender;

        }
        set
        {
            Gender = value;
        }
    }
}

