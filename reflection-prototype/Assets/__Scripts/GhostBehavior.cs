using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    private Ray groundRay;
    public GameObject targetObject;
    private Vector3 targetPos;
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
        Move();
    }

    void Move()
    {
        if (targetObject)
        {
            targetPos = targetObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * 0.05f);
        }

        Vector3 tempPos = transform.position;
        float age = Time.time - startTime;
        float theta = Mathf.PI * 2 * age / floatSpeed;
        float sin = Mathf.Sin(theta);
        tempPos.y = y0 + floatHeight * sin;
        transform.position = tempPos;
    }
}
