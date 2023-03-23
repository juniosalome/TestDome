/*
    Implement function CountNumbers that accepts a sorted array of unique integers and, 
        efficiently with respect to time used, 
        counts the number of array elements that are less than the parameter lessThan.

    For example, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4) should return 2 because there are two array elements less than 4. 
*/

using System;

public class SortedSearch
{
  
    private static int FindMid(int[] sortedArray, int left, int right, int lessThan)
    {
        var middle = left + (right - left) / 2; 

        if (sortedArray[middle] == lessThan) 
        {
            
            while (middle - 1 > 0 && sortedArray[middle - 1] == lessThan) --middle;

            return middle;
        }

        if (middle <= left)
        {
            
            while (middle <= right && sortedArray[middle] < lessThan) ++middle;

            return middle;
        }

        if (sortedArray[middle] < lessThan)
        {
            left = middle;  
        }
        else
        {
            right = middle;  
        }

        return FindMid(sortedArray, left, right, lessThan);
    }

    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        var left = 0;
        var right = sortedArray.Length - 1; 

        return FindMid(sortedArray, left, right, lessThan);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(CountNumbers(new int[] { 1, 3, 5, 7 }, 4)); 
    }
}