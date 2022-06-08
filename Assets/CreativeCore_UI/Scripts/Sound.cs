using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static int priority = 0;

    public AudioSource source;

    public void Play(AudioClip clip, float time = 3f, float sparialBlend = 1f)
    {
        source.clip = clip;
        source.Play();
        source.spatialBlend = sparialBlend;
        source.priority = priority;
        priority = Mathf.Min(priority + 1, 255);
        StartCoroutine(Wait(time));
    }
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPool.Set(typeof(Sound), this);
        gameObject.SetActive(false);
        priority = Mathf.Max(priority - 1, 0);
    }

}
