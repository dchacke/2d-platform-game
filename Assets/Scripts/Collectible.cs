using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    GameManager gm;

    [SerializeField] AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // As per https://stackoverflow.com/a/36407104/1371131
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Destroy(gameObject);
            gm.IncCherryCount();
        }
    }
}
