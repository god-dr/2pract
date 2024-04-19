using System;
using System.Collections.Generic;

public class RomanToInteger
{
    private Dictionary<char, int> romanToIntMap = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    public int Convert(string s)
    {
        int result = 0;
        int prevValue = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int value = romanToIntMap[s[i]];

            if (value < prevValue)
                result -= value;
            else
                result += value;

            prevValue = value;
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        RomanToInteger converter = new RomanToInteger();

     
        Console.WriteLine("Пример 1: " + converter.Convert("III"));      
        Console.WriteLine("Пример 2: " + converter.Convert("LVIII"));    
        Console.WriteLine("Пример 3: " + converter.Convert("MCMXCIV"));  
    }
}

