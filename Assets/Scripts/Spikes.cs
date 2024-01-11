using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    PlayerController pc;
    GameManager gm;

    void Awake()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !pc.IsAscending())
        {
            gm.TriggerGameOver();
        }
    }
}
