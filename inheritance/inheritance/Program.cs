using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorials
{
    class Program
    {
        class Animal
        {
            public string name;
            public int maxAge;

            public void MakeNoise()
            {
                Console.WriteLine("animal noises");
            }
        }

        class Dog : Animal
        {
            public string race;
        }
        static void Main(string[] args)
        {
            Animal newAnimal = new Animal();
            newAnimal.MakeNoise();

            Dog newDog = new Dog();
            newDog.name = "fido";
            newDog.maxAge = 12;
            newDog.race = "retriever";
            newDog.MakeNoise();
            Console.ReadKey();
            
        }
    }
}