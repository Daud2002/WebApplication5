using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       
        List<int> marks = new List<int> { 60, 45, 75, 30, 55, 90 };

       
        var selectedMarks = from mark in marks
                            where mark > 50 && mark >= 85
                            select mark;

        
        Console.WriteLine("Marks more than 50 and 85 plus:");
        foreach (var mark in selectedMarks)
        {
            Console.WriteLine(mark);
        }
    }
}