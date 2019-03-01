using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Animal.Proxy;
using Animal.ServiceContracts;
using AnimalDataContracts.Animal;

namespace Animal.Engine.Service
{
    public class AnimalEngineService:IAnimalEngineService
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

        #region Animal
        public List<AnimalDataContracts.Animal.Animal> GetAllAnimals()
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.GetAllAnimals();
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return null;
        }

        public AnimalDataContracts.Animal.Animal GetAnimalByID(int ID)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.GetAnimalByID(ID);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return null;
        }

        public AnimalDataContracts.Animal.Animal InsertAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.InsertAnimal(request);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return null;
        }

        public bool UpdateAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.UpdateAnimal(request);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return false;
        }

        public bool DeleteAnimal(AnimalDataContracts.Animal.Animal request)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.DeleteAnimal(request);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return false;
        }

        public List<AnimalType> GetAllAnimalTypes()
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.GetAllAnimalTypes();
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return null;
        }

        public AnimalType GetAnimalTypeByID(int ID)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.GetAnimalTypeByID(ID);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return null;
        }

        public AnimalType InsertAnimalType(AnimalType request)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.InsertAnimalType(request);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return null;
        }

        public bool UpdateAnimalType(AnimalType request)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.UpdateAnimalType(request);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return false;
        }

        public bool DeleteAnimalType(AnimalType request)
        {
            try
            {
                using (AnimalResourceProxy proxy = new AnimalResourceProxy())
                {
                    return proxy.DeleteAnimalType(request);
                }
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            return false;
        }
        #endregion


    }
}
