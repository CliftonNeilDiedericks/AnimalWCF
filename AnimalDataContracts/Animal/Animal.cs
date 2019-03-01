using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AnimalDataContracts.Animal
{
    [DataContract]
    [Serializable]
    public class Animal
    {
        [DataMember(IsRequired = true)]
        public int ID { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        public int AnimalTypeID { get; set; }
       
    }
}
