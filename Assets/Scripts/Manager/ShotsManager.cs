using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotsManager : MonoBehaviour
{
    public int fireIndex;
    public float bulletSpeed;

    private Vector3 target;

    private int splitScreen = Screen.width / 3;

    public GameObject cross, pointer, bulletPrefab;

    public List<Transform> firePoints = new List<Transform>();

    private AmmoScript ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = gameObject.GetComponent<AmmoScript>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        cross.transform.position = new Vector2(target.x, target.y);

        if (Input.mousePosition.x < splitScreen)
        {
                fireIndex = 0;
            if (ammo.alphaCounter == 10)
                fireIndex = 1;
            if (ammo.alphaCounter == 10 && ammo.deltaCounter == 10)
                fireIndex = 2;
        }
        else if (Input.mousePosition.x >= splitScreen && Input.mousePosition.x < 2 * splitScreen)
        {
                fireIndex = 1;
            if (ammo.deltaCounter == 10)
                fireIndex = 0;
            if (ammo.deltaCounter == 10 && ammo.alphaCounter == 10)
                fireIndex = 2;
        }
        else if (Input.mousePosition.x >= 2 * splitScreen)
        {
                fireIndex = 2;
            if (ammo.omegaCounter == 10)
                fireIndex = 1;
            if (ammo.omegaCounter == 10 && ammo.deltaCounter == 10)
                fireIndex = 0;
        }

        Vector3 difference = target - firePoints[fireIndex].transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Input.GetButtonDown("Fire1") && gameObject.activeSelf)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;

            direction.Normalize();
            Shoot(direction, rotationZ);

            ammo.RemoveMissile();
            SoundManager.PlaySound("shot");
        }

        if (ammo.alphaCounter == 10 && ammo.deltaCounter == 10 && ammo.omegaCounter == 10 || GameManager.levelComplete)
        {
            gameObject.SetActive(false);
            cross.SetActive(false);
            Cursor.visible = true;
        }
    }

    void Shoot(Vector2 direction, float rotationZ)
    {
        Instantiate(pointer, cross.transform.position, Quaternion.Euler(0, 0, -45));

        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = firePoints[fireIndex].transform.position;
        b.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        if (GameManager.levelNumber == 2)
        {
            b.GetComponent<TrailRenderer>().startColor = Color.green;
            b.GetComponent<TrailRenderer>().endColor = Color.green;
        }
        else if (GameManager.levelNumber == 3)
        {
            b.GetComponent<TrailRenderer>().startColor = Color.white;
            b.GetComponent<TrailRenderer>().endColor = Color.white;
        }
        else if (GameManager.levelNumber == 4)
        {
            b.GetComponent<TrailRenderer>().startColor = Color.white;
            b.GetComponent<TrailRenderer>().endColor = Color.white;
        }
        else if (GameManager.levelNumber == 5)
        {
            b.GetComponent<TrailRenderer>().startColor = new Color(0, 0.7005146f, 1);
            b.GetComponent<TrailRenderer>().endColor = new Color(0, 0.7005146f, 1);
        }
        else if (GameManager.levelNumber == 6)
        {
            b.GetComponent<TrailRenderer>().startColor = new Color(255, 255, 0);
            b.GetComponent<TrailRenderer>().endColor = new Color(255, 255, 0);
        }
        else if (GameManager.levelNumber == 7)
        {
            b.GetComponent<TrailRenderer>().startColor = Color.white;
            b.GetComponent<TrailRenderer>().endColor = Color.white;
        }
        else if (GameManager.levelNumber == 8)
        {
            b.GetComponent<TrailRenderer>().startColor = Color.green;
            b.GetComponent<TrailRenderer>().endColor = Color.green;
        }
        else if (GameManager.levelNumber == 9)
        {
            b.GetComponent<TrailRenderer>().startColor = new Color(0, 1, 0.95f);
            b.GetComponent<TrailRenderer>().endColor = new Color(0, 1, 0.95f);
        }
        else if (GameManager.levelNumber == 10)
        {
            b.GetComponent<TrailRenderer>().startColor = Color.green;
            b.GetComponent<TrailRenderer>().endColor = Color.green;
        }
        else if (GameManager.levelNumber > 10)
        {
            b.GetComponent<TrailRenderer>().startColor = new Color(0, 0.172549f, 1);
            b.GetComponent<TrailRenderer>().endColor = new Color(0, 0.172549f, 1);
        }
    }

}
