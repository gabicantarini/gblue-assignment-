﻿namespace VatCalculator.Dtos
{
    public class ValueResponseDto
    {
        public decimal? Net { get; set; }
        public decimal? Gross { get; set; }
        public decimal? AustriaVatRate { get; set; }
        public decimal? Vat { get; set; }
    }
}
