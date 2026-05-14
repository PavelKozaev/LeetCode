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
}