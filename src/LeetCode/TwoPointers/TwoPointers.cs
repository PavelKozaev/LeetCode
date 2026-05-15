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
}