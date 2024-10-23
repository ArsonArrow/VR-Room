using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpForce = 1;
    bool isJumping = false;
    Rigidbody rb;

    void Update()
    {
        if (!isJumping && OVRInput.Get(OVRInput.Button.One))
        {
            isJumping = true;
            rb.AddRelativeForce(Vector3.up * JumpForce * Time.smoothDeltaTime);
        }

        if (isJumping && rb.velocity.y == 0)
        {
            isJumping = false;
        }
    }
}
