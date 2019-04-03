using System.Collections.Generic;

public class CoupleWithGivenSum
{
    public static List<string> GetCouples(int[] values, int expectedSum)
    {
        // merge sort : O(n.log n)
        MergeSort(values);

        // look for the couples that match the sum : O(n)
        return LookForCouples(values, expectedSum);

        // Final complexity : O(n.log n) + O(n) = O(n.log n)
    }

    public static void MergeSort(int[] values)
    {
        MergeSort(values, 0, values.Length);
    }

    /// <summary>
    /// Merge sort part of a table.
    /// 1. Cut in halves
    /// 2. Sort each half
    /// 3. Merge the two sorted parts
    /// Use additionnal space to store the merge result
    /// </summary>
    /// <param name="values">Values to sort</param>
    /// <param name="start">Index of the window start</param>
    /// <param name="length">Length of the window</param>
    private static void MergeSort(int[] values, int start, int length)
    {
        if (length == 1)
            return;

        var halfSize = length / 2;
        var secondHalfSize = length - halfSize;

        var middle = start + halfSize;

        MergeSort(values, start, halfSize);
        MergeSort(values, middle, secondHalfSize);

        var mergedHalves = Merge(values, start, length, middle, halfSize, secondHalfSize);

        for (var i = 0; i < length; i++)
        {
            values[start + i] = mergedHalves[i];
        }
    }

    private static int[] Merge(int[] values, int start, int length, int middle, int halfSize, int secondHalfSize)
    {
        var mergedHalves = new int[length];
        var currentMergeIndex = 0; // index in the merge table
        var currentFirstHalfIndex = start; // index in the original table
        var currentFirstHalfValue = values[currentFirstHalfIndex];
        var currentSecondHalfIndex = middle; // index in the original table
        var currentSecondHalfValue = values[currentSecondHalfIndex];
        while (currentMergeIndex < length)
        {
            if (currentFirstHalfIndex >= start + halfSize)
            {
                // all elements of the first half have been merged already
                currentSecondHalfValue = values[currentSecondHalfIndex];
                mergedHalves[currentMergeIndex] = currentSecondHalfValue;
                currentSecondHalfIndex++;
            }
            else if (currentSecondHalfIndex >= middle + secondHalfSize)
            {
                // all elements of the second half have been merged already
                mergedHalves[currentMergeIndex] = currentFirstHalfValue;
                currentFirstHalfIndex++;
                currentFirstHalfValue = values[currentFirstHalfIndex];
            }
            else if (currentFirstHalfValue > currentSecondHalfValue)
            {
                mergedHalves[currentMergeIndex] = currentSecondHalfValue;
                currentSecondHalfIndex++;
                currentSecondHalfValue = values[currentSecondHalfIndex];
            }
            else
            {
                mergedHalves[currentMergeIndex] = currentFirstHalfValue;
                currentFirstHalfIndex++;
                currentFirstHalfValue = values[currentFirstHalfIndex];
            }

            currentMergeIndex++;
        }

        return mergedHalves;
    }

    /// <summary>
    /// Look for couples with a given sum in an ascending sorted table.
    /// Start with a the smallest (first element) and the greatest (last element)
    /// While the sum is greater than expected sum, decrease the index of the last element
    /// If a couple has expected sum, store it, increase index of the first element and decrease index of the last element until the element values change
    /// When the sum becomes less than expected, go back to the previous last element and increase the index of the first
    /// Do it until both index meet
    /// </summary>
    /// <param name="values">Values</param>
    /// <param name="expectedSum">Sum of the couples</param>
    /// <returns>List of pre-printed couples</returns>
    private static List<string> LookForCouples(int[] values, int expectedSum)
    {
        var couples = new List<string>();
        var firstElementIndex = 0;
        var firstElementValue = values[firstElementIndex];
        var secondElementIndex = values.Length - 1;
        var secondElementValue = values[secondElementIndex];

        while (firstElementIndex < secondElementIndex)
        {
            if (firstElementValue + secondElementValue > expectedSum)
            {
                secondElementIndex--;
                secondElementValue = values[secondElementIndex];
            }
            else if (firstElementValue + secondElementValue < expectedSum)
            {
                firstElementIndex++;
                firstElementValue = values[firstElementIndex];
            }
            else
            {
                couples.Add($"[{firstElementValue}, {secondElementValue}]");
                while (firstElementIndex < secondElementIndex + 1 && firstElementValue == values[firstElementIndex + 1])
                {
                    firstElementIndex++;
                }
                firstElementIndex++;
                firstElementValue = values[firstElementIndex];
                while (firstElementIndex < secondElementIndex + 1 && secondElementValue == values[secondElementIndex - 1])
                {
                    secondElementIndex--;
                }
                secondElementIndex--;
                secondElementValue = values[secondElementIndex];
            }
        }

        return couples;
    }
}