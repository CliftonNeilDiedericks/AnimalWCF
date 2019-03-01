using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSoundApp
{
    public class CatSound : IAnimalSound
    {
    
        public string MakeSound(string name)
        {
            return String.Format("{0} says MEEEEOOOOOOWWW.", name);
        }
    }
}
