using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private Transform[] patrolPoints;

    [SerializeField] private float speed;
    private int patrolDestination;
    [SerializeField] private Transform playerTransform;
    private bool isChasing;
    [SerializeField] private float chaseDistance;


    // Update is called once per frame
    void Update()
    {
        if(isChasing)
        {   
            //enemy is on right of player so move enemy left
            if(transform.position.x > playerTransform.position.x)
            {
                transform.localScale=new Vector3(1,1,1);
                transform.position +=Vector3.left*speed*Time.deltaTime;
            }
            if(transform.position.x < playerTransform.position.x)
            {
                transform.localScale=new Vector3(-1,1,1);
                transform.position +=Vector3.right*speed*Time.deltaTime;
            }

            if(Vector2.Distance(transform.position, playerTransform.transform.position)>=4)
            {
                isChasing=false;
                if(Vector2.Distance(transform.position, patrolPoints[1].position) < Vector2.Distance(transform.position, patrolPoints[0].position))
                {
                    patrolDestination=1;
                    transform.localScale=new Vector3(-1,1,1);
                }
                else
                {
                    patrolDestination=0;
                    transform.localScale=new Vector3(1,1,1);
                }
            }
            
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position)<chaseDistance)
            {
                isChasing=true;
            }
            flipMoveEnemy();
        }     
    }

    private void flipMoveEnemy()
    {
        if(patrolDestination==0)
        {
            transform.position= Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed*Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[0].position)<.2f)
            {
                // flipping the enemy
                transform.localScale=new Vector3(-1,1,1);
                patrolDestination=1;
            } 
        }
        if(patrolDestination==1)
        {  
            transform.position= Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed*Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[1].position)<.2f)
            {              
                // Debug.Log("move Right");

                // flipping the enemy
                transform.localScale=new Vector3(1,1,1);   
                patrolDestination=0;
            } 
        }

    }
}
