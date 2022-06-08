using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
    public FacingObject facingObject;

    private void Start()
    {
        facingObject.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        facingObject.enabled = true;
    }
}
