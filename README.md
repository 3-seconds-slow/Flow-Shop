# Flow-shop scheduling
The flow-shop scheduling problem is a type of job scheduling problem where there n jobs that need to be processed on m machines in a strict order, where the ith operation needs to be performed on the ith machine. The goal is to minimise the make span, Cmax. In other words, given a bunch of jobs that need to be processed by machine A, then machine B, etc, what order should the jobs be performed to finish in the shortest amount of time? This problem can be solved optimally for 2 machine shops using Johnson's Rule
## Johnson's rule
Johnson's rule can be used to solve the flow-shop problem provided the following conditions are met:
- The time for each job must be invariant with respect to when it is done.
- Job times must be independent of the job sequence.
- All jobs must be processed in the first machine before going through the second machine.
- All jobs have the same priority.

Johnsons's rule is as follows:
1. Get the jobs and their time on each machine
2. Select the job with the shorest time on a machine. If the time is on machine 1, then schedule it first. If it is on machine 2, schedule it last. if it's thesame on both, pick one arbitrarily
3. Remove this job from the list
4. repeat step 2 and 3 until all jobs are scheduled

Johnson's rule can also be use to find an optimal solution in 3 machine shops, provided that the quickest job on machine 1 or 3 is larger than the slowest job on machine 2. If this condition is met, then a solution can be found by adding the time of machines 1 and 2, and 2 and 3 together so Johnson's Rule for 2 machines can be applied

My code implements Johnson's Rule to provide solutions for 2 and 3 machine problems
