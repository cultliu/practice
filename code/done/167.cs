namespace c167{
    public class Solution
    {
        int[] TwoSum(int[] numbers, int target)
        {

            int low = 0, high = numbers.Length-1;
            high = FindClosest(numbers, target-numbers[0]);

            while(low < high)
            {
                var sum = numbers[low] + numbers[high];
                if (sum == target)
                {
                    return new int[] {low+1, high+1};
                }
                else if (sum > target)
                {
                    high--;
                }
                else
                {
                    low++;
                }
            }
            return new int[]{0,0};
        }

        int FindClosest(int[] nums, int target)
        {
            int low = 0, high = nums.Length-1;
            while (low < high-1)
            {
                int mid =  (low + high)/2;
                if (nums[mid] >= target && nums[mid-1] < target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
            return high;
        }
    }
}