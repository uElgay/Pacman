using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int targetPoint;
    public float speed;

    void Start()
    {
        targetPoint=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position==patrolPoints[targetPoint].position)
        {
            transform.Rotate(0,90.0f,0);
            increaseTargetInt();
        }
        transform.position=Vector3.MoveTowards(transform.position,patrolPoints[targetPoint].position,speed*Time.deltaTime);
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if(targetPoint>=patrolPoints.Length)
            targetPoint=0;
    }
}
