using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models.DependentCreditNotes;
using Mc2.CrudTest.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class DependentCreditNoteRepository : IDependentCreditNoteRepository
    {
        private FinanceDbContext _context;

        public DependentCreditNoteRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(DependentCreditNote model)
        {
            await _context.DependentCreditNotes.AddAsync(model);
            return model.Id;
        }

        public async Task Delete(DependentCreditNote model)
        => await Task.FromResult(_context.DependentCreditNotes.Remove(model));

        public async Task<DependentCreditNote> GetById(Guid id)
        => await _context.DependentCreditNotes.FirstOrDefaultAsync(prop => prop.Id == id);

        public async Task<Guid> Update(DependentCreditNote model)
        {
            await Task.FromResult(_context.DependentCreditNotes.Update(model));
            return model.Id;
        }
    }
}
