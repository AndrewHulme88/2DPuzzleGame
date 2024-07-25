using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointHazard : MonoBehaviour
{
    [SerializeField] Transform[] movePoints;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float waitAtPoints = 1f;
    
    private int currentPoint;
    private Transform targetPoint;
    private float waitCounter;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetNextTarget();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            rb.velocity = Vector2.zero;

            waitCounter -= Time.deltaTime;
            if(waitCounter <= 0)
            {
                SetNextTarget();
            }
        }
        else
        {
            Vector2 moveDirection = (targetPoint.position - transform.position).normalized;
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void SetNextTarget()
    {
        currentPoint = (currentPoint + 1) % movePoints.Length;
        targetPoint = movePoints[currentPoint];
        waitCounter = waitAtPoints;
    }
}
