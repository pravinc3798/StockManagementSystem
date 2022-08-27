namespace StockManagement
{
    public class Order
    {
        public string TypeOfTransaction;
        public string StockSymbol;
        public double Price;
        public int Qty;
        public DateTime TrasactionTime;

        public Order(string typeOfTransaction, string stockSymbol, double price, int qty)
        {
            TypeOfTransaction = typeOfTransaction;
            StockSymbol = stockSymbol;
            Price = price;
            Qty = qty;
            TrasactionTime = DateTime.Now;
        }
    }
}