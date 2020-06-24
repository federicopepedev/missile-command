using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shot;
    public static AudioClip explosion;
    static AudioSource audioSrc;

    void Start()
    {
        shot = Resources.Load<AudioClip>("shot");
        explosion = Resources.Load<AudioClip>("explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shot":
                audioSrc.PlayOneShot(shot);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosion);
                break;
        }
    }
}
