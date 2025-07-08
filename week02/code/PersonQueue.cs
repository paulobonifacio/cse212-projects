using System;
using System.Collections.Generic;

// This class wraps a queue of Person objects using FIFO logic
public class PersonQueue
{
    // Internal queue to store Person objects
    private Queue<Person> _queue = new();

    // Add a person to the end of the queue
    public void Enqueue(Person person)
    {
        _queue.Enqueue(person);
    }

    // Remove and return the person at the front of the queue
    public Person Dequeue()
    {
        return _queue.Dequeue();
    }

    // Check if the queue is empty
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    // Return the number of people in the queue
    public int Length => _queue.Count;

    // Convert the queue to a readable string
    public override string ToString()
    {
        return string.Join(", ", _queue);
    }
}
