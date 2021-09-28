using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script1 : MonoBehaviour
{

    private bool auxDisp = true;
    public int alcanceVision;

    public GameObject bola;
    public GameObject pj;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("EnemigoDispara", 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v1x = new Vector2(transform.position.x, 0);
        Vector2 v2x = new Vector2(pj.transform.position.x, 0);

        if (Vector2.Distance(v1x,v2x) < alcanceVision && auxDisp == true)
        {

            InvokeRepeating("EnemigoDispara", 0, 2.5f);
            auxDisp = false;
        }
        else if (Vector2.Distance(v1x,v2x) < -1 && auxDisp == false)
        {
            auxDisp = true;
            CancelInvoke();
        }
    }


    public void EnemigoDispara()
    {
        
        Instantiate(bola, new Vector3(transform.position.x - 1.2f, transform.position.y), bola.transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "bala")
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}
