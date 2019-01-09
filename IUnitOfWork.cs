using THE_MBURUS_FARM.DBL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace THE_MBURUS_FARM.DBL.UOW
{
    public interface IUnitOfWork
    {
        ISecurityRepository SecurityRepository { get; }
        ITaxRepository TaxRepository { get; }
        IGeneralRepository GeneralRepository { get; }
        IRefRepository RefRepository { get; }
        IReportRepository ReportRepository { get; }
        IAnimalRepository AnimalRepository { get; }

        void Reset();
    }
}
