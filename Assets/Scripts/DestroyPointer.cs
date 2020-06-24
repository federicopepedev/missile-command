using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        DestroyObject();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
