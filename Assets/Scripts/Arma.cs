using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{

    public GameObject bala;
    public GameObject balaIzq;
    public Jugador pj;

    public bool auxArma;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pj.compFinalLevel == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (auxArma == true)
                {
                    Instantiate(bala, new Vector3(transform.position.x + 0.6f, transform.position.y), bala.transform.rotation);
                }

                if (auxArma == false)
                {
                    Instantiate(balaIzq, new Vector3(transform.position.x - 2.2f, transform.position.y), balaIzq.transform.rotation);
                }



            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log(auxArma);
                if (auxArma == true)
                {
                    auxArma = false;
                    //transform.position = new Vector3(transform.position.x - 4, transform.position.y);
                }
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                //Bala bala = new Bala();
                //bala.velBala = 0.05f;
                Debug.Log(auxArma);
                if (auxArma == false)
                {
                    auxArma = true;
                    //transform.position = new Vector3(transform.position.x + 4, transform.position.y);
                }
            }
        }
        
    }
}
