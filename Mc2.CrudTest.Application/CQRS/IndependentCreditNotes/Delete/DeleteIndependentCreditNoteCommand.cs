using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Delete
{
    public class DeleteIndependentCreditNoteCommand: IRequest<bool>
    {
        public Guid Id { get; private set; }

        public DeleteIndependentCreditNoteCommand(Guid id)
        {
            Id = id;
        }
    }
}
