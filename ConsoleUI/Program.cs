using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static bool ValidateTextFile(string filePath)
        {
            //does the file exist?
            if (File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} is present proceeding with validation" );
            }
            else
            {
                Console.WriteLine($"File {filePath} not found, exiting");
                return false;
            }

            //Does each line of the text file have 3 sections comma separated?
            List<string> lines = File.ReadAllLines(filePath).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] entries = lines[i].Split(',');
                if (entries.Length != 3)
                {
                    Console.WriteLine($"{entries.Length}");
                    Console.WriteLine($"Problem with input file {filePath} row {i}");
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            //Set location of file we want to read
            string filePath = @"C:\Users\Jon\Documents\Projects\iamtimcorey\testfile.txt";

            if (!(ValidateTextFile(filePath)))
            {
                Console.WriteLine("Validation failed exiting the program");
                Console.ReadLine();
                Environment.Exit(1);
            }

            //create object people of type list using Person class
            List<Person> people = new List<Person>();

            //Create an object lines of type list, where each line is a line from the file 
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                //we assume each line is split up by comma
                string[] entries = line.Split(',');

                //extend the person class for a new person
                Person newPerson = new Person();

                //add the values from the list entries to the appropriate variable in the person class
                newPerson.FirstName = entries[0];
                newPerson.LastName = entries[1];
                newPerson.URL = entries[2];

                //add the newPerson object to the list people
                people.Add(newPerson);
            }

            Console.WriteLine("Read from text file");
            foreach (var person in people)
            {
                Console.WriteLine($"{ person.FirstName } {person.LastName }: {person.URL}");
            }

            people.Add(new Person { FirstName = "Luke", LastName = "Barritt", URL = "www.allah.com" });

            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add($"{ person.FirstName },{ person.LastName },{ person.URL }");
            }

            Console.WriteLine("Writing to text file");

            File.WriteAllLines(filePath, output);

            Console.WriteLine("All entries written");

            Console.ReadLine();
        }
    }
}
