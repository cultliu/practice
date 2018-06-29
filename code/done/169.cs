namespace c169{
    public class Solution
    {
        int Do(int[] nums)
        {
            int major = nums[0], count = 1;
            for(int i=1; i<nums.Length; i++)
            {
                if (nums[i] == major)
                {
                    count++;
                    if (count > nums.Length/2)
                    {
                        return major;
                    }
                }
                else
                {
                    if (--count ==0)
                    {
                        major = nums[i];
                        count =1;
                    }
                }
                
            }
            return major;

        }
    }
}