using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three values with different priorities (low, high, medium) and dequeue all of them.
    // Expected Result: Values come out in order from highest priority to lowest, regardless of the
    // order they were added in: "high", "medium", "low".
    // Defect(s) Found: The loop that searches for the highest priority item stopped one item early
    // (index < _queue.Count - 1), so the last item in the queue was never even considered. Also,
    // Dequeue never removed the item it found, it just read the value, so the same item was returned
    // every time and the queue never actually shrank.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 3);
        priorityQueue.Enqueue("medium", 2);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two values with the same highest priority, "first" then "second", along with
    // a lower priority value in between.
    // Expected Result: Since both "first" and "second" share the highest priority, "first" comes out
    // before "second" because it was added earlier, followed by the lower priority value.
    // Defect(s) Found: The comparison used >= instead of >, so when a later item tied the current
    // highest priority, it incorrectly replaced it. This meant "second" was returned before "first",
    // breaking the first in first out rule for equal priorities.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("second", 5);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on a queue that has nothing in it.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None, this part already worked correctly in the original code.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single value, dequeue it, then enqueue a new value and dequeue again.
    // Expected Result: Confirms that Dequeue actually removes the item, so the queue can be reused
    // after emptying out instead of returning the same stale item forever.
    // Defect(s) Found: Since the original Dequeue never removed items from the list, the second
    // Dequeue call would have incorrectly returned "one" again instead of "two".
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("one", 1);

        Assert.AreEqual("one", priorityQueue.Dequeue());

        priorityQueue.Enqueue("two", 1);
        Assert.AreEqual("two", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}