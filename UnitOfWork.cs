using System;
using System.Collections.Generic;
using System.Text;
using THE_MBURUS_FARM.DBL.Repositories;

namespace THE_MBURUS_FARM.DBL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private IAnimalRepository animalRepository;

        public UnitOfWork(string connectionString)
        {
            connString = connectionString;
        }

        public IAnimalRepository AnimalRepository
        {
            get { return animalRepository ?? (animalRepository = new AnimalRepository(connString)); }
        }

       
        public void Reset()
        {
            animalRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
