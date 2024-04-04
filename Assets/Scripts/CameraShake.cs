using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraShake : MonoBehaviour
{
    public IEnumerator ShakeCamera (float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsedTime = 0.0f;

        while(elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = originalPos + new Vector3(x, y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }
}
