using System.Linq;

namespace AegonAlgorithmApp
{
    /// <summary>
    /// Used to do some operations on a string
    /// </summary>
    public class StringUtilities
    {
        public static bool ContainSpecialCharacter(string str, bool withSpace = false)
        {
            if (withSpace)
                return str.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c));
            else
                return str.Any(c => !char.IsLetterOrDigit(c));
        }

        /// <summary>
        /// After reverse order of words from phrasese: 
        /// First word allways will be with first letter to UperCase, and last word will be normal.
        /// </summary>
        public static string LogicLowerUper(string inputWord)
        {
            var outputString = string.Empty;
            int firstLetter = -1;
            if (inputWord != null && inputWord != string.Empty)
            {
                for (int i = 0; i < inputWord.Length; i++)
                {
                    if (char.IsLetter(inputWord[i]) && firstLetter++ == -1)
                        outputString += inputWord[i].ToString().ToUpper();
                    else
                        outputString += inputWord[i].ToString().ToLower();
                }
            }
            return outputString;
        }
    }
}
