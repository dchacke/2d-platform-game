using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            target.transform.position.y,
            transform.position.z
        );
    }
}
