using MediatR;
using System;

namespace Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.GetById
{
    public class GetIndependentCreditNoteByIdQuery: IRequest<GetIndependentCreditNoteByIdQueryResult>
    {
        public Guid Id { get; private set; }

        public GetIndependentCreditNoteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
