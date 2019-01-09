using THE_MBURUS_FARM.DBL.Enums;
using THE_MBURUS_FARM.DBL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace THE_MBURUS_FARM.DBL.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<PigBreed> GetPigBreed(int userCode);
        IEnumerable<PigBreed> GetPigBreed(string breed);
        IEnumerable<PigBreed> GetPigBreed();
        IEnumerable<makepigOrder> makepigOrder(makepigOrder order);
    }
}
