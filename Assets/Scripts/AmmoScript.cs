using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public int alphaCounter, deltaCounter, omegaCounter;
    private int fireIndex;

    private List<GameObject> alphaMissiles, deltaMissiles, omegaMissiles = new List<GameObject>();

    void Start()
    {
        alphaMissiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("AlphaMissile"));
        deltaMissiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeltaMissile"));
        omegaMissiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("OmegaMissile"));
    }

    public void RemoveMissile()
    {
        fireIndex = gameObject.GetComponent<ShotsManager>().fireIndex;

        if (fireIndex == 0)
        {
            if (alphaCounter < alphaMissiles.Count)
            {
                alphaMissiles[alphaCounter].SetActive(false);
                alphaCounter++;
            }
        }
        if (fireIndex == 1)
        {
            if (deltaCounter < deltaMissiles.Count)
            {
                deltaMissiles[deltaCounter].SetActive(false);
                deltaCounter++;
            }
        }
        if (fireIndex == 2)
        {
            if (omegaCounter < omegaMissiles.Count)
            {
                omegaMissiles[omegaCounter].SetActive(false);
                omegaCounter++;
            }
        }
    }
}
