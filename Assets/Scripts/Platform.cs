using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject cherryPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCherry();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCherry()
    {
        if (Random.Range(0.0f, 1.0f) < 0.2f)
        {
            float width = GetComponent<SpriteRenderer>().bounds.size.x;
            float height = GetComponent<SpriteRenderer>().bounds.size.y;
            float x = Random.Range(transform.position.x - width / 2, transform.position.x + width / 2);
            float y = transform.position.y + height + 0.25f;

            Vector3 pos = new Vector3(x, y, 0);

            Instantiate(cherryPrefab, pos, cherryPrefab.transform.rotation);
        }
    }
}
