using Mc2.CrudTest.Domain.Dtos.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Update
{
    public class UpdateDependentCreditNoteCommand: IRequest<bool>
    {
        public DependentCreditNoteInputDto DependentCreditNoteInputDto { get; private set; }

        public UpdateDependentCreditNoteCommand(DependentCreditNoteInputDto dependentCreditNoteInputDto)
        {
            DependentCreditNoteInputDto = dependentCreditNoteInputDto;
        }
    }
}
