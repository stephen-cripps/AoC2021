using AdventOfCode1.Extensions;

namespace AdventOfCode1.Solutions;

public class Day17
{
    public static (int maxY, int successCount) GetBestLaunchHeight(int targetXMin, int targetXMax, int targetYMin, int targetYMax)
    {
        var maxY = 0;
        var successCount = 0;

        for (var i = 5; i <= targetXMax; i++)
        {
            for (var j = targetYMin; j < 300; j++)
            {
                var attemptHeight = FireProbe(targetXMin, targetXMax, targetYMin, targetYMax, i, j);

                if (attemptHeight == -1000)
                    break; // overshot x at this height, no need to try continue, just increase x

                if (attemptHeight > -100)
                    successCount++;

                if (attemptHeight > maxY)
                    maxY = attemptHeight;
            }
        }

        return (maxY, successCount);
    }

    public static int FireProbe(int targetXMin, int targetXMax, int targetYMin, int targetYMax, int xVel, int yVel)
    {
        var x = 0;
        var y = 0;
        var maxY = 0;
        while (y >= targetYMin && x <= targetXMax)
        {
            y += yVel;
            x += xVel;

            if (y > maxY)
                maxY = y;

            if (x >= targetXMin && x <= targetXMax && y >= targetYMin && y <= targetYMax)
                return maxY;

            yVel--;
            if (xVel > 0)
                xVel--;
            else if (xVel < 0)
                xVel++;
        }

        return x > targetXMax ? -1000 : -100;
    }

}
