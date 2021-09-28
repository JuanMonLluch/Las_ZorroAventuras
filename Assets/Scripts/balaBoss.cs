using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaBoss : MonoBehaviour
{

    private int velBala = 4;
    
    public GameObject pj;

    Vector3 target; 
    // Start is called before the first frame update
    void Start()
    {
        pj = GameObject.Find("Jugador");
       
        target = pj.transform.position;
        Debug.Log("pj: " + target);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target - new Vector3(4, 0), velBala * Time.deltaTime);
        if (transform.position == (target - new Vector3(4,0)))
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag != "boss" && collision.gameObject.tag != "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
