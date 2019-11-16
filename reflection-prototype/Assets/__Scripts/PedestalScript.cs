using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalScript : MonoBehaviour
{
    public bool hasMirror = true;
    public bool locked = true;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (!hasMirror)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (locked)
        {
            LockPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasMirror)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void LockPosition()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
