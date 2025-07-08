using System;
using System.Collections.Generic;

// This class represents a priority queue where higher numbers mean higher priority
public class PriorityQueue
{
    // Internal list to store all items
    private List<PriorityItem> _queue = new();

    // Add an item to the end of the list with its associated priority
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    // Remove and return the item with the highest priority
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        int highPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = i;
            }
        }

        // Remove and return the highest-priority item
        var item = _queue[highPriorityIndex];
        _queue.RemoveAt(highPriorityIndex);
        return item.Value;
    }

    // Return a string representation of the queue
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

// Class used to store a value and its priority
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // Return a string
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
