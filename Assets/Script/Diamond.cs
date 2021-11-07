using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private CircleCollider2D Dia;
    //public Transform targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        Dia= GetComponent<CircleCollider2D>();
        //targetPoint = transform.GetChild(0).GetComponent<Transform>();
    }
    //private void Update()
    //{
    //    if (transform.position.y> targetPoint.position.y)
    //    {
    //        transform.position = targetPoint.position;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           Destroy(this.gameObject);
            Player.HP++;
        }
    }

}
