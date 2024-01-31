using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Queue
{
    class Queue<T>
    {
        class QueueNode<T>
        {
            public T Value { get; set; } // The value stored in the node.
            public QueueNode<T> Next { get; set; } // Reference to the next node in the queue.
            public QueueNode<T> Previous { get; set; } // Reference to the previous node in the queue.

            public QueueNode(T value)
            {
                Value = value; // Set the value of the node.
                Next = null; // Initially, the next node is null.
                Previous = null; // Initially, the previous node is null.
            }
        }


        private QueueNode<T> front; // The front node of the queue.
        private QueueNode<T> rear; // The rear node of the queue.
        private int count; // The number of elements in the queue.

        public int Count
        {
            get { return count; } // Getter for count.
        }

        public Queue()
        {
            front = null; // Initially, the front is null as the queue is empty.
            rear = null; // Initially, the rear is also null.
            count = 0; // The count of elements starts at 0.
        }

        public void Enqueue(T value)
        {
            QueueNode<T> newNode = new QueueNode<T>(value); // Create a new node with the value.

            if (rear == null)
            {
                // If the queue is empty, both front and rear are the new node.
                front = newNode;
                rear = newNode;
            }
            else
            {
                // Link the new node after the current rear.
                rear.Next = newNode;
                newNode.Previous = rear;
                // Update the rear to be the new node.
                rear = newNode;
            }

            count++; // Increment the count of elements.
        }

        public T Dequeue()
        {
            if (front == null)
                throw new InvalidOperationException("Queue is empty."); // Check for an empty queue.

            T value = front.Value; // Store the value to return.

            // Move the front pointer to the next node.
            front = front.Next;

            if (front == null)
                rear = null; // If the queue becomes empty, adjust the rear as well.
            else
                front.Previous = null; // Remove the reference to the dequeued node.

            count--; // Decrement the count of elements.
            return value; // Return the dequeued value.
        }

        public T Peek()
        {
            if (front == null)
                throw new InvalidOperationException("Queue is empty."); // Check for an empty queue.

            return front.Value; // Return the value of the front node.
        }

        public void Clear()
        {
            front = null; // Reset the front to null.
            rear = null; // Reset the rear to null.
            count = 0; // Reset the count to 0.
        }
    }

}
