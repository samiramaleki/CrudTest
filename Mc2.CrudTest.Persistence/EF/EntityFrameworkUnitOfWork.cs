using Mc2.CrudTest.Application.Interfaces;
using System;

namespace Mc2.CrudTest.Persistence.EF
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private FinanceDbContext _context;

        public EntityFrameworkUnitOfWork(FinanceDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}
