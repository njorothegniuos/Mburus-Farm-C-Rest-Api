using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using THE_MBURUS_FARM.DBL.Enums;
using THE_MBURUS_FARM.DBL.Models;
using Dapper;

namespace THE_MBURUS_FARM.DBL.Repositories
{
    public class AnimalRepository : BaseRepository, IAnimalRepository
    {
        public AnimalRepository(string connectionString) : base(connectionString)
        {
        }
        #region pig breeds
        public IEnumerable<PigBreed> GetPigBreed(int userCode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@maker", userCode);
                return connection.Query<PigBreed>("sp_getPigBreeds", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #region api methods
        public IEnumerable<PigBreed> GetPigBreed()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<PigBreed>("sp_getPig_Breeds", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<PigBreed> GetPigBreed(string breed)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@breed", breed);
                return connection.Query<PigBreed>("sp_getPig_Breeds", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion api mtds
        public IEnumerable<makepigOrder> makepigOrder(makepigOrder order)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@breed", order.breed);
                parameters.Add("@males", order.males);
                parameters.Add("@females", order.females);
                parameters.Add("@age", order.age);
                return connection.Query<makepigOrder>("sp_makepigOrder", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion pig breeds
    }
}
