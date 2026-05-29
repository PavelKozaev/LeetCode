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
    
    
    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        var reader = 1;
        var writer = 1;

        while (reader < nums.Length)
        {
            if (nums[reader] != nums[writer - 1])
            {
                nums[writer] = nums[reader];
                writer++;
            }
            
            reader++;
        }

        return writer;
    }
    
    
    public static void MoveZeroes(int[] nums)
    {
        var slow = 0;
        var fast = 0;

        while (fast < nums.Length)
        {
            if (nums[fast] != 0)
            {
                (nums[slow], nums[fast]) = (nums[fast], nums[slow]);
                slow++;
            }

            fast++;
        }
    }
    
    
    public static int[] TwoSum(int[] numbers, int target) 
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (left < right)
        {
            if (numbers[left] + numbers[right] < target)
            {
                left++;
            }
            else if (numbers[left] + numbers[right] > target)
            {
                right--;
            }
            else
            {
                return [left + 1, right + 1];
            }
        }

        return [];
    }
    
    
    public static IList<IList<int>> ThreeSum(int[] nums) 
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();
        
        for (var i = 0; i <= nums.Length - 3; i++)
        {
            if (nums[i] > 0)
            {
                break;
            }
            
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                
                if (sum < 0)
                {
                    left++;
                }
                else if (sum > 0)
                {
                    right--;
                }
                else
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    left++;
                    right--;

                    while (left < right && nums[left] == nums[left - 1])
                    {
                        left++;
                    }
                    
                    while (left < right && nums[right] == nums[right + 1])
                    {
                        right--;
                    }
                }
            }
        }

        return result;
    }


    public static int Compress(char[] chars)
    {
        var write = 0;

        for (int read = 0, count = 0; read < chars.Length; read++)
        {
            count++;

            if (read == chars.Length - 1 || chars[read] != chars[read + 1])
            {
                chars[write++] = chars[read];

                if (count > 1)
                {
                    foreach (var c in count.ToString())
                    {
                        chars[write++] = c;
                    }
                }

                count = 0;
            }
        }
        
        return write;
    }


    public static int CompareVersion(string version1, string version2)
    {
        int i = 0, j = 0;

        while (i < version1.Length || j < version2.Length)
        {
            int num1 = 0, num2 = 0;

            while (i < version1.Length && version1[i] != '.')
            {
                num1 = num1 * 10 + (version1[i] - '0');
                i++;
            }
            
            while (j < version2.Length && version2[j] != '.')
            {
                num2 = num2 * 10 + (version2[j] - '0');
                j++;
            }

            if (num1 < num2) return -1;
            if (num1 > num2) return 1;

            if (i < version1.Length) i++;
            if (j < version2.Length) j++;
        }
        
        return 0;
    }
}