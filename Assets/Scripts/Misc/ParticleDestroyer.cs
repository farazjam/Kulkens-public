using System.Collections;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DestroyOverTime", 2f);
    }

    IEnumerator DestroyOverTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
