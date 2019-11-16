using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    private Ray groundRay;
    public GameObject targetObject;
    private Rigidbody rb;
    private float startTime;
    private float y0;

    public float floatHeight = 3f;
    public float floatSpeed = 5f;
    public float speed = 1f;

    void Start()
    {
        targetObject = PlayerBehavior.S.gameObject;
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
        y0 = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 tempPos = transform.position;
        float age = Time.time - startTime;
        float theta = Mathf.PI * 2 * age / floatSpeed;
        float sin = Mathf.Sin(theta);
        tempPos.y = y0 + floatHeight * sin;
        transform.position = tempPos;

        if (targetInSight(targetObject))
        {
            Vector3 targetPos = targetObject.transform.position;
            Vector3 targetDir = targetPos - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * 0.05f);
            Quaternion toRotation = Quaternion.LookRotation(targetDir, transform.up);
            /*print("Target:" + targetDir.ToString());
            print("Rotate:"+toRotation.ToString());*/
            Quaternion rot = Quaternion.Lerp(transform.rotation, toRotation, 100f);
            transform.rotation = rot;
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(new Ray(transform.position, transform.forward));
    }

    bool targetInSight(GameObject target)
    {
        Vector3 targetDir = (target.transform.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, targetDir) < 60)
        {
            return true;
        }

        return false;
        /*Ray sightline = new Ray(transform.position, targetDir);
        RaycastHit hit;
        if (Physics.Raycast(sightline, out hit, 20))
        {
            
        }*/
    }
}
