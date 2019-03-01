using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalDataContracts.Animal;
using Dapper;

namespace Animal.ResourceAccess.Animal
{
    public class AnimalDapperRepository : DapperGenericRepository
    {
        public AnimalDapperRepository(string connectionName)
           : base(connectionName)
        { }

        #region Animal
        public List<AnimalDataContracts.Animal.Animal> GetAllAnimals()
        {
            var prm = new DynamicParameters();       

            return connection.Query<AnimalDataContracts.Animal.Animal>("sp_Animal_All_G", prm, commandType: CommandType.StoredProcedure).AsList();
        }

        public AnimalDataContracts.Animal.Animal GetAnimalByID(int ID)
        {
            var prm = new DynamicParameters();
            prm.Add("ID", ID);

            return connection.Query<AnimalDataContracts.Animal.Animal>("sp_Animal_By_ID_G", prm, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public AnimalDataContracts.Animal.Animal InsertAnimal(AnimalDataContracts.Animal.Animal request)
        {
            var prm = new DynamicParameters();
            prm.Add("Name", request.Name);
            prm.Add("AnimalTypeID", request.AnimalTypeID);
            prm.Add("Animal_ID ", dbType: DbType.Int32, direction: ParameterDirection.Output);


            connection.Execute("sp_Animal_I", prm, commandType: CommandType.StoredProcedure);
            request.ID = prm.Get<int>("Animal_ID");
            return request;
        }

        public bool UpdateAnimal(AnimalDataContracts.Animal.Animal request)
        {
            var prm = new DynamicParameters();
            prm.Add("Name", request.Name);
            prm.Add("AnimalTypeID", request.AnimalTypeID);
            prm.Add("ID", request.ID);

            connection.Execute("sp_Animal_U", prm, commandType: CommandType.StoredProcedure);

            return true;
        }
        public bool DeleteAnimal(AnimalDataContracts.Animal.Animal request)
        {
            var prm = new DynamicParameters();          
            prm.Add("ID", request.ID);

            connection.Execute("sp_Animal_D", prm, commandType: CommandType.StoredProcedure);

            return true;
        }

        #endregion

        #region AnimalType
        public List<AnimalDataContracts.Animal.AnimalType> GetAllAnimalTypes()
        {
            var prm = new DynamicParameters();

            return connection.Query<AnimalDataContracts.Animal.AnimalType>("sp_AnimalType_All_G", prm, commandType: CommandType.StoredProcedure).AsList();
        }

        public AnimalDataContracts.Animal.AnimalType GetAnimalTypeByID(int ID)
        {
            var prm = new DynamicParameters();
            prm.Add("ID", ID);

            return connection.Query<AnimalDataContracts.Animal.AnimalType>("sp_AnimalType_By_ID_G", prm, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public AnimalDataContracts.Animal.AnimalType InsertAnimalType(AnimalDataContracts.Animal.AnimalType request)
        {
            var prm = new DynamicParameters();
            prm.Add("TypeName", request.TypeName);
            prm.Add("ClassName", request.ClassName);
            prm.Add("AnimalType_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);


            connection.Execute("sp_AnimalType_I", prm, commandType: CommandType.StoredProcedure);
            request.ID = prm.Get<int>("AnimalType_ID");
            return request;
        }

        public bool UpdateAnimalType(AnimalDataContracts.Animal.AnimalType request)
        {
            var prm = new DynamicParameters();
            prm.Add("TypeName", request.TypeName);
            prm.Add("ClassName", request.ClassName);
            prm.Add("ID", request.ID);

            connection.Execute("sp_AnimalType_U", prm, commandType: CommandType.StoredProcedure);

            return true;
        }
        public bool DeleteAnimalType(AnimalDataContracts.Animal.AnimalType request)
        {
            var prm = new DynamicParameters();
            prm.Add("ID", request.ID);

            connection.Execute("sp_AnimalType_D", prm, commandType: CommandType.StoredProcedure);

            return true;
        }

        #endregion
    }
}
