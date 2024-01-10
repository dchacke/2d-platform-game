using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cherryCountDisplay;
    [SerializeField] GameObject platformPrefab;

    PlayerController pc;

    float highestY = 0;

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
        }
    }

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        SpawnSeedPlatforms();
        InvokeRepeating("SpawnPlatform", 0, 1);
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
}
