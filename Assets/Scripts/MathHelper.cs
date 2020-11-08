using UnityEngine;

public static class MathHelper
{
    /// <param name="direction"> -1 for counter clockwise, 1 for clockwise </param>
    /// <param name="currentPercentage"> in Degrees </param>
    public static Vector2 GiveNextPointInArchByPercentage(int direction, float currentPercentage, float radius
        , float nextPointIncrementAmount, Vector2 originPoint)
    {
        float currentPercentageRad = currentPercentage * Mathf.Deg2Rad;
        float x = 0f;
        float y = 0f;

        if (direction == 1)
        {
            float calculatedPercentage = currentPercentageRad + nextPointIncrementAmount;
            x = originPoint.x + radius * Mathf.Cos(calculatedPercentage);
            y = originPoint.y + radius * Mathf.Sin(calculatedPercentage);
        }
        else if (direction == -1)
        {
            float calculatedPercentage = currentPercentageRad - nextPointIncrementAmount;
            x = originPoint.x + radius * Mathf.Cos(calculatedPercentage);
            y = originPoint.y + radius * Mathf.Sin(calculatedPercentage);
        }
        else
        {
            Debug.LogError("Enter appropriate number");
        }

        return new Vector2(x, y);
    }

    public static float FindPercentageInArch(Vector2 originPoint, Vector2 objectPosition, out float radius)
    {
        Vector2 centeredPoint = objectPosition - originPoint;
        Vector2 normalizedPoint = centeredPoint.normalized;

        radius = centeredPoint.magnitude;

        // check for regions in the circle
        // first region
        if (normalizedPoint.x >= 0 && normalizedPoint.y >= 0)
        {
            return Mathf.Asin(normalizedPoint.y) * Mathf.Rad2Deg;
        }
        else if (normalizedPoint.x <= 0 && normalizedPoint.y >= 0) // second region
        {
            return (90 - Mathf.Asin(normalizedPoint.y) * Mathf.Rad2Deg) + 90f;
        }
        else if (normalizedPoint.x <= 0 && normalizedPoint.y <= 0) // third region
        {
            return (90 - Mathf.Asin(normalizedPoint.y) * Mathf.Rad2Deg) + 90f;
        }
        else if (normalizedPoint.x >= 0 && normalizedPoint.y <= 0) // fourth region
        {
            return (90 - (-Mathf.Asin(normalizedPoint.y)) * Mathf.Rad2Deg + 270f);
        }
        return 0f;
    }
}
