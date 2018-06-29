namespace c162{
    public class Solution
    {
        int Do(int[] nums)
        {
            int low = 0, high = nums.Length;
            while(low < high-1)
            {
                int mid = (low+high)/2;
                if (nums[mid-1] > nums[mid])
                {
                    high = mid;
                }
                else if (nums[mid+1]> nums[mid])
                {
                    low = mid;
                }
                else 
                {
                    return mid;
                }
            }
            return (low != high && nums[low] > nums[high])? low : high;
        }
    }
}