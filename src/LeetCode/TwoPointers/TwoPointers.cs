namespace LeetCode.TwoPointers;

public static class TwoPointers
{
    public static void ReverseString(char[] s)
    {
        var left = 0;
        var right = s.Length - 1;
        
        while (left < right)
        {
            (s[left], s[right]) = (s[right], s[left]);
            
            left++;
            right--;
        }
    }

    
    public static bool IsPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }

            while (left < right && !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }

            if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
    
    
    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        var k = m + n - 1;

        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }

            k--;
        }

        while (j >= 0)
        {
            nums1[k] = nums2[j];
            j--;
            k--;
        }
    }

    
    public static int[] Intersection(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var result = new List<int>();

        var i = 0;
        var j = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
            {
                if (result is { Count: 0 } || result[^1] != nums1[i])
                {
                    result.Add(nums1[i]);
                }
                
                i++;
                j++;
            }
            else if (nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }
        
        return result.ToArray();
    }
    
    
    public static int[] SortedSquares(int[] nums)
    {
        var result = new int[nums.Length];

        var left = 0;
        var right = nums.Length - 1;
        var pos = nums.Length - 1;

        while (left <= right)
        {
            var leftSquare = nums[left] * nums[left];
            var rightSquare = nums[right] * nums[right];
            
            if (leftSquare >= rightSquare)
            {
                result[pos] = leftSquare;
                left++;
            }
            else
            {
                result[pos] = rightSquare;
                right--;
            }

            pos--;
        }

        return result;
    }
}