using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Script_Lv2 : MonoBehaviour
{
    public float vidaMax = 40;
    public float vida = 40;
    public float daño;
    public float cadDisparo;
    private bool disp = false;
    public bool limDisp = false;

    public CamaraScript camaraScript;

    public Jugador jugador;

    private GameObject[] arr_balas_act;

    public GameObject gen_paj_boss;

    public GameObject paj_boss;

    public Animator animator;

    public GameObject balaBoss;

    public BoxCollider2D bx2d;

    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arr_balas_act = GameObject.FindGameObjectsWithTag("Projectile");

        if (arr_balas_act.Length > 5)
        {
            disp = false;
        }
        else
        {
            disp = true;
        }

        if (vida <= 40 && vida > 35)
        {
            cadDisparo = Random.Range(0, 100);
            if (cadDisparo < 1 && disp == true && limDisp == true)
            {
                Instantiate(balaBoss, transform.position - new Vector3(4, -2), transform.rotation);
            }
        }
        else if (vida <= 35 && vida >= 30)
        {
            animator.SetBool("ToElevarse", true);
            animator.SetBool("ToVolar", true);
            bx2d.offset = new Vector2(-0.05f,0.07f);
            fase2boss();
        }
        else if (vida < 30 && vida >= 20)
        {
            rb2d.gravityScale = 1;
            animator.SetBool("ToElevarse", false);
            animator.SetBool("ToVolar", false);
            animator.SetBool("ToPosarse", true);
            animator.SetBool("ToIddle", true);

            bx2d.offset = new Vector2(0,0);
            cadDisparo = Random.Range(0, 100);
            if (cadDisparo < 1 && disp == true && limDisp == true)
            {
                Instantiate(balaBoss, transform.position - new Vector3(4, -2), transform.rotation);
            }
        }
        else if (vida < 20 && vida >= 15)
        {
            rb2d.gravityScale = 0;
            animator.SetBool("ToPosarse", false);
            animator.SetBool("ToIddle", false);
            animator.SetBool("ToElevarse", true);
            animator.SetBool("ToVolar", true);
            bx2d.offset = new Vector2(-0.05f, 0.07f);
            fase2boss();
        }
        else if (vida < 15 && vida > 0)
        {
            rb2d.gravityScale = 1;
            animator.SetBool("ToElevarse", false);
            animator.SetBool("ToVolar", false);
            animator.SetBool("ToPosarse", true);
            animator.SetBool("ToIddle", true);

            bx2d.offset = new Vector2(0,0);
            cadDisparo = Random.Range(0, 100);
            if (cadDisparo < 1 && disp == true && limDisp == true)
            {
                Instantiate(balaBoss, transform.position - new Vector3(4, -2), transform.rotation);
            }
        }
        else if (vida <= 0)
        {
            limDisp = false;
            animator.SetBool("ToPosarse", false);
            animator.SetBool("ToIddle", false);
            animator.SetBool("ToDeath", true);
            StartCoroutine(MuerteBoss());
        }
    }

    private void fase2boss()
    {
        float random_instan;
        random_instan = Random.Range(0, 100);
        if ( random_instan < 0.3f)
        {
            int random_position = Random.Range(0, 100);
            if (random_position < 50)
            {
                Instantiate(paj_boss, gen_paj_boss.transform.position, gen_paj_boss.transform.rotation);
            }
            else
            {
                Instantiate(paj_boss, gen_paj_boss.transform.position - new Vector3(0, -1.8f), gen_paj_boss.transform.rotation);
            }
            
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
        if (collision.gameObject.tag == "bala")
        {
            daño = Random.Range(0.1f, 3f);
            Debug.Log(daño);
            Destroy(collision.gameObject);
            vida = vida - daño;
        }
    }
}
