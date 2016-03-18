using EloRatingTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EloRatingTests
{
    [TestClass]
    public class EloCalculatorTests
    {
        [TestMethod]
        public void Test()
        {
            int elo;

            elo = EloCalculator.CalculateNewElo(2000, 2000, 0, EloCalculator.VictoryType.Win);
            Assert.AreEqual(elo, 2020);

            elo = EloCalculator.CalculateNewElo(1970, 2320, 35, EloCalculator.VictoryType.Loss);
            Assert.AreEqual(elo, 1968);

            elo = EloCalculator.CalculateNewElo(2480, 2100, 482, EloCalculator.VictoryType.Loss);
            Assert.AreEqual(elo, 2471);
        }
    }
}
