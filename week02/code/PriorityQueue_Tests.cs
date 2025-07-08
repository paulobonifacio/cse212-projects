using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Queue 3 items with different priorities and check if the one with the highest priority is removed.
    // Expected Result: Returns the item with the highest priority.
    // Defect(s) Found: Original code does not remove item from list, only returns value.
    public void TestPriorityQueue_RemovesHighestPriorityItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        string result = pq.Dequeue();
        Assert.AreEqual("High", result);

        // Dequeuing again should bring up priority 5
        result = pq.Dequeue();
        Assert.AreEqual("Medium", result);
    }

    [TestMethod]
    // Scenario: Queue multiple items with the same priority and ensure that it follows FIFO.
    // Expected Result: The first insert with the highest priority is returned first.
    // Defect(s) Found: The original 'for' loop ignores the last item.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 10);
        pq.Enqueue("Second", 10);
        pq.Enqueue("Third", 5);

        string result = pq.Dequeue();
        Assert.AreEqual("First", result);

        result = pq.Dequeue();
        Assert.AreEqual("Second", result);
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: Should throw exception with correct message.
    // Defect(s) Found: None. The code throws an exception, but tests don't confirm this.
    public void TestPriorityQueue_EmptyThrows()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Queue items with different priorities and ensure that they are all returned in the correct order.
    // Expected Result: Order: High, Medium, Low
    // Defect(s) Found: Original code returns items, but does not remove them.
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 100);
        pq.Enqueue("Medium", 50);

        string result = pq.Dequeue();
        Assert.AreEqual("High", result);

        result = pq.Dequeue();
        Assert.AreEqual("Medium", result);

        result = pq.Dequeue();
        Assert.AreEqual("Low", result);
    }
}
