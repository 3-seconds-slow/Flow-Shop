using FlowShop;

namespace Flow_Shop_Tests;

[TestClass()]
public class Flow_Shop_Tests
{
    [TestMethod()]
    public void TwoMachineRegularData()
    {
        Job A = new("A", 3.2, 4.2);
        Job B = new("B", 4.7, 1.5);
        Job C = new("C", 2.2, 5);
        Job D = new("D", 5.8, 4);
        Job E = new("E", 3.1, 2.8);

        List<Job> jobs = new() { A, B, C, D, E };
        Job[] expected = { C, A, D, E, B };
        Job[] actual = Program.SortTwoMachineJobs(jobs);

        //Assert.AreEqual(expected, actual);
        Assert.IsTrue(actual.SequenceEqual(expected));
    }

    [TestMethod()]
    public void TwoMachineIdenticalData()
    {
        Job A = new("A", 1, 1);
        Job B = new("B", 1, 1);
        Job C = new("C", 1, 1);

        List<Job> jobs = new() { A, B, C };
        Job[] expected = { C, B, A };
        Job[] actual = Program.SortTwoMachineJobs(jobs);

        Assert.IsTrue(actual.SequenceEqual(expected));
    }

    [TestMethod()]
    public void TwoMachineSymetricalData()
    {
        Job A = new("A", 1, 5);
        Job B = new("B", 2, 2);
        Job C = new("C", 5, 1);

        List<Job> jobs = new() { A, B, C };
        Job[] expected = { A, B, C };
        Job[] actual = Program.SortTwoMachineJobs(jobs);

        Assert.IsTrue(actual.SequenceEqual(expected));
    }

    [TestMethod()]
    public void TwoMachineEmptyData()
    {
        List<Job> jobs = new();
        Job[] expected = Array.Empty<Job>();
        Job[] actual = Program.SortTwoMachineJobs(jobs);

        Assert.ThrowsException<ScheduleException>(() => Program.SortTwoMachineJobs(jobs));
    }

    [TestMethod()]
    public void ThreeMachineRegularData()
    {
        Job A = new("A", 10, 3, 8);
        Job B = new("B", 6, 1, 8);
        Job C = new("C", 7, 5, 9);
        Job D = new("D", 10, 6, 9);

        List<Job> jobs = new() { A, B, C, D };
        Job[] expected = { B, C, D, A };
        Job[] actual = Program.SortThreeMachineJobs(jobs);

        Assert.IsTrue(actual.SequenceEqual(expected));
    }

    [TestMethod()]
    public void ThreeMachineIdenticalData()
    {
        Job A = new("A", 1, 1, 1);
        Job B = new("B", 1, 1, 1);
        Job C = new("C", 1, 1, 1);

        List<Job> jobs = new() { A, B, C };
        Job[] expected = { C, B, A };
        Job[] actual = Program.SortThreeMachineJobs(jobs);

        Assert.IsTrue(actual.SequenceEqual(expected));
    }

    [TestMethod()]
    public void ThreeMachineUnsuitableData()
    {
        Job A = new("A", 1, 2, 3);
        Job B = new("B", 2, 2, 5);
        Job C = new("C", 1, 2, 3);

        List<Job> jobs = new() { A, B, C };
        Job[] expected = { A, B, C };
        Job[] actual = Program.SortThreeMachineJobs(jobs);

        Assert.ThrowsException<ScheduleException>(() => Program.SortThreeMachineJobs(jobs));
    }

    [TestMethod()]
    public void ThreeMachineEmptyData()
    {
        List<Job> jobs = new();
        Job[] expected = Array.Empty<Job>();
        Job[] actual = Program.SortThreeMachineJobs(jobs);

        Assert.ThrowsException<ScheduleException>(() => Program.SortThreeMachineJobs(jobs));
    }
}
