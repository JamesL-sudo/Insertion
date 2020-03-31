using System;

namespace Insertion
{
    class SortingList
    {
        private int[] list;
        public readonly int Length;

        public SortingList(int requiredLength)
        {
            Length = requiredLength;
            list = new int[Length];
        }

        public void Randomise()
        {
            var random = new Random();

            for (int i = 0; i < list.Length; i++)
                list[i] = random.Next(50);
        }

        public void Print()
        {
            foreach (int i in list)
                Console.Write(String.Format("{0}, ", i));
            Console.WriteLine("");
        }

        public void Insert(int value)
        {
            /* First, find the right place for the item to go in */
            for (int i = 0; i < Length; i++)
            {
                if (list[i] == 0)
                {
                    /* There is nothing in this place, so just take it */
                    list[i] = value;
                    break;
                }
                if (value < list[i])
                {
                    /* We need to shift everything along one, so start at 
                     * the end and copy the whole list along
                     */
                    for (int j = list.Length - 1; j > i; j--)
                        list[j] = list[j - 1];

                    list[i] = value;
                    break;
                }
            }
            this.Print();
        }
    class BubbleSort{
            private int[] list;
            public readonly int Length;

            public SortingList2(int requiredLength){
                Length = requiredLength;
                list = new int[Length];
            }
            public void Randomise(){
                var random = new Random();
                for (inr i =0;i<list.Length;i++){
                    list[i]= random.next(50);
                }
            }
            public void Print(){
                for(int i=0;i<list.Length;i++){
                    Console.Write(list[i]);
                    Console.Write(", ");
                }
            }
            public void Sort(){
                for(int j=0;j<list.Length;j++){
                    for(int i=0;i<list.Length-1;i++){
                        if (list[i]>list[i+1]){
                            var temp = list[i+1];
                            list[i+1] = list[i];
                            list[i] = temp;
                        }
                    }
                }
            }
        }

        public int Pop()
        {
            int ret = -1;

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != -1)
                {
                    ret = list[i];
                    /* 'Delete' the value */
                    list[i] = -1;
                    break;
                }
            }

            /* If no values found, ret remains as -1 */
            return (ret);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var unsortedList = new SortingList(10);
            var sortedList = new SortingList(unsortedList.Length);
            var Bubblelist = new SortingList2(10);
            /* Let's fill the unsorted list with all sorts of junk */
            unsortedList.Randomise();
            unsortedList.Print();
            Bubblelist.Print();
            Bubblelist.Sort();
            /* This is where we do the insertion sort-- doesn't
             * object oriented make this look easy? */

            for (int i = 0; i < unsortedList.Length; i++)
            {
                sortedList.Insert(unsortedList.Pop());
            }

            sortedList.Print();
        }
    }
}
