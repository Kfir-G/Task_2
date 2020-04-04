using System;

namespace Task_2
{
    class Program
    {
        //-------Main--------
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[10]; //default array size
            int choice, idx = 0;
            uint tempCode;
            Animal tempAnimal;
            ShowMenu();
            choice = int.Parse(Console.ReadLine());
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        animals[idx] = addNewAnimal();
                        idx++;
                        break;
                    case 2:
                        Console.WriteLine("Insert a code number:");
                        tempCode = uint.Parse(Console.ReadLine());
                        tempAnimal = findAnimalByCode(animals, tempCode);
                        if (tempAnimal == null)
                        {
                            Console.WriteLine("Didn't find");
                            break;
                        }
                       else 
                            tempAnimal.printAnimalInfo();
                        break;
                    case 3:
                        Console.WriteLine("Insert a code number:");
                        tempCode = uint.Parse(Console.ReadLine());
                        if(EditAnimal(animals,tempCode)==true)
                        {
                            tempAnimal = findAnimalByCode(animals, tempCode);
                            tempAnimal=addNewAnimal();               
                        }
                        break;
                    case 4:
                        PrintAnimalByIsSea(animals);
                        break;
                    case 5:
                        PrintAnimalsAbove10AndFemale(animals);
                        break;
                    default:
                        Console.WriteLine("Worng input");
                        break;
                }
                Console.WriteLine("-----------------------------------");
                ShowMenu();
                choice = int.Parse(Console.ReadLine());
            }

        }
        static Animal addNewAnimal()
        { 
            uint code; string name; float weight; char kind, t; bool isSea = false;
            Console.WriteLine("\tAdd new animal:");
            Console.WriteLine("Insert code number:");
            code = uint.Parse(Console.ReadLine());
            Console.WriteLine("Insert name:");
            name = Console.ReadLine();
            Console.WriteLine("Insert weight number:");
            weight = float.Parse(Console.ReadLine());
            Console.WriteLine("The kind animal is Female?-press F\nThe kind animal is Male ? -prees M");
            kind = char.Parse(Console.ReadLine());
            Console.WriteLine("The animal live in water?-press Y\nother - press N");
            t = char.Parse(Console.ReadLine());
            if (t == 'Y')
                isSea = true;
            else
            {
                if (t == 'N') isSea = false;
                else Console.WriteLine("Worng input");
            }
            return new Animal(code, name, kind, weight, isSea);
        }
         static Animal findAnimalByCode(Animal[] arr, uint code)
         {
            if(arr[0]==null)
            {
                Console.WriteLine("There's no animals");
                return null; ;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetCode() == code)
                {
                    arr[i].printAnimalInfo();
                    return arr[i];
                }
            }
            Console.WriteLine("Did NOT find");
            return null; //the code dont match to any animal's code
         }
        static bool EditAnimal(Animal[] arr, uint code)
        {
            if(arr[0]==null)
            {
                Console.WriteLine("There's no animals");
                return false;
            }
            char tempIsSea;
            Animal temp = findAnimalByCode(arr, code);
            if (temp is null)
            {
                Console.WriteLine("The animal does not exist");
                return false;
            }
            Console.WriteLine("Insert animal new information except kind");
            temp.SetCode(uint.Parse(Console.ReadLine()));
            temp.SetName(Console.ReadLine());
            temp.SetWeight(float.Parse(Console.ReadLine()));
            tempIsSea = char.Parse(Console.ReadLine());
            if (tempIsSea == 'Y')
                temp.SetIsSea(true);
            else
                temp.SetIsSea(false);
            return true;
        }
        static void PrintAnimalByIsSea(Animal[] arr)
        {
            if(arr[0]==null)
            {
                Console.WriteLine("There's no animals");
                return;
            }
            string[] temp = new string[arr.Length + 1]; // array of water animal
            int idxTemp = 0, j;
            bool check = true;
            Console.WriteLine("-------------------------------------------------------------\nThe water animals:");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetIsSea() == true)
                {
                    for (j = 0; i <= idxTemp; i++)
                    {
                        if (arr[i].GetName() == temp[j])
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check == true)
                    {
                        arr[i].printAnimalInfo();
                        Console.WriteLine("----------------------------");
                        temp[idxTemp] = arr[i].GetName();
                        idxTemp++;
                    }
                }
                check = true;
            }
        }
        static void PrintAnimalsAbove10AndFemale(Animal[] arr)
        {
            if(arr[0]==null)
            {
                Console.WriteLine("There's no animals");
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetKind() == 'F' && arr[i].GetWeight() > 10.0)
                {
                    Console.WriteLine("---------------------");
                    arr[i].printAnimalInfo();
                }
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("Hello Manager\n*\n*\n*");
            Console.WriteLine("Animal Manager");
            Console.WriteLine("\t1 - Add new Animal"); //1
            Console.WriteLine("\t2 - Find animal by code");//2
            Console.WriteLine("\t3 - Edit existing animal");//3
            Console.WriteLine("\t4 - Print Animals By IsSea");//4
            Console.WriteLine("\t5 - Print Animals Above 10kg and King is Female");//5
            Console.WriteLine("\t6 - Exit");//6
        }
    }
}