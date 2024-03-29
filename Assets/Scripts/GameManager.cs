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
    AudioSource audioSource;

    [SerializeField] AudioClip fallingSound;

    float highestY = 0;
    public bool IsGameOver = false;

    static int Highscore = 0;

    int cherryCount = 0;
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
        audioSource = GetComponent<AudioSource>();

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
            audioSource.PlayOneShot(fallingSound);
            TriggerGameOver();
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

    public void TriggerGameOver()
    {
        IsGameOver = true;
        gameOverScreen.SetActive(true);
        StartCoroutine("RestartScene");
    }
}
