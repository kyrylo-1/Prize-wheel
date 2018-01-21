using UnityEngine;
using System.Collections;
namespace PrizeWheel
{
    public class Tools
    {
        public static int RandomInt(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static float RandomFloat(float min, float max)
        {
            return Random.Range(min, max);
        }

        public static IEnumerator ChangeColorAlpha(TextMesh target, float alpha, float duration)
        {
            //Debug.Log("Color change");
            float timeElapsed = 0f;
            Color startColor = target.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, alpha);

            while (timeElapsed < duration)
            {
                timeElapsed += Time.deltaTime;
                target.color = Color.Lerp(startColor, endColor, timeElapsed / duration);
                yield return null;
            }
        }
    }
}