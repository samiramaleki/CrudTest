using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Dtos.Invoices;
using Mc2.CrudTest.Domain.Models.Invoices;
using Mc2.CrudTest.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private FinanceDbContext _context;

        public InvoiceRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Invoice model)
        {
            await _context.Invoices.AddAsync(model);
            return model.Id;
        }
        public async Task Delete(Invoice model)
        => await Task.FromResult(_context.Invoices.Remove(model));

        public async Task<Guid> Update(Invoice model)
        {
            await Task.FromResult(_context.Invoices.Update(model));
            return model.Id;
        }

        public async Task<Invoice> GetById(Guid id)
        => await _context.Invoices.FirstOrDefaultAsync(prop => prop.Id == id);

        public async Task<List<DocumentOutPutDto>> GetList(CancellationToken cancellationToken)
        {
            var invoiceAndCredit = (from invoice in _context.Invoices
                                    join credit in _context.DependentCreditNotes on invoice.Id equals credit.InvoiceId into invoiceCreditResult
                                    from invoiceCredit in invoiceCreditResult.DefaultIfEmpty()
                                    select new DocumentOutPutDto
                                    {
                                        InvoiceId = invoice.Id,
                                        DependentCreditNoteId= invoiceCredit != null ? invoiceCredit.Id : null,
                                        CreditNumber = invoiceCredit != null ? invoiceCredit.CreditNumber : 0,
                                        CreditTotalAmount = invoiceCredit != null ? invoiceCredit.TotalAmount : 0,
                                        CreditStatus = invoiceCredit != null ? Enum.GetName(invoiceCredit.CreditStatus) : string.Empty,
                                        ExternalCreditNumber = invoiceCredit != null ? invoiceCredit.ExternalCreditNumber : null,
                                        ExternalInvoiceNumber = invoice != null ? invoice.ExternalInvoiceNumber : null,
                                        InvoiceNumber = invoice.InvoiceNumber,
                                        InvoiceTotalAmount = invoice.TotalAmount,
                                        InvoiceStatus = Enum.GetName(invoice.InvoiceStatus)
                                    }).AsNoTracking().ToList();

            var indentCredit = _context.IndependentCreditNotes.Select(x => new DocumentOutPutDto
            {

                IndependentCreditNoteId = x.Id,
                ExternalCreditNumber = x.ExternalCreditNumber,
                CreditStatus = Enum.GetName(x.InvoiceStatus),
                CreditTotalAmount = x.TotalAmount,
                CreditNumber = x.CreditNumber,
            }).AsNoTracking().ToList();

            return invoiceAndCredit.Union(indentCredit).ToList();
        }

        public async Task<List<GetInvoiceSimple>> GetInvoiceSimpleList(CancellationToken cancellationToken = default)
         => await _context.Invoices.Select(x =>
         new GetInvoiceSimple
         {
             Id= x.Id,
             InvoiceNumber= x.InvoiceNumber
         }).AsNoTracking().ToListAsync();
    }
}
