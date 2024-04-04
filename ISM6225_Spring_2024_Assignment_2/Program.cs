/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Xml.Linq;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {

                // Write your code here and you can modify the return value according to the requirements
                // corner case:If the array has 0 or 1 element, there are no duplicates to remove
                if (nums.Length <= 1)
                {
                    return nums.Length;
                }
                  
                // Initialize j to 1 because the first element is always unique
                int j = 1;
                // to find length of the array
                int n = nums.Length;
                // using for loop to iterate through array starting from second element
                for (int i =1; i < n; i++) 
                {
                    // iam using this codition to check if the current element is not equal to previous element because this gives unquie element that can be stored back in array
                    if (nums[i] != nums[i-1]) 
                    {
                        // storing unique element in the array
                        nums[j] = nums[i];
                        // incrementing j to count the unique elements
                        j += 1;
                    }
                }
                // returning final number of unique elements.
                return j;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // corner case:If the array has 0 or 1 element, there are no zeros to move
                if (nums.Length <= 1)
                    return new List<int>(nums);

                // initializing a variable to keep track of the position to place the  non zero elements;
                int j = 0;
                // using this to find the length of the array
                int n = nums.Length;
                // iterating through every element
                for (int i = 0; i < n; i++) 
                {
                    // condition to check non zero element
                    if (nums[i] != 0) 
                    {
                        // moving non zero element to front of the array 
                        nums[j] = nums[i];
                        // incrementing  postion to place the next non zero element
                        j++; 
                    }
                }
                // using for loop to fill remaining posistions to zero
                for (int i = j; i < n; i++)
                {
                    // assigning the value to zero
                    nums[i] = 0; 
                }
                // returning the new array
                return new List<int>(nums);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Initializing the result list to store the triplets                                             
                IList<IList<int>> result = new List<IList<int>>();
                // Sorting the array to handle duplicates 
                Array.Sort(nums);
                // to fine Length of the array
                int n = nums.Length;
                //corner case: If the array has less than 3 elements, it's not possible to find triplets
                if (n < 3)
                {
                    return new List<IList<int>>(result);

                }
                    
                // Fixing the first element (i) and using two pointers (j and k) to find the other two elements
                for (int i = 0; i < n - 2; i++) 
                {
                    // Skip duplicate values for i
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    //Initializing j pointer
                    int j = i + 1;
                    // Initializing k pointer
                    int k = n - 1;

                    // Iterating while left pointer is less than right pointer
                    while (j < k) 
                    {
                        // Calculating the sum of three elements
                        int sum = nums[i] + nums[j] + nums[k];

                        // If sum is zero, adding the triplet to the result list
                        if (sum == 0) 
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[k] });

                            // Skipping duplicate values for j pointer
                            while (j < k && nums[j] == nums[j + 1])
                                j++;

                            // Skipping duplicate values for k pointer
                            while (j < k && nums[k] == nums[k - 1])
                                k--;

                            // Moving j pointer forward and k pointer backward
                            j++;
                            k--;
                        }
                        // If sum is less than zero, moving j pointer forward
                        else if (sum < 0)
                        {
                            j++;
                        }
                        // If sum is greater than zero, moving k pointer backward
                        else
                        {
                            k--;
                        }
                    }
                }
                // returning multiple  triplets as array
                return new List<IList<int>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirement
                // corner case:Check if the array is empty
                if (nums.Length == 0)
                {
                    return 0;
                }
                // Initialize variables to track maximum consecutive  and current consecutive 
                int maxConsecutive = 0;
                int currentConsecutive = 0;

                // Iterating through the array
                foreach (int num in nums)
                {
                    // If current element is 1, incrementing current consecutive  count
                    if (num == 1)
                    {
                        currentConsecutive++;
                    }
                    else
                    {
                        // If current element is 0, updating max consecutive if needed
                        if (currentConsecutive > maxConsecutive)
                        {
                            maxConsecutive = currentConsecutive;
                        }
                        // Resetting current consecutive ones count
                        currentConsecutive = 0;
                    }
                }

                // Checking and updating max consecutive ones for the last sequence if needed
                if (currentConsecutive > maxConsecutive)
                {
                    maxConsecutive = currentConsecutive;
                }

                // Returning the maximum consecutive ones count
                return maxConsecutive;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // corner case:Checking if the binary input is within the specified range
                if (binary < 1 || binary > 1000000000)
                {
                    throw new ArgumentOutOfRangeException("binary", "Input binary number must be between 1 and 10^9.");
                }

                int decimalValue = 0;
                int baseValue = 1; // Initializing the base value for binary to decimal conversion

                // Iterating through each digit of the binary number from right to left
                while (binary > 0)
                {
                    // Getting the rightmost digit of the binary number
                    int lastDigit = binary % 10;

                    // corner case:Checking if the digit is a valid binary digit (0 or 1)
                    if (lastDigit != 0 && lastDigit != 1)
                    {
                        throw new ArgumentException("Input is not a valid binary number.");
                    }

                    // Updating the decimal value by adding the product of the last digit and the base value
                    decimalValue += lastDigit * baseValue;

                    // Updating the base value by multiplying it by 2 for the next iteration
                    baseValue *= 2;

                    // Removing the rightmost digit from the binary number
                    binary /= 10;
                }

                // Returning the decimal value
                return decimalValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // cornerCase:Checking if the array has less than two elements
                if (nums.Length < 2)
                    return 0;

                // Sorting the array
                Array.Sort(nums);

                // Initializing the maximum gap to 0
                int maxGap = 0;

                // Iterating through the array to find the maximum difference between successive elements
                for (int i = 1; i < nums.Length; i++)
                {
                    // Calculating the difference between successive elements
                    int currentGap = nums[i] - nums[i - 1];

                    // Updating the maximum gap if the current gap is greater
                    if (currentGap > maxGap)
                        maxGap = currentGap;
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // corner case:Checking if the array length is less than 3, as it's not possible to form a triangle with less than three sides
                if (nums.Length < 3)
                    return 0;

                // Sorting the array in non-decreasing order
                Array.Sort(nums);

                // Iterating from the end of the array to find the largest perimeter
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Checking if it's possible to form a triangle with the current side length and the two preceding side lengths
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                    {
                        return nums[i] + nums[i - 1] + nums[i - 2]; // Return the largest perimeter
                    }
                }

                // Corner case:If no valid triangle can be formed, returning 0
                return 0;
            
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // corner case:Checking if either input string is empty
                if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(part))
                {
                    return s;
                }
                // corner case:Converting both the input string and substring to lowercase
                s = s.ToLower();
                part = part.ToLower();

                // Iterating until all occurrences of 'part' are removed from 's'
                while (s.Contains(part))
                {
                    // Finding the index of the leftmost occurrence of 'part'
                    int index = s.IndexOf(part);

                    // Removing 'part' starting from the leftmost occurrence
                    s = s.Remove(index, part.Length);
                }

                // Returning the modified string after removing all occurrences of 'part'
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}