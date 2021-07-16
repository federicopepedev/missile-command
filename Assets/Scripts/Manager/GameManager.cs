using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int executions = 2;
    public static int levelNumber = 1;
    public static float bulletSpeed = 1;

    private int highScore;
    private int bonusMissiles;
    private int bonusCities;

    public static bool levelComplete;

    private GameObject bonusText;
    private GameObject endText;

    private List<GameObject> missiles = new List<GameObject>();
    private List<GameObject> cities = new List<GameObject>();
    private List<GameObject> citiesBonus = new List<GameObject>();
    private List<GameObject> enemyBullets = new List<GameObject>();

    Text score;
    Text points;
    Text firstBonus;
    Text secondBonus;

    private Animator arrowsAnim;

    private EnemiesManager enemiesManager;
    private ShotsManager shotsManager;

    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        points = GameObject.Find("Points").GetComponent<Text>();
        firstBonus = GameObject.Find("MissilePoints").GetComponent<Text>();
        secondBonus = GameObject.Find("CitiesPoints").GetComponent<Text>();

        bonusText = GameObject.Find("BonusText");
        bonusText.SetActive(false);

        endText = GameObject.Find("EndText");
        endText.SetActive(false);

        arrowsAnim = GameObject.Find("Cities").GetComponent<Animator>();

        enemiesManager = GameObject.Find("EnemiesManager").GetComponent<EnemiesManager>();
        shotsManager = GameObject.Find("ShotsManager").GetComponent<ShotsManager>();
    }

    void Start()
    {
        Time.timeScale = 1;

        levelComplete = false;

        points.text = levelNumber.ToString();

        arrowsAnim.Play("Arrows", -1, 0);

        highScore = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        score.text = "" + scoreValue;

        enemyBullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemyBullet"));
        cities = new List<GameObject>(GameObject.FindGameObjectsWithTag("City"));

        if (enemyBullets.Count == 0 && cities.Count > 0 && !levelComplete && !enemiesManager.isActiveAndEnabled)
        {
            levelComplete = true;
            CountBonus();
        }
        else if(cities.Count == 0 || enemyBullets.Count == 0 && cities.Count == 0)
            EndGame();
    }

    void CountBonus()
    {
        missiles.AddRange(GameObject.FindGameObjectsWithTag("AlphaMissile"));
        missiles.AddRange(GameObject.FindGameObjectsWithTag("DeltaMissile"));
        missiles.AddRange(GameObject.FindGameObjectsWithTag("OmegaMissile"));
        citiesBonus.AddRange(GameObject.FindGameObjectsWithTag("City"));

        firstBonus.text = "x" + missiles.Count;
        secondBonus.text = "x" + citiesBonus.Count;

        bonusText.SetActive(true);

        foreach (GameObject missile in missiles)
            if(missile.activeInHierarchy)
            {
                bonusMissiles += 1 * levelNumber;
                scoreValue += bonusMissiles;
            }

        foreach (GameObject cityBonus in citiesBonus)
            if (cityBonus.activeInHierarchy)
            {
                bonusCities += 1 * levelNumber;
                scoreValue += bonusCities;
            }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
        if (levelNumber > 5)
            executions = 3;
        else if (levelNumber > 14)
            executions = 4;

        if (bulletSpeed < 4)
            bulletSpeed += 0.05f;

        levelNumber++;

        SceneManager.LoadScene("SampleScene");
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        endText.SetActive(true);

        if (scoreValue > highScore)
        {
            highScore = scoreValue;
            PlayerPrefs.SetInt("highscore", highScore);
            PlayerPrefs.Save();
        }

        shotsManager.enabled = false;
        Cursor.visible = true;

    }

    public void NewGame()
    {
        scoreValue = 0;
        executions = 2;
        levelNumber = 1;
        bulletSpeed = 1;

        Destroy(GameObject.Find("Cities"));

        SceneManager.LoadScene("MainMenu");
    }

}
