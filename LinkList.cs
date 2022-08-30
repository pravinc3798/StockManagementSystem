namespace StockManagement
{
    public class LinkList
    {
        private class Node
        {
            public Order Details;
            public Node Next;

            public Node(Order details)
            {
                Details = details;
            }
        }

        private Node Head;
        private Node Tail;
        private int Size;

        public void AddOrder(Order details)
        {
            var newNode = new Node(details);

            if (Head == null)
                Head = Tail = newNode;

            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            Size++;
        }

        public void OrderHistory()
        {
            Console.WriteLine("---------------------------Order histroy---------------------------------------------");

            var temp = Head;
            while (temp != null)
            {
                Console.WriteLine("Date Time : {0}, Type : {1}, Stock : {2}, Price : {3}, Quantity : {4}", temp.Details.TrasactionTime.ToLocalTime(),temp.Details.TypeOfTransaction,temp.Details.StockSymbol,temp.Details.Price,temp.Details.Qty);
                temp = temp.Next;
            }
        }
    }
}
