using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSoundApp
{
    public class DataAccess
    {
        public List<AnimalEngineService.Animal> GetAllAnimals()
        {
            AnimalEngineService.AnimalEngineServiceClient client = null;

            try
            {
                client = new AnimalEngineService.AnimalEngineServiceClient();
                var response =client.GetAllAnimals();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot connect to AnimalEngineService", ex.InnerException);
            }
            finally
            {
                if (client != null)
                {
                    if (client.State == System.ServiceModel.CommunicationState.Faulted)
                    {
                        client.Abort();
                    }
                    else
                    {
                        client.Close();
                    }
                }
            }
        }
        public List<AnimalEngineService.AnimalType> GetAllAnimalTypes()
        {
            AnimalEngineService.AnimalEngineServiceClient client = null;

            try
            {
                client = new AnimalEngineService.AnimalEngineServiceClient();
                var response = client.GetAllAnimalTypes();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot connect to AnimalEngineService", ex.InnerException);
            }
            finally
            {
                if (client != null)
                {
                    if (client.State == System.ServiceModel.CommunicationState.Faulted)
                    {
                        client.Abort();
                    }
                    else
                    {
                        client.Close();
                    }
                }
            }
        }
        public AnimalEngineService.AnimalType GetAnimalTypeByID(int ID)
        {
            AnimalEngineService.AnimalEngineServiceClient client = null;

            try
            {
                client = new AnimalEngineService.AnimalEngineServiceClient();
                var response = client.GetAnimalTypeByID(ID);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot connect to AnimalEngineService", ex.InnerException);
            }
            finally
            {
                if (client != null)
                {
                    if (client.State == System.ServiceModel.CommunicationState.Faulted)
                    {
                        client.Abort();
                    }
                    else
                    {
                        client.Close();
                    }
                }
            }
        }


    }
}
