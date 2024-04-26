using Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Create;
using Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Delete;
using Mc2.CrudTest.Application.CQRS.DependentCreditNotes.Update;
using Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Create;
using Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Delete;
using Mc2.CrudTest.Application.CQRS.IndependentCreditNotes.Update;
using Mc2.CrudTest.Application.CQRS.Invoices.Create;
using Mc2.CrudTest.Application.CQRS.Invoices.Delete;
using Mc2.CrudTest.Application.CQRS.Invoices.GetById;
using Mc2.CrudTest.Application.CQRS.Invoices.List;
using Mc2.CrudTest.Application.CQRS.Invoices.Simple;
using Mc2.CrudTest.Application.CQRS.Invoices.Update;
using Mc2.CrudTest.Domain.Dtos;
using Mc2.CrudTest.Domain.Dtos.Invoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add-invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceInputDto invoiceInputDto)
        {
            return Ok(await _mediator.Send(new CreateInvoiceCommand(invoiceInputDto)));
        }

        [HttpGet]
        [Route("invoice-by-{id}")]
        public async Task<ActionResult<GetInvoiceByIdQueryResult>> GetInvoiceById(Guid id)
        {
            return Ok(await _mediator.Send(new GetInvoiceByIdQuery(id)));
        }

        [HttpPut]
        [Route("update-invoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody] InvoiceInputDto invoiceInputDto)
        {
            return Ok(await _mediator.Send(new UpdateInvoiceCommand(invoiceInputDto)));
        }

        [HttpGet]
        [Route("invoices")]
        public async Task<ActionResult<List<DocumentOutPutDto>>> Invoices()
        {
            return Ok(await _mediator.Send(new GetInvoiceListQuery { }));
        }

        [Route("delete-{id}-invoice")]
        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteInvoiceCommand { Id = id }));
        }

        [HttpPost]
        [Route("add-dependent-creditNote")]
        public async Task<IActionResult> CreateDependentCreditNote([FromBody] DependentCreditNoteInputDto dependentCreditNoteInputDto)
        {
            return Ok(await _mediator.Send(new CreateDependentCreditNoteCommand(dependentCreditNoteInputDto)));
        }

        [HttpPut]
        [Route("update-dependent-creditNote")]
        public async Task<IActionResult> UpdateDependentCreditNote([FromBody] DependentCreditNoteInputDto dependentCreditNoteInputDto)
        {
            return Ok(await _mediator.Send(new UpdateDependentCreditNoteCommand(dependentCreditNoteInputDto)));
        }

        [Route("delete-{id}-dependent-creditNote")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDependentCreditNote(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteDependentCreditNoteCommand { Id = id }));
        }

        [HttpGet]
        [Route("simple-invoice")]
        public async Task<ActionResult<List<GetInvoiceSimple>>> GetInvoiceSimple()
        {
            return Ok(await _mediator.Send(new GetInvoiceSimpleQuery()));
        }

        [HttpPost]
        [Route("add-independent-creditNote")]
        public async Task<IActionResult> CreateInDependentCreditNote([FromBody] IndependentCreditNoteInPutDto independentCreditNoteInPutDto)
        {
            return Ok(await _mediator.Send(new CreateIndependentCreditNoteCommand(independentCreditNoteInPutDto)));
        }

        [HttpPut]
        [Route("update-independent-creditNote")]
        public async Task<IActionResult> UpdateInDependentCreditNote([FromBody] IndependentCreditNoteInPutDto independentCreditNoteInPutDto)
        {
            return Ok(await _mediator.Send(new UpdateIndependentCreditNoteCommand(independentCreditNoteInPutDto)));
        }

        [Route("delete-{id}-independent-creditNote")]
        [HttpDelete]
        public async Task<IActionResult> DeleteInDependentCreditNote(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteIndependentCreditNoteCommand(id)));
        }
    }
}
