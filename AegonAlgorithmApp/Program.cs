using System;

namespace AegonAlgorithmApp
{
    /// <summary>
    ///  Requirements:
    ///    1. If the required functionality was achieved
    ///    2. Code quality: how are the best practices/principles followed(things like code readability and separation of concerns)
    ///    3. (not mandatory!!!) Testing: either unit tests(preferred) or a Console App that uses the implementation in different scenarios(not mandatory)
    ///    4. Algorithm efficiency – not as important as the first 3 points
    ///    5. Anything else you think it’s useful
    ////// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            string inputPhrase = "     - You are      awesome?";
            string outputPhrase = AlgorithmController.GetResult(inputPhrase);
            Console.WriteLine(outputPhrase);
            Console.ReadLine();
        }
    }
}
