using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public Transform objectToDisappear;
    // If player touch the top of the platform, the platform will fall down and disappear
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        float t = 1f;
        while (t > 0)
        {
            objectToDisappear.position -= new Vector3(0, 0.02f, 0);
            t -= 0.01f;
            yield return null;
        }
    }
}
