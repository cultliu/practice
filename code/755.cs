namespace c755{
using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int[] PourWater(int[] height, int count, int index)
    {
        for (int j = 0; j < count; j++)
        {
            int move = index;
            for (int i = index-1; i>=0; i--)
            {
                if (height[i]<height[move])
                {
                    move = i;
                }

                if ((i == 0 || height[i-1] > height[i]) && move != index)
                {
                    height[move]++;
                    break;
                }
            }

            if (move == index)
            {
                for (int i = index+1; i<height.Length; i++)
                {
                    if (height[i] < height[move])
                    {
                        move = i;
                    }

                    if ((i == height.Length-1 || height[i+1] > height[i]) && move != index)
                    {
                        height[move]++;
                        break;
                    }
                }
            }

            if (move == index) height[move]++;
        }
        
        
        return height;
    }
}
}