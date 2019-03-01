using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AnimalDataContracts.Animal
{
    [DataContract]
    [Serializable]
    public class AnimalType
    {

        [DataMember(IsRequired = true)]
        public int ID { get; set; }

        [DataMember(IsRequired = true)]
        public string TypeName { get; set; }

        [DataMember]
        public string ClassName { get; set; }
    }
}
