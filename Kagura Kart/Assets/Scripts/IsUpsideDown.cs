using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsUpsideDown : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
