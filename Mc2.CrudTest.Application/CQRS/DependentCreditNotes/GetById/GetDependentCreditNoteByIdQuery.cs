using MediatR;
using System;

namespace Mc2.CrudTest.Application.CQRS.DependentCreditNotes.GetById
{
    public class GetDependentCreditNoteByIdQuery: IRequest<GetDependentCreditNoteByIdQueryResult> 
    {
        public Guid Id { get; private set; }

        public GetDependentCreditNoteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
