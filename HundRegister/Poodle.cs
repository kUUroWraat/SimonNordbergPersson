using System;
using System.Collections.Generic;
using System.Text;



class Poodle : Dog
{
    public Poodle(string Name, int Age, int Whithers, int Length, string Gender, int Weight, string Breed) : base(Name, Age, Whithers, Length, Gender, Weight, Breed)
    {

    }
    public override double GetAsTailLength()
    {
        double taillength = Age - Length;

        if (taillength < 8)
        {
            return 8;
        }
        else
        {
            taillength = Age - Length;
            return taillength;
        }
    }
    
}

