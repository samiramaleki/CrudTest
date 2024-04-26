using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models.IndependentCreditNotes;
using Mc2.CrudTest.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class IndependentCreditNoteRepository : IIndependentCreditNoteRepository
    {
        private FinanceDbContext _context;

        public IndependentCreditNoteRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(IndependentCreditNote model)
        {
            await _context.IndependentCreditNotes.AddAsync(model);
            return model.Id;
        }

        public async Task Delete(IndependentCreditNote model)
        => await Task.FromResult(_context.IndependentCreditNotes.Remove(model));

        public async Task<IndependentCreditNote> GetById(Guid id)
         => await _context.IndependentCreditNotes.FirstOrDefaultAsync(prop => prop.Id == id);

        public async Task<Guid> Update(IndependentCreditNote model)
        {
            await Task.FromResult(_context.IndependentCreditNotes.Update(model));
            return model.Id;
        }
    }
}
