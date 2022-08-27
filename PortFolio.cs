namespace StockManagement
{
    public class PortFolio
    {
        public string Symbol;
        public double InvestedAmount;
        public int Qty;
        public double AvgBuy;
        public double PL;

        public PortFolio(string symbol, double investedAmount, int qty)
        {
            Symbol = symbol;
            InvestedAmount = investedAmount;
            Qty = qty;
            AvgBuy = 0;
            PL = 0;
        }
    }
}