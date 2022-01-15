using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Tests
{
    [TestFixture]
    public class TasksUnitTests
    {
        [Test]
        public void GetIntegersFromList_WhenPassList_ReturnsOnlyListOfIntegers()
        {
            var actual = Program.GetIntegersFromList(new List<object> { 1, "a", 2, "b", "c", 3 });

            CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(int));
        }

        [Test]
        public void GetIntegersFromList_WhenPassOnlyStrings_ReturnsEmptyList()
        {
            var actual = Program.GetIntegersFromList(new List<object> { "a", "b", "c" });

            Assert.That(!actual.Any());
        }

        [Test]
        public void GetFirstNonRepeatingLetter_WhenPassStringWithNonRepeting_ReturnsFirstNonRepeatingLetter()
        {
            var actual = Program.GetFirstNonRepeatingLetter("Stress");
            Assert.That(actual == 't');
        }
        [Test]
        public void GetFirstNonRepeatingLetter_WhenPassStringWithNonRepeting_ReturnsEmptyChar()
        {
            var actual = Program.GetFirstNonRepeatingLetter("ttrreess");
            Assert.That(actual == '-');
        }

        [Test]
        public void GetSumOfAllDigitsInANumber_WhenPass16_Returns7()
        {
            var actual = Program.GetSumOfAllDigitsInANumber(16);
            Assert.That(actual == 7);
        }

        [Test]
        public void GetSumOfAllDigitsInANumber_WhenPass493193_Returns2()
        {
            var actual = Program.GetSumOfAllDigitsInANumber(493193);
            Assert.That(actual == 2);
        }

        [Test]
        public void CountNumberOfPairsInTheArrayWhichSumIsEqualToTargetValue_WhenPassArrAndTarget5_Returns4()
        {
            var arr = new int[] { 1, 3, 6, 2, 2, 0, 4, 5 };
            var target = 5;

            var actual = Program.CountNumberOfPairsInTheArrayWhichSumIsEqualToTargetValue(arr, target);

            Assert.That(actual == 4);
        }

        [Test]
        public void CountNumberOfPairsInTheArrayWhichSumIsEqualToTargetValue_WhenPassEmptyArrAndTarget0_Returns0()
        {
            var arr = new int[] { };
            var target = 0;

            var actual = Program.CountNumberOfPairsInTheArrayWhichSumIsEqualToTargetValue(arr, target);

            Assert.That(actual == 0);
        }

        [Test]
        public void GetOrderedFriends_WhenCalled_ReturnsWellFormatedStringOfFriends()
        {
            var expected = "(Corwill, Alfred)(Corwill, Fired)(Corwill, Raphael)(Corwill, Wilfred)(Tornbull, Betty)(Tornbull, Bjon)(TornBull, Barney)";

            var actual = Program.GetOrderedFriends();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTheNextBiggerNumberByRearranging_WhenPass12_Returns21()
        {
            var actual = Program.GetTheNextBiggerNumberByRearranging(12);

            Assert.That(actual == 21);
        }

        [Test]
        public void GetTheNextBiggerNumberByRearranging_WhenPass9_ReturnsMinus1()
        {
            var actual = Program.GetTheNextBiggerNumberByRearranging(9);

            Assert.That(actual == -1);
        }
    }
}
