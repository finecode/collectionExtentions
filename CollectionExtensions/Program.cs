using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Enumerable of size 7 (abc1, abc2,...abc7)
            var ints = Enumerable.Range(1, 7);
            var strings = ints.Select(o => "abc" + o.ToString());

            // Chunk it into groups of 3 elements
            var groups = strings.Chunk<String>(3);  

            // Creates CSV strings from each chunked group
            var csvStrings = groups.Select(o => String.Join(",", o.ToArray<String>()) + "\n");

            csvStrings.Print<String>();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

    public static class CollectionExtensions
    {
        /*
         * Chunks IEnumerable to several IEnumarables
         * 
         * [1,2,3,4,5,67] => [[1,2,3],[4,5,6],[7]]
         * 
         */
 
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source.Where((x, i) => i % chunkSize == 0).Select((x, i) => source.Skip(i * chunkSize).Take(chunkSize));
        }

        /*
         * Prints an IEnumarable
         * 
         */
        public static void Print<T>(this IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
