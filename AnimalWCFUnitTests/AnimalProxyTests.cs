using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ServiceModel;
using Animal.Engine.Service;
using Animal.Proxy;
using Animal.ResourceAccess.Service;
using Animal.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceModelEx;
using System.Linq;
using Animal.Engine.Proxy;

namespace AnimalWCFUnitTests
{
    [TestClass]
    public class AnimalProxyTests
    {
        public AnimalProxyTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        static ServiceHost host = null;
        static ServiceHost engineHost = null;
        static DateTime testStartTime = DateTime.Now;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            host = new ServiceHost<AnimalResourceAccessService>();
            engineHost = new ServiceHost<AnimalEngineService>();

            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            host.Open();
            engineHost.Open();

            //TestDataUtils.GetTestDates(out START_DATE, out END_DATE);
            //TEST_USER = TestDataUtils.GetTestUser();
            testStartTime = DateTime.Now;
        }
        [TestMethod()]
        [Priority(0)]
        public void TestMethod1_GetAllAnimalsTest()
        {
            AnimalEngineProxy proxy = new AnimalEngineProxy();

            List<AnimalDataContracts.Animal.Animal> Animals = new List<AnimalDataContracts.Animal.Animal>();
            try
            {
                Animals = proxy.GetAllAnimals();

                Assert.IsTrue(Animals != null && Animals.Count > 0);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(1)]
        public void TestMethod2_GetAnimalByID()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();

            AnimalDataContracts.Animal.Animal Animal = new AnimalDataContracts.Animal.Animal();
            int ID = 1;
            try
            {
                Animal = proxy.GetAnimalByID(ID);

                Assert.IsTrue(Animal != null && Animal.ID > 0);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(2)]
        public void TestMethod3_InsertAnimal()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();

            AnimalDataContracts.Animal.Animal _Animal = new AnimalDataContracts.Animal.Animal();
            var Animals = proxy.GetAllAnimals();

            var result = Animals.Where(x => x.Name == "Rainbow Dash").FirstOrDefault();
            if (result != null && result.ID > 0)
            {

                var result2 = proxy.DeleteAnimal(result);

            }
            _Animal.Name = "Rainbow Dash";
            _Animal.AnimalTypeID = 3;
            _Animal.ID = 0;
            try
            {

                _Animal = proxy.InsertAnimal(_Animal);

                Assert.IsTrue(_Animal != null && _Animal.ID> 0);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(3)]
        public void TestMethod4_UpdateAnimal()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();           
            AnimalDataContracts.Animal.Animal Animal = new AnimalDataContracts.Animal.Animal();
            var Animals = proxy.GetAllAnimals();

            Animal = Animals.Where(x => x.Name == "Rainbow Dash").FirstOrDefault();
            Animal.Name = "Fluttershy";
            Animal.AnimalTypeID = 3;

            try
            {
                var result = proxy.UpdateAnimal(Animal);

                Assert.IsTrue(result);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(4)]
        public void TestMethod5_DeleteAnimal()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();

            AnimalDataContracts.Animal.Animal Animal = new AnimalDataContracts.Animal.Animal();
            var Animals = proxy.GetAllAnimals();

            Animal = Animals.Where(x => x.Name == "Fluttershy").FirstOrDefault();
            try
            {
                var result = proxy.DeleteAnimal(Animal);

                Assert.IsTrue(result);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(5)]
        public void TestMethod6_GetAllAnimalTypes()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();

            List<AnimalDataContracts.Animal.AnimalType> AnimalTypes = new List<AnimalDataContracts.Animal.AnimalType>();
            try
            {
                AnimalTypes = proxy.GetAllAnimalTypes();

                Assert.IsTrue(AnimalTypes != null && AnimalTypes.Count > 0);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }

        [TestMethod()]
        [Priority(6)]
        public void TestMethod7_GetAnimalTypeByID()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();

            AnimalDataContracts.Animal.AnimalType AnimalType = new AnimalDataContracts.Animal.AnimalType();
            int ID = 1;
            try
            {
                AnimalType = proxy.GetAnimalTypeByID(ID);

                Assert.IsTrue(AnimalType != null && AnimalType.ID > 0);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(7)]
        public void TestMethod8_InsertAnimalType()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();

            AnimalDataContracts.Animal.AnimalType AnimalType = new AnimalDataContracts.Animal.AnimalType();
            var AnimalTypes = proxy.GetAllAnimalTypes();
            var result = AnimalTypes.Where(x => x.TypeName == "Snake").FirstOrDefault();
            if (result != null&&result.ID > 0)
            {
                var result2 = proxy.DeleteAnimalType(result);
            }
            AnimalType.TypeName = "Snake";
            AnimalType.ClassName = "Services.Sounds.SnakeSound";
            try
            {
                AnimalType = proxy.InsertAnimalType(AnimalType);

                Assert.IsTrue(AnimalType != null && AnimalType.ID > 0);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(8)]
        public void TestMethod9_UpdateAnimalType()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();

            AnimalDataContracts.Animal.AnimalType AnimalType = new AnimalDataContracts.Animal.AnimalType();
            var AnimalTypes = proxy.GetAllAnimalTypes();

            AnimalType = AnimalTypes.Where(x => x.TypeName == "Snake").FirstOrDefault();
            AnimalType.TypeName = "Horse";
            AnimalType.ClassName = "Services.Sounds.HorseSound";
            try
            {
                var result = proxy.UpdateAnimalType(AnimalType);

                Assert.IsTrue(result);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }
        [TestMethod()]
        [Priority(9)]
        public void TestMethod_10_DeleteAnimalType()
        {
            AnimalResourceProxy proxy = new AnimalResourceProxy();


            AnimalDataContracts.Animal.AnimalType AnimalType = new AnimalDataContracts.Animal.AnimalType();
            var AnimalTypes = proxy.GetAllAnimalTypes();

            AnimalType = AnimalTypes.Where(x => x.TypeName == "Horse").FirstOrDefault();

            try
            {
                var result = proxy.DeleteAnimalType(AnimalType);

                Assert.IsTrue(result);
            }
            finally
            {
                Utils.CloseProxy(proxy);
            }
        }





    }
}
