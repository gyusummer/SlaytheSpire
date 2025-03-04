using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	public static float Choose(float[] probs)
    {
        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
    public static Vector3 BezierPoint(Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float f = 1 - t;

        return f * f * p1 + 2f * t * f * p2 + t * t * p3;
    }
    public static void RotateObjectToward(GameObject from, GameObject to)
    {
        Vector2 v = to.transform.position - from.transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, v);
        from.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
