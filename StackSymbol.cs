namespace StockManagement
{
    public class StackSymbol
    { 
        public class Node
        {
            public PortFolio Value;
            public Node Next;

            public Node(PortFolio value)
            {
                Value = value;
            }
        }

        private Node Head;
        private Node Tail;
        private int Size;

        public void Add(PortFolio value)
        {
            var newNode = new Node(value);

            if (Head == null)
                Head = Tail = newNode;
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            Size++;
        }

        public Node Contains(string symbol)
        {
            var temp = Head;
            while (temp != null)
            {
                if (temp.Value.Symbol == symbol)
                    return temp;
                temp = temp.Next;
            }
            return null;
        }

        public void Print()
        {
            var temp = Head;
            while (temp != null)
            {
                Console.WriteLine(" ------- Share Symbol : {0} -------", temp.Value.Symbol);
                if (temp.Value.Qty != 0)
                {
                    Console.WriteLine("Invested Amount : {0}", temp.Value.InvestedAmount);
                    Console.WriteLine("Share Quantity : {0}", temp.Value.Qty);
                    Console.WriteLine("Share Average Buy : {0} \n", temp.Value.AvgBuy);
                }
                if(temp.Value.PL != 0)
                    Console.WriteLine("Profit or Loss : {0}",temp.Value.PL);

                temp = temp.Next;
            }
        }
    }
}