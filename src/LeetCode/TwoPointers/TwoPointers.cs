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

    
    public static int MaxArea(int[] height)
    {
        int max = 0, left = 0, right = height.Length - 1;

        while (left < right)
        {
            var temp = (right - left) * Math.Min(height[left], height[right]);

            max = Math.Max(max, temp);

            if (height[left] < height[right]) left++;
            else right--;
        }
        
        return max;
    }
    
    
    public static string ReverseVowels(string s)
    {
        var result = s.ToCharArray();

        int left = 0, right = s.Length - 1;
        
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        while (left < right)
        {
            while (left < right && !vowels.Contains(result[left])) left++;
            
            while (left < right && !vowels.Contains(result[right])) right--;

            if (left < right)
            {
                (result[left], result[right]) = (result[right], result[left]);
                left++;
                right--;
            }
        }

        return new string(result);
    }

    
    public static string ReverseOnlyLetters(string s)
    {
        var arr = s.ToCharArray();
        
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetter(arr[left])) left++;
            
            while (left < right && !char.IsLetter(arr[right])) right--;

            if (left < right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++;
                right--;
            }
        }
        
        return new string(arr);
    }


    public static bool IsLongPressedName(string name, string typed)
    {
        int i = 0, j = 0;

        while (j < typed.Length)
        {
            if (i < name.Length && name[i] == typed[j])
            {
                i++;
                j++;
            }
            else if (j > 0 && typed[j] == typed[j - 1]) j++;
            else return false;
        }
        
        return i == name.Length;
    }


    public static void DuplicateZeros(int[] arr)
    {
        var n = arr.Length;
        var zeros = 0;
        var last = n - 1;

        for (var i = 0; i <= last-zeros; i++)
        {
            if (arr[i] == 0)
            {
                if (i == n - 1 - zeros)
                {
                    arr[n - 1] = 0;
                    last--;
                    break;
                }
                
                zeros++;
            }
        }

        int writeIdx = last - zeros;

        for (var i = writeIdx; i >= 0; i--)
        {
            if (arr[i] == 0)
            {
                arr[i + zeros] = 0;
                zeros--;
                arr[i + zeros] = 0;
            }
            else
            {
                arr[i + zeros] = arr[i];
            }
        }
    }


    public static int[] SortArrayByParity(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            if (nums[left] % 2 == 0)
            {
                left++;
            }
            else if (nums[right] % 2 != 0)
            {
                right--;
            }
            else
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
        
        return nums;
    }
}