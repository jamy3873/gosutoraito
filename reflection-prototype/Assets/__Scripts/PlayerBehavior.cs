using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior S;
    private bool _holdingSword;
    private Transform _thisCamera;
    public int mirrorCount = 0;
    
    public bool holdingSword
    {
        get { return _holdingSword; }
    }
    void Start()
    {
        S = this;
        _thisCamera = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = GetObject();
            if (go)
            {
                switch (go.tag)
                {
                    case "Pedestal":
                        PedestalScript ped = go.GetComponent<PedestalScript>();
                        if (ped.hasMirror)
                            Grab(go);
                        else
                            Place(go);
                        break;
                    case "Mirror":
                        //editMode
                        break;
                }
            }
            
            
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            _holdingSword = true;
        }
        else
        {
            _holdingSword = false;
        }
        
    }

    private GameObject GetObject()
    {
        Ray ray = new Ray(_thisCamera.transform.position, _thisCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f))
        {
            GameObject go = hit.collider.gameObject;
            switch (go.tag)
            {
                case "Pedestal":
                    return go.transform.parent.gameObject;
                case "Mirror":
                    return go.transform.parent.gameObject;
                default:
                    break;
            }
        }
        return null;
    }

    public void Grab(GameObject item)
    {
        switch (item.tag)
        {
            case "Pedestal":
                PedestalScript pedestal;
                pedestal = item.GetComponent<PedestalScript>();
                pedestal.hasMirror = false;
                mirrorCount++;
                break;

        }
    }

    public void Place(GameObject item)
    {
        switch (item.tag)
        {
            case "Pedestal":
                if (mirrorCount > 0)
                {
                    PedestalScript pedestal;
                    pedestal = item.GetComponent<PedestalScript>();
                    pedestal.hasMirror = true;
                    mirrorCount--;
                    
                }
                break;

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(new Ray(Camera.main.transform.position, Camera.main.transform.forward));
    }
}
