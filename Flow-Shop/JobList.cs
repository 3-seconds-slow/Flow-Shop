namespace FlowShop
{
    //modified linked list class for sorting and holding data for jobs on one machine
    internal class JobList
    {
        private Node head;
        private Node tail;

        public JobList()
        {
            head = null;
            tail = null;
        }

        //add new node in proper loction using insertion sort. update head and tail pointers to ensure they point at the smallest and
        //largest values respectively
        public void Add(double key, Job data)
        {
            Node newNode = new Node(key, data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else if (key <= head.key)
            {
                if(head.next == null)
                {
                    tail = head;
                }
                newNode.next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null && current.next.key < key)
                {
                    current = current.next;
                }

                if (current.next == null)
                {
                    tail = newNode;
                }

                newNode.next = current.next;
                current.next = newNode;
            }
        }

        //return the smllest processing time
        public double getMinKey()
        {
            return head.key;
        }

        //return the largest processing time
        public double getMaxKey()
        {
            return tail.key;
        }

        //remove and retun head node from list
        public Job pop()
        {
            Node current = head;
            head = current.next;
            return current.data;
        }

        //remove a specific job from the list 
        public void remove(Job data)
        {
            Node current = head;
            Node previous = null;
            while(current.data != data) 
            {
                previous = current;
                current = current.next; 
            }
            if(previous != null)
            {
                previous.next = current.next;
            }
            else
            {
                head = current.next;
            }
            
        }

        //checks if list is empty
        public bool isEmpty()
        {
            return head == null;
        }

        //prints the list
        override
        public String ToString()
        {
            string s = "";
            Node current = head;

            while (current != null)
            {
                s = s + current.key + ", ";
                current = current.next;
            }
            s = s + "MinKey: " + getMinKey() + ", MaxKey: " + getMaxKey();
            return s;
        }
    }

    //list node class. holds key (processing time), data (Job) and pointer to next node
    class Node
    {
        public double key;
        public Job data;
        public Node next;

        public Node(double key, Job data)
        {
            this.key = key;
            this.data = data;
            this.next = null;
        }
    }
}
