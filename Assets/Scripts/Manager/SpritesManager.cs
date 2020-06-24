using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    private List<GameObject> spritesMissiles = new List<GameObject>();
    private List<GameObject> spritesCities = new List<GameObject>();

    void Awake()
    {
        spritesMissiles.AddRange(GameObject.FindGameObjectsWithTag("AlphaMissile"));
        spritesMissiles.AddRange(GameObject.FindGameObjectsWithTag("DeltaMissile"));
        spritesMissiles.AddRange(GameObject.FindGameObjectsWithTag("OmegaMissile"));
        spritesCities.AddRange(GameObject.FindGameObjectsWithTag("City"));

        if (GameManager.levelNumber == 2)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(0, 0.172549f, 1);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = Color.green;

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
        }
        if (GameManager.levelNumber == 3)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = Color.green;

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (GameManager.levelNumber == 4)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(0, 0.7450981f, 1);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = Color.white;

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0.253829f);
        }
        if (GameManager.levelNumber == 5)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(1, 0, 0.3057165f);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = new Color(0, 0.7005146f, 1);

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (GameManager.levelNumber == 6)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(1, 0.4799654f, 0);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0.4176397f);
        }
        if (GameManager.levelNumber == 7)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(1, 0.2971698f, 0.6709907f);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = Color.white;

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = new Color(0, 0.45f, 1);
        }
        if (GameManager.levelNumber == 8)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(0.3f, 0.3f, 1);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = Color.green;

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = new Color(255, 0, 145);
        }
        if (GameManager.levelNumber == 9)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(0.89f, 0, 1);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0.95f);

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
        }
        if (GameManager.levelNumber == 10)
        {
            for (int i = 0; i < sprites.Count; i++)
                sprites[i].color = new Color(0, 0.45f, 1);

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = Color.green;

            foreach (GameObject spriteCity in spritesCities)
                if (spriteCity.activeInHierarchy)
                    spriteCity.GetComponent<SpriteRenderer>().color = new Color(0, 0.7333333f, 1);
        }
        if (GameManager.levelNumber > 10)
        {

            sprites[0].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            sprites[1].color = sprites[0].color;
            sprites[2].color = sprites[0].color;
            sprites[3].color = sprites[0].color;

            spritesCities[0].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            spritesCities[1].GetComponent<SpriteRenderer>().color = spritesCities[0].GetComponent<SpriteRenderer>().color;
            spritesCities[2].GetComponent<SpriteRenderer>().color = spritesCities[0].GetComponent<SpriteRenderer>().color;
            spritesCities[3].GetComponent<SpriteRenderer>().color = spritesCities[0].GetComponent<SpriteRenderer>().color;
            spritesCities[4].GetComponent<SpriteRenderer>().color = spritesCities[0].GetComponent<SpriteRenderer>().color;
            spritesCities[5].GetComponent<SpriteRenderer>().color = spritesCities[0].GetComponent<SpriteRenderer>().color;

            for (int i = 0; i < spritesMissiles.Count; i++)
                spritesMissiles[i].GetComponent<SpriteRenderer>().color = new Color(0, 0.172549f, 1);
        }
    }
}
