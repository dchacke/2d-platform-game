using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float leftBound;
    public float rightBound;
    public float highestY;

    float speed = 10;
    float jumpForce = 400;
    bool facingRight = true;
    Rigidbody2D rb;
    GameManager gm;
    AudioSource audioSource;

    [SerializeField] AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.IsGameOver)
        {
            return;
        }

        Move();
        ConstrainMovement();
        Rotate();
        TrackHighestY();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground") && !IsAscending() && !gm.IsGameOver)
        {
            Jump();
        }
    }

    void Move()
    {
        float input = Input.GetAxis("Horizontal");
        Vector2 movement = Vector2.right * input;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void ConstrainMovement()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, leftBound, rightBound),
            transform.position.y
        );
    }

    void Rotate()
    {
        float input = Input.GetAxis("Horizontal");

        if (input < 0 && facingRight || input > 0 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
    }

    void TrackHighestY()
    {
        highestY = Mathf.Max(highestY, transform.position.y);
    }

    void Jump()
    {
        // TODO: Since we're using physics, this would be better placed
        // in FixedUpdate, but Input.GetKeyDown seems lossy there.
        rb.AddForce(Vector2.up * jumpForce);

        audioSource.PlayOneShot(jumpSound);
    }

    public bool IsAscending()
    {
        return rb.velocity.y > 0;
    }
}
