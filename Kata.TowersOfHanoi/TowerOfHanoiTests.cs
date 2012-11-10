using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.TowersOfHanoi
{
    [TestClass]
    public class TowerOfHanoiTests
    {
        [TestClass]
        public class NewGame
        {
            [TestMethod]
            public void WhenGameStarts_TowerOneHasNDisks()
            {
                int numberOfDisks = 4;

                var game = new Game(numberOfDisks);

                game.Tower1.Disks.Count.Should().Be(numberOfDisks);

            }

            [TestMethod]
            public void WhenGameStarts_DisksAreInCorrectOrder()
            {
                int numberOfDisks = 4;

                var game = new Game(numberOfDisks);

                game.IsValid.Should().Be(true);


            }

            [TestMethod]
            public void WhenGameStarts_Tower2AndTower3_AreEmpty()
            {
                const int IRRELEVANT_NUMBER = 1;
                var game = new Game(IRRELEVANT_NUMBER);

                game.Tower2.Disks.Count.Should().Be(0);
                game.Tower3.Disks.Count.Should().Be(0);

            }
        }

        [TestClass]
        public class StartGame
        {
            [TestMethod]
            public void WhenGameStarts_ItShouldMoveDiskFromTower1ToTower3()
            {
                var game = new Game(1);

                game.Start();

                game.Tower1.Disks.Count.Should().Be(0);
                game.Tower2.Disks.Count.Should().Be(0);
                game.Tower3.Disks.Count.Should().Be(1);

            }

            [TestMethod]
            public void WhenTowerAHasTwoDisks_TowerCShouldHaveTwoDisks()
            {
                var game = new Game(2);

                game.Start();

                game.Tower1.Disks.Count.Should().Be(0);
                game.Tower2.Disks.Count.Should().Be(0);
                game.Tower3.Disks.Count.Should().Be(2);
            }
            
            [TestMethod]
            public void WhenTowerAHasThreeDisks_TowerCShouldHaveThreeDisks()
            {
                var game = new Game(3);

                game.Start();

                game.Tower1.Disks.Count.Should().Be(0);
                game.Tower2.Disks.Count.Should().Be(0);
                game.Tower3.Disks.Count.Should().Be(3);

                game.IsFinished.Should().Be(true);
                game.IsValid.Should().Be(true);
            }

            [TestMethod]
            public void When_MoveDisksOverEachOtherTwice_ThenGameIsFinished()
            {
                // this is a solution for 2 disks
                var game = new Game(2);

                game.Start();

                game.Tower1.Disks.Count.Should().Be(0);
                game.Tower2.Disks.Count.Should().Be(0);
                game.Tower3.Disks.Count.Should().Be(2);

                game.IsFinished.Should().Be(true);

            }



        }


        [TestClass]
        public class MoveDisk
        {
            [TestMethod]
            public void When_Move1_ThenDiskShouldMoveFromTower1ToTower2()
            {
                var game = new Game(2);

                game.MoveDisk(game.Tower1, game.Tower2);

                game.Tower1.Disks.Count.Should().Be(1);
                game.Tower2.Disks.Count.Should().Be(1);
                game.Tower3.Disks.Count.Should().Be(0);


            }
            [TestMethod]
            public void When_MoveDisksOverEachOtherTwice_ThenGameIsFinished()
            {
                // this is a solution for 2 disks
                var game = new Game(2);

                game.MoveDisk(game.Tower1, game.Tower2);
                game.MoveDisk(game.Tower1, game.Tower3);
                game.MoveDisk(game.Tower2, game.Tower3);

                game.Tower1.Disks.Count.Should().Be(0);
                game.Tower2.Disks.Count.Should().Be(0);
                game.Tower3.Disks.Count.Should().Be(2);

                game.IsFinished.Should().Be(true);

            }

            [TestMethod]
            public void When_DistributeDiskOverTowerTwoAndThree_ThenGameIsNotFinished()
            {
                var game = new Game(2);

                game.MoveDisk(game.Tower1, game.Tower2);
                game.MoveDisk(game.Tower1, game.Tower3);

                game.IsValid.Should().Be(true);
                game.IsFinished.Should().Be(false);

            }


        }



    }

    
}
