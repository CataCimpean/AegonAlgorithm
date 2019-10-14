namespace AegonAlgorithmApp
{
    public class AlgorithmController
    {
        public static string GetResult(string inputPhrase)
        {
            var outputPhrase = string.Empty;
            var inputList = new AlgorithmSplit().SplitCustomString(inputPhrase);
            inputList = new AlgorithmReverse().ReverseCustomList(inputList);
            outputPhrase = StringUtilities.LogicLowerUper(string.Join(string.Empty, inputList.ToArray()));
            return outputPhrase;
        }
    }
}
