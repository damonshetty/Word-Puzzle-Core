using Xunit;
using InterfacesDictionaryData;
using Data_Access_Layer;
using Business;

namespace XUnit_Tests
{
    public class UnitTest1
    {
        [Fact(Skip = "Not required")]
        public void LoadDictionaryData()
        {
            //Arrange
            IDictionaryData iDictionaryData = new clsDictionaryData();

            //Act
            var DictionaryFile = iDictionaryData.DictionaryFile;

            //Assert
            
        }
                  

        [Fact]
        public void GivenTwoWordsWithOneLetterDifferenceReturnTrue()
        {
            //Arrange
            IDictionaryData iDictionaryData = new clsDictionaryData();
            ITransform iTransform = new WordTransform(iDictionaryData);

            //Act
            var isOneLetterDifferent = iTransform.IsOneLetterDifferent("Back", "Bach");

            //Assert
            Assert.True(isOneLetterDifferent);   
        }

        [Theory]
        [InlineData("back", "bach")]
        [InlineData("ship", "shop")]
        public void GivenTwoStringsWithOneLetterDifferenceReturnTrue(string StartWord, string EndWord)
        {
            //Arrange
            IDictionaryData iDictionaryData = new clsDictionaryData();
            ITransform iTransform = new WordTransform(iDictionaryData);

            //Act
            var isOneLetterDifferent = iTransform.IsOneLetterDifferent(StartWord, EndWord);

            //Assert
            Assert.True(isOneLetterDifferent);
        }

        [Fact]
        public void GivenTwoWordsCheckWhichLetterDifferent()
        {
            //Arrange
            IDictionaryData iDictionaryData = new clsDictionaryData();
            ITransform iTransform = new WordTransform(iDictionaryData);

            //Act
            var CheckWhichLetterDifferent = iTransform.CheckWhichLetterDifferent("back", "bach");

            //Assert
            Assert.Equal(3, CheckWhichLetterDifferent);
        }

        [Fact]
        public void GivenTwoWordsShouldIAddExpectFalse()
        {
            //Arrange
            IDictionaryData iDictionaryData = new clsDictionaryData();
            ITransform iTransform = new WordTransform(iDictionaryData);

            //Act
            var shouldAdd = iTransform.ShouldAddWord(3, "back", "bach");

            //Assert
            Assert.False(shouldAdd);
        }


        [Fact]
        public void GivenTwoWordsShouldIAddExpectTrue()
        {
            //Arrange
            IDictionaryData iDictionaryData = new clsDictionaryData();
            ITransform iTransform = new WordTransform(iDictionaryData);

            //Act
            var shouldAdd = iTransform.ShouldAddWord(3, "spit", "spot");

            //Assert
            Assert.True(shouldAdd);
        }

    }
}
