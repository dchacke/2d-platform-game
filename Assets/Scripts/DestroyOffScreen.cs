using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < GameObject.Find("Player").transform.position.y - 20)
        {
            Destroy(gameObject);
        }
    }
}
