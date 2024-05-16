using System;
using System.Collections.Generic;
using System.Linq; // WE NEED THIS LIBRARY!
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    //----------------------------------------------------------------------------
    class person
    {
        public string Name;
        public int age;
        public string subject;

        public person(string N, int A, string S)
        {
            Name = N;
            age = A;
            subject = S;
        }
        public void display()
        {
            Console.WriteLine($"{Name} ({age}) : {subject}");
        }
    }
    //-------------------------------------------------------------------------
    class Program
    {
        static int[] Numbers = { 3, 5, 6, 3, 8, 45, 56, 33, 14 };
        static List<person> people = new List<person>();

        static void setup()
        {

            people.Add(new person("Fred", 18, "Maths"));
            people.Add(new person("Mary", 20, "Maths"));
            people.Add(new person("Ahmed", 19, "Comp Sci"));
            people.Add(new person("Tabitha", 17, "Comp Sci"));
            people.Add(new person("Conrad", 17, "Comp Sci"));
            people.Add(new person("Amelia", 18, "Comp Sci"));
            people.Add(new person("Azra", 18, "Maths"));

        }
        static void Main(string[] args)
        {
            setup();
            // Task 1 - Enter a number and make a List of numbers greater than this number in order.
            Console.WriteLine("Original Numbers:");
            DisplayResults(Numbers.ToList());

            Console.Write("Enter Number:");
            int N = int.Parse(Console.ReadLine());
            Console.Write("TASK 1 Numbers over {0} (FOR LOOP) : ", N);

            //
            //OLD SKOOL - USE A FOR LOOP
            //
            List<int> BigUns = new List<int>();
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] > N)
                {
                    BigUns.Add(Numbers[i]);
                }
            }


            DisplayResults(BigUns);



            //----------------------------------------------------------

            //
            //LAMBDA EXPRESSION
            //

            List<int> BigNumbers = Numbers.Where(o => o > N).OrderBy(o => o).ToList(); //o represents a particular object in the collection
            Console.Write($"TASK 1 Numbers over {N} (LAMBDA) : ", N);
            DisplayResults(BigNumbers);

            //-------------------------------------------------------------





            //Try to write Lambdas to....
            //Use the cheat sheet and the website https://linqsamples.com/ provided to help you

            //TASK 2 - Output how many even numbers are in the array
            Console.Write("TASK 2 - Number of Even Numbers : ");
            int evennum = Numbers.Count(o => o % 2 == 0);
            Console.WriteLine(evennum);

            //TASK 3 - Output the average of the numbers in the array that are above the number entered above.
            Console.Write("TASK 3 - Average Above number entered :");
            double avg = BigNumbers.Average();
            Console.WriteLine(avg);
            //TASK 4 - Output the biggest number in the array numbers (hint: order the list then use first or last)
            Console.Write("TASK 4 - Biggest Number is: ");
            int GreatNum = Numbers.Max();
            Console.WriteLine(GreatNum);
            Console.WriteLine("\nSTUDENTS");
            DisplayPeople(people);
            //TASK 5 - List the names of everyone in the persons list who is 18 or over in aplhabetical order.
            Console.WriteLine("TASK 5 -Names over 18 : ");
            DisplayPeople(people.Where(x => x.age >= 18).OrderBy(x => x.Name).ToList());
            
            // TASK 6 - Output the number of people doing Maths
            Console.WriteLine("TASK 6 - Number of people doing maths : " + people.Where(y => y.subject == "Maths").Count());


            // TASK 7 - Output the avg age of computer science students
            Console.WriteLine("TASK 7 - The average age of Computer science students : " + people.Where(z => z.subject == "Comp Sci").Average(z => z.age));
            
            
            // TASK 8 - Difficult! Group and Output students  in each type of group
            Console.WriteLine("TASK 8 - Classes  : ");
            
            Console.ReadLine();

        }





        static void DisplayResults(List<int> Results)
        {
            foreach (int item in Results)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
        }

        static void DisplayPeople(List<person> Results)
        {
            foreach (person p in Results)
            {
                p.display();
            }
            Console.WriteLine();
        }
    }
}