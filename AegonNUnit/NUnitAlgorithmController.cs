using AegonAlgorithmApp;
using NUnit.Framework;

namespace AegonNUnit
{
    [TestFixture]
    public class NUnitAlgorithmController
    {
        [Test]
        public void When_Is_The_Given_Phrase()
        {
            //Arrange
            string inputPhrase = "     - You are      awesome?";

            //Act
            var outputPhrase = AlgorithmController.GetResult(inputPhrase);
            
            //Assert
            Assert.AreEqual("     - Awesome are you?     ", outputPhrase);
        }

        [Test]
        public void When_Phrase_Contains_Special_Character_At_The_End()
        {
            //Arrange
            string inputPhrase = "Ana are mere?";

            //Act
            var outputPhrase = AlgorithmController.GetResult(inputPhrase);

            //Assert
            Assert.AreEqual("Mere are ana?", outputPhrase);
        }

        [Test]
        public void When_Phrase_Starts_With_Special_Character()
        {
            //Arrange
            string inputPhrase = "-Ana are mere";

            //Act
            var outputPhrase = AlgorithmController.GetResult(inputPhrase);

            //Assert
            Assert.AreEqual("-Mere are ana", outputPhrase);
        }

        [Test]
        public void When_Phrase_DoesNot_Contains_Any_Special_Character()
        {
            //Arrange
            string inputPhrase = "Ana are mere";

            //Act
            var outputPhrase = AlgorithmController.GetResult(inputPhrase);

            //Assert
            Assert.AreEqual("Mere are ana", outputPhrase);
        }

        [Test]
        public void When_Phrase_Contains_Special_Character_Anywhere()
        {
            //Arrange
            string inputPhrase = "  -Ana are mere?";

            //Act
            var outputPhrase = AlgorithmController.GetResult(inputPhrase);

            //Assert
            Assert.AreEqual("  -Mere are ana?  ", outputPhrase);
        }

        [Test]
        public void When_Is_Random_Phrase()
        {
            //Arrange
            string inputPhrase = "Eu merg la Bucuresti iar Tu la Timisoara";

            //Act
            var outputPhrase = AlgorithmController.GetResult(inputPhrase);

            //Assert
            Assert.AreEqual("Timisoara la tu iar bucuresti la merg eu", outputPhrase);
        }
    }
}
