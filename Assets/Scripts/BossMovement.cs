using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float speed = 1f;
    private float xPos;
    public Transform targetPoint;

    void Start()
    {
        //targetPoint.position = new Vector2(0.5f,3.32f);
    }
   /* private void FixedUpdate()
    {

        this.transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        if(transform.position.x == targetPoint.position.x)
        {
            xPos = Random.Range(-1.84f, 0.74f);
            if(xPos >= transform.position.x)
            {
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            else if(xPos <= transform.position.x)
            {
                Vector3 localScale = transform.localScale;
                localScale.x *= 1f;
                transform.localScale = localScale;
            }
            targetPoint.position = new Vector2 (xPos,this.transform.position.y);
        }
    }*/
}
