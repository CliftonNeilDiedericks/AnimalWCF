using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Animal.ResourceAccess.Animal;
using Animal.ServiceContracts;
using AnimalDataContracts.Animal;


namespace Animal.ResourceAccess.Service
{
    public class AnimalResourceAccessService:IAnimalResourceService
    {
        #region HandleException
        System.Diagnostics.EventLog eventLog1;

        private void HandleException(Exception ex)
        {
            try
            {
                eventLog1 = new System.Diagnostics.EventLog();
                CreateEventLog();
                string className = "", methodName = "";

                StackTrace st = new StackTrace();
                if (st.FrameCount > 1)
                {
                    StackFrame sf = st.GetFrame(1);
                    className = sf.GetMethod().DeclaringType.Name;
                    methodName = sf.GetMethod().Name;
                }

                eventLog1.WriteEntry(string.Format("The following error occurred: \r\n\r\nSummary:\r\n{0}\r\n\r\nDetail:\r\n{1}" +
                    "\r\n\r\nMethod:\r\n{2}\r\n\r\nClass:\r\n{3}", ex.Message, ex.ToString(), methodName, className), System.Diagnostics.EventLogEntryType.Warning);

                throw new FaultException<ExceptionDetail>(new ExceptionDetail(ex), ex.Message);
            }
            catch { }
        }

        private void CreateEventLog()
        {
            if (!System.Diagnostics.EventLog.SourceExists("AnimalWCF"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "AnimalWCF", "AnimalWCFLog");
            }
            eventLog1.Source = "AnimalWCF";
            eventLog1.Log = "AnimalWCFLog";
        }


        #endregion

        #region DAPPER Animal
        public List<AnimalDataContracts.Animal.Animal> GetAllAnimals()
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.GetAllAnimals();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return null;
        }

        public AnimalDataContracts.Animal.Animal GetAnimalByID(int ID)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.GetAnimalByID(ID);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return null;
        }

        public AnimalDataContracts.Animal.Animal InsertAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.InsertAnimal(request);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return null;
        }

        public bool UpdateAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.UpdateAnimal(request);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return false;
        }

        public bool DeleteAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.DeleteAnimal(request);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return false;
        }

        public List<AnimalType> GetAllAnimalTypes()
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.GetAllAnimalTypes();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return null;
        }
    

        public AnimalType GetAnimalTypeByID(int ID)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.GetAnimalTypeByID(ID);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return null;
        }

        public AnimalType InsertAnimalType(AnimalType request)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.InsertAnimalType(request);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return null;
        }

        public bool UpdateAnimalType(AnimalType request)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.UpdateAnimalType(request);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return false;
        }

        public bool DeleteAnimalType(AnimalType request)
        {
            try
            {
                AnimalDapperRepository repo = new AnimalDapperRepository(Constants.AnimalDB);
                return repo.DeleteAnimalType(request);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return false;
        }
        #endregion

        
    }
}
