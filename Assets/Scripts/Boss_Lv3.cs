using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Lv3 : MonoBehaviour
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

    private GameObject[] arr_balas;

    public GameObject gen_paj_boss;

    public GameObject paj_boss;

    public GameObject rat_boss;

    public Animator animator;

    public GameObject balaBoss;

    public BoxCollider2D bx2d;

    public Rigidbody2D rb2d;

    public SpriteRenderer sp2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arr_balas_act = GameObject.FindGameObjectsWithTag("Projectile");

        if (arr_balas_act.Length > 7)
        {
            disp = false;
        }
        else
        {
            disp = true;
        }

        if (vida <= 55 && vida > 45)
        {
            cadDisparo = Random.Range(0, 100);
            if (cadDisparo < 1 && disp == true && limDisp == true)
            {
                Instantiate(balaBoss, transform.position - new Vector3(2,0), transform.rotation);
            }
        }
        else if (vida <= 45 && vida >= 35)
        {
            animator.SetBool("ToElevarse", true);
            animator.SetBool("ToVolar", true);
            bx2d.offset = new Vector2(-0.05f, 0.07f);
            fase2boss();
        }
        else if (vida < 35 && vida >= 20)
        {
            rb2d.gravityScale = 1;
            animator.SetBool("ToElevarse", false);
            animator.SetBool("ToVolar", false);
            animator.SetBool("ToPosarse", true);
            animator.SetBool("ToIddle", true);

            bx2d.offset = new Vector2(0, 0);
            cadDisparo = Random.Range(0, 100);
            if (cadDisparo < 1 && disp == true && limDisp == true)
            {
                Instantiate(balaBoss, transform.position - new Vector3(2,0), transform.rotation);
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
            fase3boss();
        }
        else if (vida < 15 && vida > 0)
        {
            rb2d.gravityScale = 1;
            animator.SetBool("ToElevarse", false);
            animator.SetBool("ToVolar", false);
            animator.SetBool("ToPosarse", true);
            animator.SetBool("ToIddle", true);

            bx2d.offset = new Vector2(0, 0);
            cadDisparo = Random.Range(0, 100);
            if (cadDisparo < 1 && disp == true && limDisp == true)
            {
                Instantiate(balaBoss, transform.position - new Vector3(2,0), transform.rotation);
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

    IEnumerator MuerteBoss()
    {
        yield return new WaitForSeconds(4);
        animator.SetBool("ToDeath", false);
        animator.SetBool("ToElevarse", true);
        animator.SetBool("ToVolar", true);
        yield return new WaitForSeconds(4);
        sp2d.flipX = false;
        gameObject.transform.Translate(new Vector3(6 * Time.deltaTime, 0));
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
        Destroy(gameObject);
        camaraScript.compruebaBoss();
        jugador.compruebaBoss();

    }
    private void fase2boss()
    {
        float random_instan;
        random_instan = Random.Range(0, 100);

        if (random_instan < 0.1f)
        {
            int random_position = Random.Range(0, 100);
            if (random_position < 50 && disp == true)
            {
                Instantiate(paj_boss, gen_paj_boss.transform.position, gen_paj_boss.transform.rotation);
            }
            else if (random_position > 50 && disp == true)
            {
                Instantiate(paj_boss, gen_paj_boss.transform.position - new Vector3(0, -1.8f), gen_paj_boss.transform.rotation);
            }

        }
    }

    private void fase3boss()
    {
        float random_instan;
        random_instan = Random.Range(0, 100);

        if (random_instan < 0.1f)
        {
            int random_position = Random.Range(0, 100);
            if (random_position < 50 && disp == true)
            {
                Instantiate(rat_boss, gen_paj_boss.transform.position, gen_paj_boss.transform.rotation);
            }
            else if (random_position > 50 && disp == true)
            {
                Instantiate(rat_boss, gen_paj_boss.transform.position - new Vector3(0, -1.8f), gen_paj_boss.transform.rotation);
            }

        }
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
