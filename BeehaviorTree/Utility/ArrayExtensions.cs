using System;
using System.Collections.Generic;
using System.Text;

namespace BeehaviorTree.Utility
{
    public static class ArrayExtensions
    {
        public static T[] Shuffle<T>(this T[] items)
        {
            int counter = items.Length;
            T[] array = items;

            while(counter > 1)
            {
                counter--;
                int index = RandomGenerator.GetRandomInt(counter + 1);
                T value = array[index];

                array[index] = array[counter];
                array[counter] = value;
            }

            return array;
        }
    }
}
