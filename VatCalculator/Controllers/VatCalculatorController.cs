using MediatR;
using Microsoft.AspNetCore.Mvc;
using VatCalculator.Business.UseCases.VatCalculatorUseCase;
using VatCalculator.Dtos;

namespace VatCalculator.Controllers
{
    [ApiController]
    [Route("api/vat-calculator")]
    public class VatCalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VatCalculatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ValueRequestDto request, CancellationToken cancellationToken)
        {
            VatCalculatorUseCaseRequest vatCalculationUseCaseRequest = new(request);
            ValueResponseDto vatCalculatorResponse = await _mediator.Send(vatCalculationUseCaseRequest);
            return Ok(vatCalculatorResponse);
        }
    }
}
