using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCollision : MonoBehaviour
{
    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);

        Instantiate(explosion, transform.position, transform.rotation);

        SoundManager.PlaySound("explosion");
    }
}
