using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject Dam;
   public Transform targetPoint;
    private CircleCollider2D pull;
    private bool isUp;
    private Rigidbody2D DamRB;
    private Vector2 damv;

    // Start is called before the first frame update
    private void Start()
    {
        pull = GetComponent<CircleCollider2D>();     
        DamRB = this.transform.GetChild(0).GetComponent<Rigidbody2D>();
        damv = DamRB.velocity;
        //isUp = true;
    }
    private void Update()
    {
        if (Dam!=null)
        {
            if (isUp && Dam.transform.position.y < targetPoint.position.y)
            {
                DamRB.velocity = new Vector2(DamRB.velocity.x, 1.2f);
               
            }
            else
            {
                DamRB.velocity = damv;
            }
        }
       


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isUp = !isUp;
          
        }
    }
        }
