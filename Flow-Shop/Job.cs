namespace FlowShop
{
    //Class for storing job name and processing times
    public class Job
    {
        public string jobName { get; set; }
        public double MachineATime { get; set; }
        public double MachineBTime { get; set; }
        public double MachineCTime { get; set; }

        public Job (string jobName, double MachineATime, double MachineBTIme)
        {
            this.jobName = jobName;
            this.MachineATime = MachineATime;
            this.MachineBTime = MachineBTIme;
        }

        public Job(string jobName, float MachineATime, float MachineBTIme, float MachineCTime)
        {
            this.jobName = jobName;
            this.MachineATime = MachineATime;
            this.MachineBTime = MachineBTIme;
            this.MachineCTime = MachineCTime;
        }
    }
}
