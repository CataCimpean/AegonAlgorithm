using System.Collections.Generic;

namespace AegonAlgorithmApp
{
    /// <summary>
    /// 1.Used to reverse a list 
    /// 2.The algorithm doesen't change order or position of special characters
    /// Complexity: O(n/2) 
    /// </summary>
    public class AlgorithmReverse
    {
        public List<string> ReverseCustomList(List<string> list)
        {
            if (list != null && list.Count > 0)
            {
                int right = list.Count - 1;
                int left = 0;
                int range = list.Count / 2;
                for (int i = 0; i <= range; i++)
                {
                    if (list.Count % 2  == 0 ? StringUtilities.ContainSpecialCharacter(list[left])
                        : StringUtilities.ContainSpecialCharacter(list[left],true))
                        left++;
                    else if  (list.Count % 2  == 0 ? StringUtilities.ContainSpecialCharacter(list[right])
                        : StringUtilities.ContainSpecialCharacter(list[right],true))
                        right--;
                    else
                    {
                        var tmp = list[left];
                        list[left] = list[right];
                        list[right] = tmp;

                        left++;
                        right--;
                    }
                }
            }
            return list;
        }
    }
}
