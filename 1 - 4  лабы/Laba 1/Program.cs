

/*using System;

public class HelloWorld
{
   public static void Main()
   {
       /* задание 1
       string J = Console.ReadLine();
       string S = Console.ReadLine();

       int count = 0;

       foreach (char stone in S)
       {
           if (J.Contains(stone))
           {
               count++;
           }
       }

       Console.WriteLine($"Количество драгоценностей в камнях: {count}");
   */

/*using System;
using System.Collections.Generic;
2 задание
class Program
{
    static void Main()
    {
        int[] candidates1 = {2, 5, 2, 1, 2};
        int target1 = 5;
        Console.WriteLine("Уникальные комбинации для target = " + target1 + ":");
        Console.WriteLine(string.Join(", ", CombinationSum(candidates1, target1)));

        int[] candidates2 = {10, 1, 2, 7, 6, 1, 5};
        int target2 = 8;
        Console.WriteLine("Уникальные комбинации для target = " + target2 + ":");
        Console.WriteLine(string.Join(", ", CombinationSum(candidates2, target2)));
    }
    
    static List<List<int>> CombinationSum(int[] candidates, int target)
    {
        List<List<int>> result = new List<List<int>>();
        Array.Sort(candidates); 
        
        GenerateCombinations(candidates, target, result, new List<int>(), 0);
        return result;
    }

    static void GenerateCombinations(int[] candidates, int target, List<List<int>> result, List<int> current, int index)
    {
        if (target == 0)
        {
            result.Add(new List<int>(current)); 
            return;
        }

        for (int i = index; i < candidates.Length; i++)
        {
           
            if (i > index && candidates[i] == candidates[i - 1])
            {
                continue;
            }

            if (candidates[i] <= target)
            {
                current.Add(candidates[i]); 
                GenerateCombinations(candidates, target - candidates[i], result, current, i + 1); // Рекурсивно вызываем для остатка
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
*/
/*using System;
using System.Collections.Generic;
3 задание
class Program
{
    static void Main()
    {
        int[] nums1 = {1, 2, 3, 4};
        Console.WriteLine("Результат для nums1: " + ContainsDuplicate(nums1));

        int[] nums2 = {1, 1, 1, 3, 3, 4, 3, 2, 4, 2};
        Console.WriteLine("Результат для nums2: " + ContainsDuplicate(nums2));

        int[] nums3 = {1, 2, 3, 1};
        Console.WriteLine("Результат для nums3: " + ContainsDuplicate(nums3));
    }

    static bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(num))
            {
                return true;
            }
            else
            {
                set.Add(num);
            }
        }

        return false;
    }
}
*/
