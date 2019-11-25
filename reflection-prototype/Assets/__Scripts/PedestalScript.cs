using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalScript : MonoBehaviour
{
    public GameObject thisMirror;
    [SerializeField]
    public bool hasMirror
    {
        get { return thisMirror.activeInHierarchy; }
        set
        {
            transform.GetChild(0).gameObject.SetActive(value);
        }
    }
    public bool locked = true;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisMirror = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseOver()
    {

        transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseExit()
    {
        transform.GetChild(1).GetComponent<Renderer>().material.color = Color.white;
    }
}
