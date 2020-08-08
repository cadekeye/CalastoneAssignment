using CalastoneLibrary;
using NUnit.Framework;
using System;


namespace CalastoneUnitTest
{
    [TestFixture]
    public class UtilityTest
    {

        [TestCase("abcdfg;'")]
        public void TestRemoveNonAlphaCharacter(string input)
        {
            IUtility _utility = new Utility();

            var actual = _utility.RemoveNonAlphaCharacter(input)
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual("abcdfg", actual);

        }

        [TestCase(";'")]
        [TestCase(";.[]()'")]
        [TestCase("")]
        public void TestRemoveNonAlphaCharacterReturnEmpty(string input)
        {
            IUtility _utility = new Utility();

            var actual = _utility.RemoveNonAlphaCharacter(input)
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual("", actual);
            Assert.IsEmpty(actual);

        }

        [TestCase("c:\\caleb\\calastone.txt")]
        public void TestReadTextFileContents(string filePath)
        {
            IUtility _utility = new Utility();

            var actual = _utility.ReadTextFileContentsAsync(filePath)
                .GetAwaiter()
                .GetResult();

            Assert.IsNotEmpty(actual);
            Assert.IsTrue(actual.Contains("Alice"));

        }

        [TestCase("")]
        public void TestReadTextFileContentsWithInvalidPathRaisedException(string filePath)
        {
            IUtility _utility = new Utility();

            Assert.Throws<ArgumentException>(() => _utility.ReadTextFileContentsAsync(filePath).GetAwaiter().GetResult());
  
        }
    }
}
