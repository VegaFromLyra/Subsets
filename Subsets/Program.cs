using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>();
            input.Add(1);
            input.Add(2);
            input.Add(3);

            var result = GetSubSets(input);

            foreach (List<int> temp in result)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    Console.Write(temp[i] + " ");
                }

                Console.WriteLine();
            }
        }

        // Given a set of size n,
        // the total number of subsets is O(2 ^ n)
        // Time complexity - O(2 ^ n) ?
        // Space complexity - O(2 ^ n)
        static List<List<int>> GetSubSets(List<int> input)
        {
            List<List<int>> result = new List<List<int>>();

            if (input.Count == 0)
            {
                result.Add(new List<int>());
            }
            else
            {
                int last = input[input.Count - 1];

                input.Remove(last);

                List<List<int>> subset = GetSubSets(input);

                foreach (var item in subset)
                {
                    // Add the item as is then 
                    // create a copy of the item
                    // and add last to it
                    result.Add(item);

                    int[] copyItem = new int[item.Count];
                    item.CopyTo(copyItem);

                    List<int> newList = new List<int>(copyItem);
                    newList.Add(last);

                    result.Add(newList);
                }
            }

            return result;
        }
    }
}
