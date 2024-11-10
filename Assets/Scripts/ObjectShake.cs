using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectShake : MonoBehaviour
{
    public IEnumerator ShakeCamera (float intensity, float duration, float magnitude, int xTrue, int yTrue)
    {
        Vector3 originalPos = transform.position;
        float elapsedTime = 0.0f;

        while(elapsedTime < duration)
        {
            float x = xTrue * Random.Range(-intensity, intensity) * magnitude;
            float y = yTrue * Random.Range(-intensity, intensity) * magnitude;

            transform.position = originalPos + new Vector3(x, y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }
}
