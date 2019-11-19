/*
 * Robin:
 * onödiga using statements.
 */
using System;
using System.Collections.Generic;
using System.Text;



class Labrador : Dog
{
    public Labrador(string Name, int Age, int Whithers, int Length, string Gender, int Weight, string Breed) : base(Name, Age, Whithers, Length, Gender, Weight, Breed)
    {

    }
    /*
     * Robin:
     * double taillength = Length - Withers görs 2 gånger.
     */
    public override double GetAsTailLength()
    {
        double taillength = Length - Withers;

        if (Gender == "Male")
        {
            taillength = Length - Withers + 2;
            return taillength;
        }
        else
        {
            taillength = Length - Withers;
            return taillength;
        }

    }
    
}

