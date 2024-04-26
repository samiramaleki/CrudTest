using Mc2.CrudTest.Domain.Dtos.Invoices;
using Mc2.CrudTest.Domain.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
        Task<List<DocumentOutPutDto>> GetList(CancellationToken cancellationToken = default);
        Task<List<GetInvoiceSimple>> GetInvoiceSimpleList(CancellationToken cancellationToken = default);
    }
}
