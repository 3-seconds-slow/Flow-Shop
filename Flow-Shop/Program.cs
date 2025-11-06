namespace FlowShop
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<Job> jobs = new List<Job>();
            Job[] sortedJobs;
            bool threeMachine = GetJobsFromUser(jobs); //threeMachine is a flag for how many machines are used
            try
            {
                if (threeMachine)
                {
                    sortedJobs = SortThreeMachineJobs(jobs);
                }
                else
                {
                    sortedJobs = SortTwoMachineJobs(jobs);
                }
                printSchedule(sortedJobs);
            }
            catch
            {
                Console.WriteLine("Unable to provide Solution");
            }
        }



        //this function prompts the user to enter the number of machines to use, and the name and times of each job. It returns a bool 
        //representing whether to use the two or three machine algorithm
        static bool GetJobsFromUser(List<Job> jobs)
        {
            bool threeMachine;

            while (true)
            {
                Console.WriteLine("This Algorithm supports 2 or 3 machine jobs");
                Console.WriteLine("Please enter the number of machines, or 'q' to quit");
                string input = Console.ReadLine();
                if (input == "2") { threeMachine = false; break; }
                else if (input == "3") { threeMachine = true; break; }
                else if (input.ToLower() == "q") { Environment.Exit(0); }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter job info, or 'done' when finished");
                    Console.Write("Enter Job name:");
                    string name = Console.ReadLine();
                    if (name.ToLower() == "done")
                    {
                        break;
                    }
                    Console.Write("Enter machine A time:");
                    float machineATime = float.Parse(Console.ReadLine());
                    Console.Write("Enter machine B time:");
                    float machineBTime = float.Parse(Console.ReadLine());
                    Job job = new Job(name, machineATime, machineBTime);
                    if (threeMachine)
                    {
                        Console.Write("Enter machine C time:");
                        float machineCTime = float.Parse(Console.ReadLine());
                        job.MachineCTime = machineCTime;
                    }
                    jobs.Add(job);
                }
                catch
                {
                    Console.WriteLine("Invalid data");
                }
            }
            return threeMachine;
        }

        //take a list of jobs to be processed on three machines and uses Johnson's rule provide an optimal schedule
        public static Job[] SortThreeMachineJobs(List<Job> jobs)
        {
            Job[] sortedJobs = new Job[jobs.Count];
            JobList machineATimes = new JobList();
            JobList machineBTimes = new JobList();
            JobList machineCTimes = new JobList();
            JobList machineABTimes = new JobList();
            JobList machineBCTimes = new JobList();
            int listStart = 0;
            int listEnd = jobs.Count - 1;
            Job quickestJob = null;
            int quickestIndex;

            //check that joblist is not empty
            if (jobs.Count > 0)
            {
                //add jobs int sorted lists for each machine
                foreach (Job job in jobs)
                {
                    machineATimes.Add(job.MachineATime, job);
                    machineBTimes.Add(job.MachineBTime, job);
                    machineCTimes.Add(job.MachineCTime, job);
                    machineABTimes.Add((job.MachineATime + job.MachineBTime), job);
                    machineBCTimes.Add((job.MachineBTime + job.MachineCTime), job);
                }

                //check that three machine constraints are met
                if (machineATimes.getMinKey() >= machineBTimes.getMaxKey() || machineCTimes.getMinKey() >= machineBTimes.getMaxKey())
                {
                    while (!machineABTimes.isEmpty())
                    {
                        //get the smallest time (minKey) from each list and schedule appropriately
                        if (machineABTimes.getMinKey() <= machineBCTimes.getMinKey())
                        {
                            quickestJob = machineABTimes.pop();
                            machineBCTimes.remove(quickestJob);
                            sortedJobs[listStart] = quickestJob;
                            listStart++;
                        }
                        else
                        {
                            quickestJob = machineBCTimes.pop();
                            machineABTimes.remove(quickestJob);
                            sortedJobs[listEnd] = quickestJob;
                            listEnd--;
                        }
                    }
                    return sortedJobs;
                }
                else
                {
                    throw new ScheduleException();
                }
            }
            else
            {
                throw new ScheduleException();
            }
        }

        //take a list of jobs to be processed on three machines and uses Johnson's rule provide an optimal schedule
        public static Job[] SortTwoMachineJobs(List<Job> jobs)
        {
            Job[] sortedJobs = new Job[jobs.Count];
            JobList machineATimes = new JobList();
            JobList machineBTimes = new JobList();
            int listStart = 0;
            int listEnd = jobs.Count - 1;
            Job quickestJob = null;
            int quickestIndex;


            //check that joblist is not empty
            if (jobs.Count > 0)
            {
                //add jobs int sorted lists for each machine
                foreach (Job job in jobs)
                {
                    machineATimes.Add(job.MachineATime, job);
                    machineBTimes.Add(job.MachineBTime, job);
                }

                while (!machineATimes.isEmpty())
                {
                    //get the smallest time (minKey) from each list and schedule appropriately
                    if (machineATimes.getMinKey() <= machineBTimes.getMinKey())
                    {
                        quickestJob = machineATimes.pop();
                        machineBTimes.remove(quickestJob);
                        sortedJobs[listStart] = quickestJob;
                        listStart++;
                    }
                    else
                    {
                        quickestJob = machineBTimes.pop();
                        machineATimes.remove(quickestJob);
                        sortedJobs[listEnd] = quickestJob;
                        listEnd--;
                    }
                }
                return sortedJobs;
            }
            else
            {
                throw new ScheduleException();
            }
        }

        static void printSchedule(Job[] sortedList)
        {
            Console.WriteLine("Schedule is: ");
            foreach (Job job in sortedList)
            {
                Console.WriteLine(job.jobName);
            }
        }
    }
}

