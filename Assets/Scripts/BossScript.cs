using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float vidaMax = 25;
    public float vida = 25;
    public float daño;
    public float cadDisparo;
    private bool disp = false;
    public bool limDisp = false;

    public CamaraScript camaraScript;

    public Jugador jugador;

    private GameObject[] arrgo;

    public Animator animator;

    public GameObject balaBoss;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            
            limDisp = false;
            animator.SetTrigger("Muerte");
            StartCoroutine(MuerteBoss());
            //gameObject.SetActive(false);
        }

        cadDisparo = Random.Range(0, 100);
        if(cadDisparo < 0.7f && disp == true && limDisp == true)
        {
            Instantiate(balaBoss, transform.position, transform.rotation);
            
        }

        arrgo = GameObject.FindGameObjectsWithTag("Projectile");

        if (arrgo.Length > 3)
        {
            disp = false;
        }
        else
        {
            disp = true;
        }
        
    }

    IEnumerator MuerteBoss()
    {
        yield return new WaitForSeconds(6);
        gameObject.SetActive(false);
        camaraScript.compruebaBoss();
        jugador.compruebaBoss();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bala")
        {
            daño = Random.Range(0f, 2f);
            Debug.Log(daño);
            Destroy(collision.gameObject);
            vida = vida - daño;
        }
    }
}
