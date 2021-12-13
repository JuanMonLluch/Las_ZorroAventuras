using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Paj_Script : MonoBehaviour
{

    public float delay_disp;
    public float anguloQuatBala;
    public int cont_balas_inst;

    public GameObject bola;

    public bool auxDisp;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemigoDispara", delay_disp, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemigoDispara()
    {
        //arr_bolas = GameObject.FindGameObjectsWithTag("bala_Enemigo");

        if (auxDisp == true)
        {
            Quaternion quaternion = new Quaternion(bola.transform.rotation.x, bola.transform.rotation.y, anguloQuatBala, bola.transform.rotation.w);
            Instantiate(bola, new Vector3(transform.position.x, transform.position.y - 1), quaternion);
            cont_balas_inst++;
            
            
        }
        if (cont_balas_inst == 4)
        {
            cont_balas_inst = 0;
            auxDisp = false;
            StartCoroutine(esperaDisp());
            
        }
        
    }

    IEnumerator esperaDisp()
    {
        yield return new WaitForSeconds(2);
        auxDisp = true;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
