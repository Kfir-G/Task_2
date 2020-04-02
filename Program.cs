using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1, a2;
            a1 = addNewAnimal();
            a1.printAnimalInfo();
            a2 = addNewAnimal();
            a2.printAnimalInfo();
            Animal[] arr ={ a1, a2 };
            PrintAnimalByIsSea(arr);
        }
        public static Animal addNewAnimal()
        {
            Console.WriteLine("Insert animal information:code,name,kind,weight,is it water animal");
            return new Animal(uint.Parse(Console.ReadLine()), Console.ReadLine(), char.Parse(Console.ReadLine()), float.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
        }
        public static Animal findAnimalByCode( Animal [] arr, int code)
        {
            for(int i=0; i<arr.Length; i++)
            {
                if(arr[i].GetCode()==code)
                {
                    arr[i].printAnimalInfo();
                    return arr[i];
                }
            }
            return null; //the code dont match to any animal's code
        }
        public static bool EditAnimal(Animal [] arr, int code)
        {
            Animal temp = findAnimalByCode(arr, code);
            if(temp ==null)
            {
                Console.WriteLine("The animal does not exist");
                return false;
            }
            Console.WriteLine("Insert animal new information");
            temp.SetCode(uint.Parse(Console.ReadLine()));
            temp.SetName((Console.ReadLine()));
            temp.SetWeight(float.Parse(Console.ReadLine()));
            temp.SetIsSea(bool.Parse(Console.ReadLine()));
            return true;
        }
        public static void PrintAnimalByIsSea(Animal [] arr)
        {
            string[] temp = new string[arr.Length+1]; // array of water animal
            int idxTemp = 0, j;
            bool check = true;
            Console.WriteLine("-------------------------------------------------------------\nThe water animals:");
            for(int i=0; i < arr.Length; i++)
            {
                if(arr[i].GetIsSea() == true)
                {
                    for(j=0; i<=idxTemp; i++)
                    {
                        if (arr[i].GetName() == temp[j])
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check == true)
                    {
                        Console.WriteLine("----------------------------");
                        arr[i].printAnimalInfo();
                        temp[idxTemp] = arr[i].GetName();
                        idxTemp++;
                    }
                }
                check = true;
            }
        }
    }
}
