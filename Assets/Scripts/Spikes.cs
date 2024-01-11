using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    PlayerController pc;
    GameManager gm;
    AudioSource audioSource;

    [SerializeField] AudioClip hurtSound;

    void Awake()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !pc.IsAscending())
        {
            audioSource.PlayOneShot(hurtSound);
            gm.TriggerGameOver();
        }
    }
}
