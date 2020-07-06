using NUnit.Framework;
using AFS.APIConsumers;
namespace AFSTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        /// <summary>
        /// Positive testing was not possible due to the fact that the API returns every time different value
        /// </summary>
        /// <param name="expectedResult"></param>
        /// <param name="givenInput"></param>
        [Test]
        [TestCase("PYER\\/\\/5Zy 73St", "pierwszy test")]
        [TestCase("Bardz() DluG! I DzYW]\\[y Nap15 DO 735Tow4nia", "bardzo dlugi i dziwny napis do testowania")]
        public void Test1(string expectedResult, string givenInput)
        {
            LeetSpeakConsumer leetSpeakConsumer = new LeetSpeakConsumer();
            string leetSpeakJson = leetSpeakConsumer.GetLeetTextJSON(givenInput);
            string result = leetSpeakConsumer.GetLeetText(leetSpeakJson);
            Assert.AreEqual(expectedResult, result);
        }
    }
}