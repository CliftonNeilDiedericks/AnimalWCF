using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSoundApp
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                DataAccess da = new DataAccess();
                var animals = da.GetAllAnimals();
                if (animals != null&&animals.Count>0)
                {
                    foreach (var animal in animals)
                    {
                        var AnimalType = da.GetAnimalTypeByID(animal.AnimalTypeID);

                        PrintAnimals(animal.Name, AnimalType.TypeName);


                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Console.ReadLine();
            }
        }
        
        private static void PrintAnimals(string Name,string AnimalType)
        {
            switch (AnimalType)
            {
                case "Dog":
                    DogSound dogsound = new DogSound();
                    Console.WriteLine(String.Format("Name: {0} Type: {1} Sound: {2}", Name, AnimalType, dogsound.MakeSound(Name)));
                    Console.ReadLine();
                    break;
                case "Cat":
                    CatSound catsound = new CatSound();
                    Console.WriteLine(String.Format("Name: {0} Type: {1} Sound: {2}", Name, AnimalType, catsound.MakeSound(Name)));
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
    }
}
