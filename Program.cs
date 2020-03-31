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

        /* Example of a docstring */
        /// <summary>
        /// Returns the first value remaining from the List.
        /// 
        /// It replaces the value with -1 to 'delete' it, so this number
        /// is special.
        /// 
        /// It's OK to do this only because we are only sorting positive
        /// numbers.  This would need a rewrite if we were to use negatives!
        /// </summary>
        /// <returns>int representing the value, or -1 if list is empty</returns>
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

            /* Let's fill the unsorted list with all sorts of junk */
            unsortedList.Randomise();
            unsortedList.Print();

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
