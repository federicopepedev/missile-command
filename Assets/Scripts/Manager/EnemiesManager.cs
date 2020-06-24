using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public int waitingTime;
    private int executions;

    private float timer, bulletSpeed;

    public GameObject enemyBullet;

    public List<Transform> firePoints = new List<Transform>();
    public List<GameObject> cities = new List<GameObject>();

    void Awake()
    {
        cities = new List<GameObject>(GameObject.FindGameObjectsWithTag("City"));
        gameObject.SetActive(true);
    }

    void Start()
    {
        executions = GameManager.executions;
        bulletSpeed = GameManager.bulletSpeed;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime && executions > 0)
        {
            timer = 0;
            --executions;
            StartCoroutine(ExecuteFirePoints());
        }

        if (executions == 0)
        {
            StopCoroutine(ExecuteFirePoints());
            gameObject.GetComponent<EnemiesManager>().enabled = false;
        }

        for (int i = cities.Count - 1; i > -1; i--)
        {
            if (cities[i] == null)
                cities.RemoveAt(i);
        }
    }

    IEnumerator ExecuteFirePoints()
    {
        Shoot();
        yield return new WaitForSeconds(waitingTime);
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            Vector3 difference = firePoint.transform.position - cities[Random.Range(0, cities.Count)].transform.position;

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;

            direction.Normalize();

            GameObject e = Instantiate(enemyBullet, firePoint.transform.position, firePoint.transform.rotation);
            e.GetComponent<Rigidbody2D>().velocity = (direction * -1) * bulletSpeed;
            e.GetComponent<SpreadScript>().enabled = false;

            if (GameManager.levelNumber < 20)
            {
                if (e.transform.position == firePoints[2].transform.position)
                    e.GetComponent<SpreadScript>().enabled = true;
            }
            if (GameManager.levelNumber > 20)
            {
                if (e.transform.position == firePoints[1].transform.position || e.transform.position == firePoints[3].transform.position)
                    e.GetComponent<SpreadScript>().enabled = true;
            }

            if (GameManager.levelNumber >= 3)
            {
                e.GetComponent<TrailRenderer>().startColor = Color.magenta;
                e.GetComponent<TrailRenderer>().endColor = Color.magenta;
            }
            if (GameManager.levelNumber >= 5)
            {
                e.GetComponent<TrailRenderer>().startColor = Color.green;
                e.GetComponent<TrailRenderer>().endColor = Color.green;
            }
            if (GameManager.levelNumber >= 8)
            {
                e.GetComponent<TrailRenderer>().startColor = Color.yellow;
                e.GetComponent<TrailRenderer>().endColor = Color.yellow;
            }
            if (GameManager.levelNumber >= 11)
            {
                e.GetComponent<TrailRenderer>().startColor = Color.red;
                e.GetComponent<TrailRenderer>().endColor = Color.red;
            }
            if (GameManager.levelNumber >= 20)
            {
                e.GetComponent<TrailRenderer>().startColor = Color.magenta;
                e.GetComponent<TrailRenderer>().endColor = Color.magenta;
            }
            if (GameManager.levelNumber >= 30)
            {
                e.GetComponent<TrailRenderer>().startColor = Color.green;
                e.GetComponent<TrailRenderer>().endColor = Color.green;
            }
            if (GameManager.levelNumber >= 40)
            {
                e.GetComponent<TrailRenderer>().startColor = Color.yellow;
                e.GetComponent<TrailRenderer>().endColor = Color.yellow;
            }
        }
    }
}
