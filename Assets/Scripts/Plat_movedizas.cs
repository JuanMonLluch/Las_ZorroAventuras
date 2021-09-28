using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_movedizas : MonoBehaviour
{

    //true = arriba; false = abajo
    private bool auxLim = false;
    private int speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("cambioSent", 2, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (auxLim == true)
        {   
            gameObject.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        else if (auxLim == false)
        {
            gameObject.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }
    }

    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Choke");
        if (collision.gameObject.tag == "Pared")
        { 
            Debug.Log("Choke");
            if (auxLim == true)
            {
                auxLim = false;
            }
            else if(auxLim == false)
            {
                auxLim = true;
            }
        }
    }*/

    public void cambioSent()
    {
        if (auxLim == true)
        {
            auxLim = false;
            //gameObject.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        else if (auxLim == false)
        {
            auxLim = true;
            //gameObject.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }
    }
}
