using System.Text.RegularExpressions;
using VatCalculator.Business.Interfaces;
using VatCalculator.Dtos;

namespace VatCalculator.Business.Implementations
{
    public class VatCalculatorService : IVatCalculatorService
    {
        public ValueResponseDto Calculate(ValueRequestDto request)
        {
            ValueResponseDto valueResponse = new ValueResponseDto();     

            if (request.Net.HasValue && request.Net.Value != 0 && request.AustriaVatRate.HasValue)
            {
                valueResponse.Net = request.Net.Value;
                valueResponse.AustriaVatRate = request.AustriaVatRate.Value;               
                valueResponse.Gross = Math.Round((decimal)(request.Net.Value + (decimal)(request.Net.Value * request.AustriaVatRate) / 100), 2);
                valueResponse.Vat = Math.Round((decimal)(request.Net.Value * request.AustriaVatRate) / 100, 2);  

            }
            else if (request.Gross.HasValue && request.Gross.Value != 0 && request.AustriaVatRate.HasValue)
            {
                valueResponse.Gross = request.Gross.Value;
                valueResponse.Net = Math.Round((decimal)(request.Gross.Value / (1 + (decimal)(request.AustriaVatRate) / 100)), 2);
                valueResponse.AustriaVatRate = request.AustriaVatRate.Value;
                valueResponse.Vat = Math.Round((decimal)(request.Gross.Value - valueResponse.Net), 2);
            }
            else if (request.Vat.HasValue && request.AustriaVatRate.HasValue)
            {
                valueResponse.Vat = request.Vat.Value;
                valueResponse.AustriaVatRate = request.AustriaVatRate.Value;
                valueResponse.Net = Math.Round((decimal)(valueResponse.Vat * (decimal)(valueResponse.AustriaVatRate)), 2);
                valueResponse.Gross = Math.Round((decimal)(valueResponse.Net + valueResponse.Vat), 2);               
            }
            
            return valueResponse;

        }
    }
}
