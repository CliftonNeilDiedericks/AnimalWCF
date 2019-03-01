using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AnimalDataContracts.Animal;

namespace Animal.ServiceContracts
{
    [ServiceContract]
    public interface IAnimalResourceService
    {
        #region Animal
        [OperationContract]
        List<AnimalDataContracts.Animal.Animal> GetAllAnimals();
        [OperationContract]
        AnimalDataContracts.Animal.Animal GetAnimalByID(int ID);
        [OperationContract]
        AnimalDataContracts.Animal.Animal InsertAnimal(AnimalDataContracts.Animal.Animal request);
        [OperationContract]
        bool UpdateAnimal(AnimalDataContracts.Animal.Animal request);
        [OperationContract]
        bool DeleteAnimal(AnimalDataContracts.Animal.Animal request);


        #endregion

        #region AnimalType
        [OperationContract]
        List<AnimalDataContracts.Animal.AnimalType> GetAllAnimalTypes();
        [OperationContract]
        AnimalDataContracts.Animal.AnimalType GetAnimalTypeByID(int ID);
        [OperationContract]
        AnimalDataContracts.Animal.AnimalType InsertAnimalType(AnimalDataContracts.Animal.AnimalType request);
        [OperationContract]
        bool UpdateAnimalType(AnimalDataContracts.Animal.AnimalType request);
        [OperationContract]
        bool DeleteAnimalType(AnimalDataContracts.Animal.AnimalType request);
       

        #endregion

    }
}
