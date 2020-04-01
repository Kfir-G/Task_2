using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1;
            a1 = addNewAnimal();
            a1.printAnimalInfo();
        }
        public static Animal addNewAnimal()
        {
            Console.WriteLine("Insert animal information:code,name,kind,weight,is it water animal");
            return new Animal(uint.Parse(Console.ReadLine()), Console.ReadLine(), char.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
        }
    }
}
