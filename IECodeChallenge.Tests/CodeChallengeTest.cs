using IECodeChallenge.Domain.Enums;
using IECodeChallenge.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IECodeChallenge.Tests
{
    [TestClass]
    public class CodeChallengeTest
    {
        

        //teste1
        [TestMethod]
        public void Correct_ShouldReturn01North()
        {
            Pacman pacman = new Pacman();

            pacman.Place(0, 0, EDirection.NORTH);

            pacman.Move();        


            Assert.AreEqual(0, pacman.X);
            Assert.AreEqual(1, pacman.Y);
            Assert.AreEqual(EDirection.NORTH, pacman.F);

        }

        //teste2
        [TestMethod]
        public void Correct_ShouldReturn00West()
        {
            Pacman pacman = new Pacman();

            pacman.Place(0, 0, EDirection.NORTH);

            pacman.RotateLeft();


            Assert.AreEqual(0, pacman.X);
            Assert.AreEqual(0, pacman.Y);
            Assert.AreEqual(EDirection.WEST, pacman.F);

        }

        //teste3
        [TestMethod]
        public void Correct_ShouldReturn33North()
        {
            Pacman pacman = new Pacman();

            pacman.Place(1, 2, EDirection.EAST);

            pacman.Move();
            pacman.Move();
            pacman.RotateLeft();
            pacman.Move();


            Assert.AreEqual(3, pacman.X);
            Assert.AreEqual(3, pacman.Y);
            Assert.AreEqual(EDirection.NORTH, pacman.F);

        }

        //generate random commands
        [TestMethod]
        public void RandomTest()
        {
            Pacman pacman = new Pacman();

            

            pacman.Place(1, 2, EDirection.EAST);

            pacman.Move();
            pacman.Move();
            pacman.RotateLeft();
            pacman.Move();


            Assert.AreEqual(3, pacman.X);
            Assert.AreEqual(3, pacman.Y);
            Assert.AreEqual(EDirection.NORTH, pacman.F);

        }
    }
}
