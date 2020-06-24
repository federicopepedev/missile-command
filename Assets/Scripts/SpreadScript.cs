using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadScript : MonoBehaviour
{
    private float waitingTime;
    private EnemiesManager enemiesManager;

    void Start()
    {
        waitingTime = 1.2f;

        if (GameManager.levelNumber > 9)
            StartCoroutine(ExecuteSpread());

        if (GameManager.levelNumber > 19)
            waitingTime = 0.9f;
        else if (GameManager.levelNumber > 25)
            waitingTime = 0.6f;
        else if (GameManager.levelNumber > 30)
            waitingTime = 0.3f;


        enemiesManager = GameObject.Find("EnemiesManager").GetComponent<EnemiesManager>();
    }

    IEnumerator ExecuteSpread()
    {
        yield return new WaitForSeconds(waitingTime);
        SpreadFire();
    }

    void SpreadFire()
    {
        if (gameObject.transform.position.y > 3.2f)
        {
            Vector3 difference = gameObject.transform.position - enemiesManager.cities[Random.Range(0, enemiesManager.cities.Count)].transform.position;

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;

            direction.Normalize();

            GameObject s = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
            s.GetComponent<Rigidbody2D>().velocity = (direction * -1) * GameManager.bulletSpeed;
        }
    }
}
