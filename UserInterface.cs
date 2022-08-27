namespace StockManagement
{
    public class UserInterface
    {
        LinkList list = new LinkList();
        StackSymbol stack = new StackSymbol();

        public void Home()
        {
            Console.Write("\n 1. Buy a Share  \n 2. Sell a Share \n 3. View Transaction Histroy \n 4. View Portfolio \n 5. Exit \n Enter the desired input : "); var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    {
                        Console.Write("\n Enter Share Symbol : "); var symbol = Console.ReadLine();
                        Console.Write(" Enter Share Price : "); var price = Convert.ToDouble(Console.ReadLine());
                        Console.Write(" Enter Qty to Buy : "); var qty = Convert.ToInt32(Console.ReadLine());

                        var temp = stack.Contains(symbol);

                        if (temp == null)
                        {
                            var newOrder = new PortFolio(symbol,qty*price,qty);
                            stack.Add(newOrder);
                            newOrder.AvgBuy = price;
                        }
                        else
                        {
                            temp.Value.InvestedAmount += price * qty;
                            temp.Value.Qty += qty;
                            temp.Value.AvgBuy = temp.Value.InvestedAmount / (double)temp.Value.Qty;
                        }

                        var order = new Order("BUY", symbol, price, qty);
                        list.AddOrder(order);

                        Home();
                        break;
                    }
                case "2":
                    {
                        Console.Write("\n Enter Share Symbol : "); var symbol = Console.ReadLine();
                        Console.Write(" Enter Share Price : "); var price = Convert.ToDouble(Console.ReadLine());
                        Console.Write(" Enter Qty to Sell : "); var qty = Convert.ToInt32(Console.ReadLine());

                        var temp = stack.Contains(symbol);

                        if(temp == null)
                        {
                            Console.WriteLine("\n {0} is not in the portfolio.",symbol);
                        }
                        else if(temp != null)
                        {
                            if (qty <= temp.Value.Qty)
                            {

                                temp.Value.PL += (price - temp.Value.InvestedAmount/(double)temp.Value.Qty) * qty;
                                temp.Value.Qty -= qty;
                                temp.Value.InvestedAmount = temp.Value.Qty * temp.Value.AvgBuy;
                                
                                var order = new Order("SELL", symbol, price, qty);
                                list.AddOrder(order);

                                if (temp.Value.Qty == 0)
                                    temp.Value.AvgBuy = temp.Value.InvestedAmount = 0;
                            }
                            else
                                Console.WriteLine("\n Can't sell qty more than {0}", temp.Value.Qty);
                        }
                        Home();
                        break;
                    }
                case "3":
                    {
                        list.OrderHistory();
                        Home();
                        break;
                    }
                case "4":
                    {
                        stack.Print();
                        Home();
                        break;
                    }
                case "5": break;

            }
        }
    }
}