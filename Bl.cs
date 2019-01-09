using THE_MBURUS_FARM.DBL.Consts;
using THE_MBURUS_FARM.DBL.Entities;
using THE_MBURUS_FARM.DBL.Enums;
using THE_MBURUS_FARM.DBL.Models;
using THE_MBURUS_FARM.DBL.UOW;
using THE_MBURUS_FARM.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace THE_MBURUS_FARM.DBL
{
    public class Bl
    {
        private UnitOfWork db;
        private string _connString;
        public string LogFile { get; set; }

        public Bl(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }
        #region api methods
        public async Task<IEnumerable<PigBreed>> GetPigBreed()
        {
            return await Task.Run(() =>
            {
                var PigBreed = db.AnimalRepository.GetPigBreed();
                return PigBreed;
            });
        }
        public async Task<IEnumerable<PigBreed>> GetPigBreed(string breed)
        {
            return await Task.Run(() =>
            {
                var PigBreed = db.AnimalRepository.GetPigBreed(breed);
                return PigBreed;
            });
        }
        public async Task<IEnumerable<makepigOrder>> makepigsOrder(makepigOrder order)
        {
            return await Task.Run(() =>
            {
                var makepigOrder = db.AnimalRepository.makepigOrder(order);
                return makepigOrder;
            });
        }
        #endregion api mtds 
    }
}
