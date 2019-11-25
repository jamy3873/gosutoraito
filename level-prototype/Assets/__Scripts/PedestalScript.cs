using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalScript : MonoBehaviour
{
    private Transform rootNode;
    public Transform originalParent;
    public GameObject thisMirror;
    [SerializeField]
    public bool hasMirror
    {
        get { return thisMirror.activeInHierarchy; }
        set
        {
            transform.parent.GetChild(0).gameObject.SetActive(value);
        }
    }
    public bool locked = true;

    private Rigidbody rb;
    void Start()
    {
        rootNode = transform.parent;
        originalParent = rootNode.parent;
        rb = rootNode.GetComponent<Rigidbody>();
        thisMirror = transform.parent.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //Edit
        if (!locked && Vector3.Distance(transform.position, PlayerBehavior.S.transform.position) < 5f)
        {
            rootNode.parent = PlayerBehavior.S.grabTransform;
        }
        
    }

    private void OnMouseUp()
    {
        //Exit edit
        if (Vector3.Distance(transform.position, PlayerBehavior.S.transform.position) < 5f)
        {
            rootNode.parent = originalParent;
            thisMirror.SetActive(!hasMirror);
        }
    }


    private void OnMouseOver()
    {
        if (!locked && Vector3.Distance(transform.position, PlayerBehavior.S.transform.position) < 5f)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    
}
