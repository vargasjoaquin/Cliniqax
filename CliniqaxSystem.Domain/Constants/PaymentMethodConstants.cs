namespace CliniqaxSystem.Domain.Constants
{
    public static class PaymentMethodConstants
    {
        public const int CASH_ID = 1;
        public const int DEBIT_CARD_ID = 2;
        public const int CREDIT_CARD_ID = 3;
        public const int BANK_TRANSFER_ID = 4;
        public const int MERCADO_PAGO_QR_ID = 5;

        public const string CASH = "Efectivo";
        public const string DEBIT_CARD = "Tarjeta de Débito";
        public const string CREDIT_CARD = "Tarjeta de Crédito";
        public const string BANK_TRANSFER = "Transferencia Bancaria";
        public const string MERCADO_PAGO_QR = "Mercado Pago / QR";
    }
}
