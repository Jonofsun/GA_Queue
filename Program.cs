namespace GA_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            // Enqueue elements
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Dequeue an element
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");

            // Peek at the front element
            Console.WriteLine($"Front element: {queue.Peek()}");

            // Display count
            Console.WriteLine($"Count: {queue.Count}");

            Console.ReadLine();
        }
    }
}
