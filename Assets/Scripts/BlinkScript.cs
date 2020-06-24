using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    public float timer;

    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine(ColorSwitch());
    }

    IEnumerator ColorSwitch()
    {
        while (true)
        {
            sprite.color = Color.white;

            yield return new WaitForSeconds(timer);

            sprite.color = Color.yellow;

            yield return new WaitForSeconds(timer);

            sprite.color = Color.green;

            yield return new WaitForSeconds(timer);

            sprite.color = Color.red;

            yield return new WaitForSeconds(timer);

            sprite.color = Color.blue;

            yield return new WaitForSeconds(timer);

            sprite.color = Color.magenta;

            yield return new WaitForSeconds(timer);
        }

    }
}
