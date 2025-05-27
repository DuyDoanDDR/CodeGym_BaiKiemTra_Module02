using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicControl : MonoBehaviour
{
    private Rigidbody rb;
    public SlingShot IsRealease;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        IsRealease = FindObjectOfType<SlingShot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRealease.isRealease)
        {
            rb.isKinematic = false;
        }
    }
}
