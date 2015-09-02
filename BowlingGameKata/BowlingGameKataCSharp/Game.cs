using System;

namespace BowlingGameKataCSharp
{
    public class Game
    {
        private const Int32 MAX_BOWLS = 21;
        private Int32[] pinsKnockedDown = new Int32[MAX_BOWLS];
        private Int32 currentBowlNumber = 0;

        public void AddRollScore(Int32 pins)
        {
            if (RolledStrike(pins))
            {
                pinsKnockedDown[currentBowlNumber++] = pins;
                if (NotLastGameRoll())
                    pinsKnockedDown[currentBowlNumber++] = 0;
            }
            else
            { 
                pinsKnockedDown[currentBowlNumber++] = pins;
            }
        }

        public Int32 GetEndScore()
        {
            var totalGameScore = 0;

            for (var currentRoll = 0; currentRoll < MAX_BOWLS; currentRoll++)
            {
                totalGameScore += pinsKnockedDown[currentRoll];
               
                if (IsSpare(currentRoll))
                    totalGameScore += pinsKnockedDown[currentRoll];
                else if (IsStrike(currentRoll) && currentRoll < 20)
                    totalGameScore = ScoreStrike(totalGameScore, currentRoll);
            }

            return totalGameScore;
        }

        private int ScoreStrike(int totalGameScore, int currentRoll)
        {
            if (currentRoll >= 18)
                totalGameScore = AddCurrentAndNextRoll(totalGameScore, currentRoll);
            else if (!NextIsStrike(currentRoll))
                totalGameScore += ScoreOfNextTwoRolls(currentRoll);
            else
                totalGameScore += ScoreOfNextTwoRollsIfStrikes(currentRoll);

            return totalGameScore;
        }

        private Int32 AddCurrentAndNextRoll(Int32 totalGameScore, Int32 currentRoll)
        {
            totalGameScore += pinsKnockedDown[currentRoll];
            totalGameScore += pinsKnockedDown[currentRoll + 1];
            return totalGameScore;
        }

        private Boolean RolledStrike(Int32 pins)
        {
            return (currentBowlNumber % 2) == 0 && pins == 10;
        }

        private Boolean NotLastGameRoll()
        {
            return currentBowlNumber != MAX_BOWLS && currentBowlNumber < 20;
        }

        private Int32 ScoreOfNextTwoRolls(Int32 currentRoll)
        {
            return pinsKnockedDown[currentRoll + 2] + pinsKnockedDown[currentRoll + 3];
        }

        private Int32 ScoreOfNextTwoRollsIfStrikes(Int32 currentRoll)
        {
            return pinsKnockedDown[currentRoll + 2] + pinsKnockedDown[currentRoll + 4];
        }

        private Boolean NextIsStrike(Int32 currentRoll)
        {
            return pinsKnockedDown[currentRoll + 2] == 10;
        }

        private Boolean IsStrike(Int32 currentRoll)
        {
            return (currentRoll % 2) == 0 && (currentRoll < MAX_BOWLS) && pinsKnockedDown[currentRoll] == 10;
        }

        private Boolean IsSpare(Int32 currentFrame)
        {
            return currentFrame % 2 == 0 && currentFrame > 1 && (pinsKnockedDown[currentFrame - 1] + pinsKnockedDown[currentFrame - 2]) == 10 && pinsKnockedDown[currentFrame - 2] != 10;
        }
    }
}
