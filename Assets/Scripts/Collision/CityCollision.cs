using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EnemyBullet")
        this.gameObject.SetActive(false);
    }
}
