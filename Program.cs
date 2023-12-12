using System;
using System.Collections;

class Program
{
    private static Hashtable charsToInts = new Hashtable()
    {
        {'A', 1 },
        {'B', 2}, 
        {'C', 3},
        {'D', 4},
        {'E', 5},
        {'F', 6},
        {'G', 7},
        {'H', 8},
        {'I', 9},
        {'J',10},
        {'K', 11},
        {'L', 12},
        {'M', 13},
        {'N', 14},
        {'O', 15},
        {'P', 16},
        {'Q', 17},
        {'R', 18},
        {'S', 19},
        {'T', 20},
        {'U', 21},
        {'V', 22},
        {'W', 23},
        {'X', 24},
        {'Y', 25},
        {'Z', 26},
    };

    public static void Main()
    {
        string filename = "names.txt";
        List<string> names = readNamesFromFile(filename);
        int total = calculateTotalValue(names);
        Console.WriteLine(total);
    }

    public static List<string> readNamesFromFile(string filename)
    {
        List<string> names = new List<string>();
        try
        {
            using StreamReader sr = new(filename);
            string[] listOfNames = sr.ReadToEnd().Split(',');
            sr.Close();
            for (int i = 0; i < listOfNames.Length; i++)
            {
                listOfNames[i] = listOfNames[i].Replace("\"", string.Empty);
                names.Add(listOfNames[i]); // add fixed element to list from array
            }
            names.Sort();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return names;
    }

    public static int calculateTotalValue(List<string> names)
    {
        int total = 0;
        int index = 1; // to offset by 1
        foreach(string name in names)
        {
            total += calculateNameValue(name, index);
            index++;
        }
        return total;
    }

    public static int calculateNameValue(string name, int index)
    {
        int total = 0;
        foreach (char character in name)
        {
            if (charsToInts.ContainsKey(character))
            {
                total += (int)charsToInts[character];
            } 
            else
            {
                Console.WriteLine("Error, not an alphabetic character");
            }
        }
        return total * index;
    }
}
