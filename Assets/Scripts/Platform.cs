using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject cherryPrefab;
    [SerializeField] GameObject spikesPrefab;

    float width;
    float height;

    void Awake()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;

        SpawnCherry();
        SpawnSpikes();
    }

    void SpawnCherry()
    {
        if (Random.Range(0.0f, 1.0f) < 0.2f)
        {
            Vector2 pos = RandomSpawnPos() + new Vector2(0, 0.25f);

            Instantiate(cherryPrefab, pos, cherryPrefab.transform.rotation);
        }
    }

    void SpawnSpikes()
    {
        if (Random.Range(0.0f, 1.0f) < 0.1f)
        {
            Vector2 pos = RandomSpawnPos() + new Vector2(0, -0.05f);

            Instantiate(spikesPrefab, pos, cherryPrefab.transform.rotation);
        }
    }

    Vector2 RandomSpawnPos()
    {
        float xOffset = 0.15f;

        return new Vector2(
            Random.Range(transform.position.x - width / 2 + xOffset, transform.position.x + width / 2 - xOffset),
            transform.position.y + height
        );
    }
}
