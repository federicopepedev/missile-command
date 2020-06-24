using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }
}
