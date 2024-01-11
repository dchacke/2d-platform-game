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
            Vector3 pos = RandomSpawnPos() + new Vector3(0, 0.25f, 0);

            Instantiate(cherryPrefab, pos, cherryPrefab.transform.rotation);
        }
    }

    void SpawnSpikes()
    {
        if (Random.Range(0.0f, 1.0f) < 1f)
        {
            Vector3 pos = RandomSpawnPos() + new Vector3(0, -0.05f, 0);

            Instantiate(spikesPrefab, pos, cherryPrefab.transform.rotation);
        }
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(
            Random.Range(transform.position.x - width / 2, transform.position.x + width / 2),
            transform.position.y + height,
            0
        );
    }
}
