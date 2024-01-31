# Guided Assignment - Queue Using Doubly Linked List

## Introduction

**What is a Queue:** A queue is a linear data structure that follows the First In, First Out (FIFO) principle. This means that the first element added to the queue will be the first one to be removed.

**Why is it Important:** Queues are widely used in computer science for managing processes in operating systems, handling requests in web servers, and in breadth-first search algorithms.

**Differences from Doubly Linked List:**
1. **Operation Order:** A queue restricts insertion to the rear (enqueue) and deletion to the front (dequeue), while a doubly linked list allows insertion and deletion at both ends.
2. **Functionality:** A queue offers two primary operations: `enqueue` (add) and `dequeue` (remove), and is more restricted compared to a doubly linked list.

**Pros of Queues:**
1. **Order Preservation:** Ensures processing in the order of arrival.
2. **Efficient Operations:** Enqueue and dequeue operations are typically done in constant time.
3. **Wide Range of Applications:** From operating systems to networking and beyond.

**Cons of Queues:**
1. **Limited Direct Access:** Cannot access elements in the middle of the queue directly.
2. **Potential for Overflow:** Limited by the amount of memory allocated if implemented using an array.

***Real World Examples***

1. **Task Scheduling:** In operating systems for managing processes.
2. **Customer Service:** In handling customer requests in order of arrival.
3. **Networking:** In managing packets in routers and switches.
4. **Printing Jobs:** In managing the order of documents to be printed.

---

## Requirements

**Project Setup:**
1. Create a new C# project named "GA_Queue_DoublyLinkedList_YourName."
2. Include your name and the current date as comments in the main class or file.

**Queue Implementation:**
3. Implement a generic queue class named `Queue<T>` using a doubly linked list.
4. Include a nested class `QueueNode<T>` for individual nodes.

**Fields and Properties:**
5. Include fields for `front` and `rear`.
6. Implement a public property `Count` for accessing the number of elements.

**Constructor:**
7. Create a constructor to initialize `front` and `rear` to null and `count` to zero.

**Core Methods:**
8. Implement core methods:
   - `Enqueue(T value)` - Adds elements to the rear.
   - `Dequeue()` - Removes and returns the element from the front.
   - `Peek()` - Returns the element at the front without removing it.

**Additional Methods:**
9. Implement the `Clear` method to empty the queue.

**Testing:**
10. Test your `Queue` class in a separate program or class.
11. Include test cases for all functionalities, ensuring correct implementation.

**Readme File:**
12. In your README, address the following:
    - Explanation of a queue and its utility.
    - Differences between a queue and a doubly linked list.
    - Discuss scenarios where a queue is preferable over other data structures.
    - Considerations for choosing between a queue and other data structures.
    - Thoughts on implementing a queue using different approaches (array vs. linked list).

Ensure thorough documentation and a clear explanation in your README.

---

## Start By Creating a Queue Class

1. Make it generic.
2. Name it `Queue`.

```csharp
using System; // Import the System namespace for basic functionalities.

// Define a generic class called Queue.
// The 'T' here is a type parameter that allows this class to work with various data types.
class Queue<T>
{

}
```

---

### Create a Nested Node Class

A queue node in a doubly linked list has references to both the next and previous nodes, allowing bidirectional traversal.

```csharp
class Queue<T>
{
    // Nested class QueueNode representing elements in the queue.
    class QueueNode<T>
    {
        public T Value { get; set; }                       // Data stored in the node.
        public QueueNode<T> Next { get; set; }             // Reference to the next node.
        public QueueNode<T> Previous { get; set; }         // Reference to the previous node.

        public QueueNode(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
```

***What is a Queue Node***

A queue node is a critical component of a queue, especially when implemented using a doubly linked list. It includes:
1. Data storage.
2. Pointers to the next and previous nodes.
3. Facilitation of queue operations like enqueue and dequeue.

---

### Fields, Property, and Constructor for your Queue

```csharp
class Queue<T>
{
    // Private fields to track the front and rear elements of the queue.
    private QueueNode<T>

 front;
    private QueueNode<T> rear;
    private int count;

    // Public property to access the count of elements.
    public int Count
    {
        get { return count; }
    }

    // Constructor to initialize an empty queue.
    public Queue()
    {
        front = null;
        rear = null;
        count = 0;
    }
}
```

Explanation with comments:

- `private QueueNode<T> front;`: This private field holds a reference to the front node in the queue.
- `private QueueNode<T> rear;`: This private field holds a reference to the rear node in the queue.
- `private int count;`: This private field keeps track of the number of elements in the queue.
- `public Queue()`: The constructor initializes an empty queue.

**Explanation for `front` and `rear`:**

`front` and `rear` references are important in a queue to perform efficient enqueue and dequeue operations. `front` allows quick access to the first element for dequeue, while `rear` facilitates fast addition of new elements at the end of the queue.

---

## Enqueue Method

```csharp
public void Enqueue(T value)
{
    QueueNode<T> newNode = new QueueNode<T>(value);

    if (rear == null)
    {
        front = newNode;
        rear = newNode;
    }
    else
    {
        rear.Next = newNode;
        newNode.Previous = rear;
        rear = newNode;
    }

    count++;
}
```

Explanation:

1. Creates a new node.
2. If the queue is empty, sets both front and rear to the new node.
3. If not, links the new node at the rear.
4. Increments the count.

---

### Dequeue Method

```csharp
public T Dequeue()
{
    if (front == null)
        throw new InvalidOperationException("Queue is empty.");

    T value = front.Value;
    front = front.Next;

    if (front == null)
        rear = null;
    else
        front.Previous = null;

    count--;
    return value;
}
```

Explanation:

1. Checks if the queue is empty.
2. Retrieves the value of the front element.
3. Updates front to the next node.
4. Adjusts rear if necessary.
5. Decreases the count and returns the value.

---

### Peek Method

```csharp
public T Peek()
{
    if (front == null)
        throw new InvalidOperationException("Queue is empty.");

    return front.Value;
}
```

Explanation:

1. Checks if the queue is empty.
2. Returns the value of the front element without removing it.

---

### Clear Method

```csharp
public void Clear()
{
    front = null;
    rear = null;
    count = 0;
}
```

Explanation:

1. Resets front and rear to null.
2. Resets the count to zero.

---

### Test the Code

```csharp
class Program
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
```

---

## Rubric

| Name                | Description                                                       | Points |
|---------------------|-------------------------------------------------------------------|--------|
| Project Setup       | C# project creation with correct naming and comments.              | 5      |
| Queue Implementation | Implementation of the generic queue class using a doubly linked list. | 15     |
| QueueNode           | Nested `QueueNode` class implementation.                          | 5      |
| Fields & Properties | Proper implementation of fields and property.                     | 5      |
| Constructor         | Constructor implementation for `Queue`.                           | 5      |
| Core Methods        | Core methods (Enqueue, Dequeue, Peek) implementation.             | 15     |
| Clear Method        | Implementation of the `Clear` method.                             | 5      |
| Testing             | Comprehensive testing program with diverse cases.                 | 10     |
| Code Compilation    | Error-free code compilation.                                      | 5      |
| Readme              | Detailed README with explanations and answers.                    | 10     |
| Total               |                                                                   | 80     |

This assignment guides you through creating a queue using a doubly linked list, emphasizing FIFO behavior and efficient queue operations.

Prompt
The tutorial above is about creating a stack with a linked list. using this format refactor the tutorial to be about creating a queue with a doubly linked list