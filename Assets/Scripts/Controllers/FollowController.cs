using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothAmount = 0.3f;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (playerTransform.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothAmount);
        }
    }
}
