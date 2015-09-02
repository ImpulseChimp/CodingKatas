using System;
using NUnit.Framework;
using BowlingGameKataCSharp;

namespace BowlingGameKataCSharpTests
{
    [TestFixture]
    public class BowlingGameKataCSharpTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        { 
            game = new Game();       
        }

        [Test]
        public void GameIsCreatedSuccessfully()
        {
            Assert.NotNull(game);
        }

        [Test]
        public void FullGutterGameTestForAllZeros()
        {
            RollMany(0, 20);
            Assert.AreEqual(0, game.GetEndScore());
        }

        [Test]
        public void RollOneOnEveryFrameForATotalOf20()
        {
            RollMany(1, 20);
            Assert.AreEqual(20, game.GetEndScore());
        }

        [Test]
        public void OneSpareAndEighteenRolls()
        {
            RollMany(5, 3);
            RollMany(0, 17);
            Assert.AreEqual(20, game.GetEndScore());
        }

        [Test]
        public void AllSparesExceptFinalToExcludeBonus()
        {
            RollMany(5, 19);
            RollMany(0, 1);
            Assert.AreEqual(140 , game.GetEndScore());
        }

        [Test]
        public void OneStrikeAndNineteenRolls()
        {
            RollMany(10, 1);
            RollMany(0, 19);
            Assert.AreEqual(10, game.GetEndScore());
        }

        [Test]
        public void OneStrikeAndFivePinsThenFourPinsThenAllGutters()
        {
            RollMany(10, 1);
            RollMany(5, 1);
            RollMany(4, 1);
            RollMany(0, 16);
            Assert.AreEqual(28, game.GetEndScore());
        }

        [Test]
        public void TwoStrikesAndTwoRollsOfFiveAndFour()
        {
            RollMany(10, 1);
            RollMany(10, 1);
            RollMany(5, 1);
            RollMany(4, 1);
            RollMany(0, 14);
            Assert.AreEqual(53, game.GetEndScore());
        }

        [Test]
        public void SpareWithTenAsSecondRollWithAllOtherRollsOfOne()
        {
            RollMany(0, 1);
            RollMany(10, 1);
            RollMany(1, 18);
            Assert.AreEqual(29, game.GetEndScore());
        }

        [Test]
        public void PerfectScoredGame()
        {
            RollMany(10, 11);
            Assert.AreEqual(300, game.GetEndScore());
        }

        private void RollMany(Int32 pins, Int32 numOfRolls)
        {
            for (var roll = 0; roll < numOfRolls; roll++)
            {
                game.AddRollScore(pins);
            }
        }
    }
}
