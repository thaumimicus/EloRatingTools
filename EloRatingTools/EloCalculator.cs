using System;
using EloRatingTools.Exceptions;

namespace EloRatingTools
{
    /// <summary>
    /// Class for calculating Elo scores after games.
    /// </summary>
    public static class EloCalculator
    {
        /// <summary>
        /// Calculates the expected score of player A.
        /// </summary>
        /// <param name="rA">The rating of player A.</param>
        /// <param name="rB">The rating of player B.</param>
        /// <returns>The expected score as a double.</returns>
        private static double CalculateExpectedScore(int rA, int rB)
        {
            double expectedScore;

            // Find 10 to the power of difference in ratings and divide by 400
            expectedScore = rB - rA;
            expectedScore = expectedScore / 400;
            expectedScore = Math.Pow(10, expectedScore);

            // Do 1 divided by 1 + previous result
            expectedScore = 1 / (1 + expectedScore);

            return expectedScore;
        }

        /// <summary>
        /// Gets the appropriate k coefficent based on rating and games played (as defined by FIDE).
        /// </summary>
        /// <param name="rating">Rating of the player.</param>
        /// <param name="totalGamesPlayed">Total number of games the player has played.</param>
        /// <returns>K coefficient as an int.</returns>
        private static double GetKCoefficient(int rating, int totalGamesPlayed)
        {
            if (totalGamesPlayed < 30)
            {
                return 40;
            }  
            else if (rating < 2400)
            {
                return 20;
            }
            else
            {
                return 10;
            }
        }

        /// <summary>
        /// Defines the victory type: relates to Actual Score.
        /// </summary>
        public enum VictoryType { Win, Loss, Draw };

        /// <summary>
        /// Gets the actual score based on victory type.
        /// </summary>
        /// <param name="victoryType">The victory type.</param>
        /// <returns>Actual score.</returns>
        private static double GetActualScore(VictoryType victoryType)
        {
            switch (victoryType)
            {
                case VictoryType.Win:
                    return 1;
                case VictoryType.Draw:
                    return 0.5;
                case VictoryType.Loss:
                    return 0;
                default:
                    throw new VictoryTypeNotFoundException("Could not find victory type " + victoryType.ToString());
            }
        }

        /// <summary>
        /// Calculates a new Elo rating for a player after a game.
        /// </summary>
        /// <param name="rating">Rating of the player.</param>
        /// <param name="opponentRating">Rating of the opponent.</param>
        /// <param name="totalGamesPlayed">Number of games the player has played.</param>
        /// <param name="victoryType">Type of victory: Win, Draw or Loss.</param>
        /// <returns></returns>
        public static int CalculateNewElo(int rating, int opponentRating, int totalGamesPlayed, VictoryType victoryType)
        {
            double ratingChange;

            // Find variables
            double kCoefficient = GetKCoefficient(rating, totalGamesPlayed);
            double expectedScore = CalculateExpectedScore(rating, opponentRating);
            double actualScore = GetActualScore(victoryType);

            // Calculate rating change
            ratingChange = kCoefficient * (actualScore - expectedScore);

            // Return new Elo
            return (int)Math.Round(rating + ratingChange);
        }
    }
}