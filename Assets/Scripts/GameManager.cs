using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cherryCountDisplay;
    [SerializeField] TextMeshProUGUI highscoreDisplay;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject gameOverScreen;

    GameObject player;
    PlayerController pc;

    float highestY = 0;

    private static int Highscore = 0;

    private int cherryCount = 0;
    public int CherryCount
    {
        get
        {
            return cherryCount;
        }
        private set
        {
            cherryCount = value;
            cherryCountDisplay.text = $"{value}";

            if (value > Highscore)
            {
                Highscore = value;
                DisplayHighscore();
            }
        }
    }

    void Start()
    {
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();

        DisplayHighscore();
        SpawnSeedPlatforms();
        InvokeRepeating("SpawnPlatform", 0, 1);
        InvokeRepeating("CheckGameOver", 0, 2);
    }

    public void IncCherryCount()
    {
        CherryCount++;
    }

    void SpawnSeedPlatforms()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        highestY += 2;
        int padding = 2;
        Vector3 pos = new Vector3(Random.Range(pc.leftBound + padding, pc.rightBound - padding), highestY, 0);
        GameObject platform = Instantiate(platformPrefab, pos, platformPrefab.transform.rotation);
    }

    void CheckGameOver()
    {
        if (player.transform.position.y < pc.highestY - 20)
        {
            gameOverScreen.SetActive(true);
            StartCoroutine("RestartScene");
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DisplayHighscore()
    {
        highscoreDisplay.text = $"Highscore: {Highscore}";
    }
}
