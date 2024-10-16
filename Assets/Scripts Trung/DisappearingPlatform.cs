using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
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
        yield return new WaitForSeconds(0.2f);
        float t = 1f;
        while (t > 0)
        {
            transform.position -= new Vector3(0, 0.1f, 0);
            t -= 0.01f;
            yield return null;
        }
        Destroy(gameObject);
    }
}
