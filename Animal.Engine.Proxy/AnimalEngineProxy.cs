using Animal.ServiceContracts;
using AnimalDataContracts.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Engine.Proxy
{
    public class AnimalEngineProxy : ClientBase<IAnimalEngineService>, IAnimalEngineService, IDisposable
    {
        public bool DeleteAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                return Channel.DeleteAnimal(request);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public bool DeleteAnimalType(AnimalType request)
        {
            try
            {
                return Channel.DeleteAnimalType(request);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public List<AnimalDataContracts.Animal.Animal> GetAllAnimals()
        {
            try
            {
                return Channel.GetAllAnimals();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public List<AnimalType> GetAllAnimalTypes()
        {
            try
            {
                return Channel.GetAllAnimalTypes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public AnimalDataContracts.Animal.Animal GetAnimalByID(int ID)
        {
            try
            {
                return Channel.GetAnimalByID(ID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public AnimalType GetAnimalTypeByID(int ID)
        {
            try
            {
                return Channel.GetAnimalTypeByID(ID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public AnimalDataContracts.Animal.Animal InsertAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                return Channel.InsertAnimal(request);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public AnimalType InsertAnimalType(AnimalType request)
        {
            try
            {
                return Channel.InsertAnimalType(request);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public bool UpdateAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                return Channel.UpdateAnimal(request);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public bool UpdateAnimalType(AnimalType request)
        {
            try
            {
                return Channel.UpdateAnimalType(request);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
