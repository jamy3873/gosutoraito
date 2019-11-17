using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior S;
    private bool _holdingSword;
    
    public bool holdingSword
    {
        get { return _holdingSword; }
    }
    void Start()
    {
        S = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _holdingSword = true;
        }
        else
        {
            _holdingSword = false;
        }
    }

    public bool CanReflect(Vector3 lightHit)
    {
        Vector3 targetDir = (lightHit - transform.position).normalized;
        if (Vector3.Angle(transform.forward, targetDir) < 90)
        {
            return true;
        }

        return false;
    }
}
