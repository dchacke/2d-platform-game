using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10;
    float jumpForce = 400;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 movement = Vector3.right * input;

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: This would be better in FixedUpdate, but Input.GetKeyDown
            // seems lossy there.
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
