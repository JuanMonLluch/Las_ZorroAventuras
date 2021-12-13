using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Plat_Diag_Sup : MonoBehaviour
{
    //false izq true derecha
    private bool auxSentido;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (auxSentido == false)
        {
            gameObject.transform.Translate(new Vector2(3 * Time.deltaTime, 2 * Time.deltaTime));
        }
        else if (auxSentido == true)
        {
            gameObject.transform.Translate(new Vector2(-3 * Time.deltaTime, -2 * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Limite")
        {
            if (auxSentido == false)
            {
                auxSentido = true;
            }
            else if (auxSentido == true)
            {
                auxSentido = false;
            }
        }

    }
}
