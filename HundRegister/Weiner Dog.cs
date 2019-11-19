/*
 * Robin:
 * onödiga using statements.
 */
using System;
using System.Collections.Generic;
using System.Text;


class Weiner_Dog : Dog
{

    public Weiner_Dog(string Name, int Age, int Whithers, int Length, string Gender, int Weight, string Breed) : base(Name, Age, Whithers, Length, Gender, Weight, Breed)
    {

    }
    public override double GetAsTailLength()
    {
        return Length / 4;
    }
    
}

