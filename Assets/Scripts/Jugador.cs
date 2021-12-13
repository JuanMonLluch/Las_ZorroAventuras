using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{

    //VARIABLES PARA DIFERENTES FUNCIONES
    private int fuerzaMovimiento = 30;
    private int fuerzaSalto = 465;
    private bool salto = false;
    private int auxSalto = 0;
    public int objRecog = 0;
    public int vidas = 3;
    public int compFinalLevel; // 0 False, 1 True, 2 Nada
    public bool compTransicción;
    private bool compPlatMov;

    //DECLARAMOS LOS COMPONENTES
    public Rigidbody2D rd2D;
    public SpriteRenderer sp;
    public CapsuleCollider2D CC2D;
    public Animator animator;
    

    //OBJETO GAMEOBJECT PARA LA EXPLOSION
    public GameObject explosion;
    public Jugador pj;
    public GameObject boss;
    public LevelsMng mng;
    public ScnMng_Lv2 mng_lv2;
    public ScnMng_Lv3 mng_lv3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        explosion.SetActive(false);
        
        //animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (compFinalLevel == 0)
        {
            if (rd2D.velocity.x == 0)
            {
                animator.SetBool("Andando", false);
                animator.SetBool("Corriendo", false);

            }
            else if (((rd2D.velocity.x > -5 && rd2D.velocity.x < 0) || (rd2D.velocity.x > 0 && rd2D.velocity.x < 5)) && salto == false)
            {
                animator.SetBool("Andando", true);
                animator.SetBool("Corriendo", false);
            }
            else if ((rd2D.velocity.x < -6 || rd2D.velocity.x > 6) && salto == false)
            {

                animator.SetBool("Corriendo", true);
                //animator.SetBool("Andando", false);
            }

            /*if((rd2D.velocity.y < -0.2f) || (rd2D.velocity.y > 0.2f))
            {
                animator.SetBool("Corriendo", false);
                animator.SetBool("Andando", false);
                animator.SetBool("Saltando", true);
            }*/

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log(rd2D.velocity);
                //transform.Translate(new Vector3(fuerzaMovimiento, 0));

                //rd2D.AddForce(new Vector2(-(fuerzaMovimiento * Time.deltaTime), 0));
                //rd2D.velocity = new Vector2(rd2D.velocity.x - (fuerzaMovimiento * Time.deltaTime), rd2D.velocity.y);

                rd2D.velocity = new Vector2(-1 * (Mathf.Clamp(-rd2D.velocity.x + (fuerzaMovimiento * Time.deltaTime), 0, 16)), rd2D.velocity.y);

                sp.flipX = true;
                CC2D.offset = new Vector2(0.15f, -0.001f);

                /*if(rd2D.velocity.x > -5)
                {
                    animator.SetBool("Andando", true);
                    animator.SetBool("Corriendo", false);
                }
                else if(rd2D.velocity.x <= -5)
                {
                    animator.SetBool("Corriendo", true);
                    animator.SetBool("Andando", false);
                }*/


            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //transform.Translate(new Vector3(fuerzaMovimiento, 0));

                //rd2D.AddForce(new Vector2(fuerzaMovimiento * Time.deltaTime, 0));

                //rd2D.velocity = new Vector2(rd2D.velocity.x + (fuerzaMovimiento * Time.deltaTime), rd2D.velocity.y);

                rd2D.velocity = new Vector2(Mathf.Clamp(rd2D.velocity.x + (fuerzaMovimiento * Time.deltaTime), 0, 14), rd2D.velocity.y);
                sp.flipX = false;
                CC2D.offset = new Vector2(-0.15f, -0.001f);
                //animator.SetBool("Corriendo", true);

                /*if (rd2D.velocity.x <= 5)
                {
                    animator.SetBool("Corriendo", false);
                    animator.SetBool("Andando", true);
                }
                else if (rd2D.velocity.x > 5)
                {
                    animator.SetBool("Andando", false);
                    animator.SetBool("Corriendo", true);
                }*/
            }

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && auxSalto != 2)
            {
                if (auxSalto < 1)
                {
                    Debug.Log(auxSalto);
                    rd2D.AddForce(new Vector2(0, (fuerzaSalto)));
                    auxSalto++;
                    salto = true;
                    animator.SetBool("Andando", false);
                    animator.SetBool("Corriendo", false);
                    animator.SetBool("Saltando", true);
                }
                else if (auxSalto == 1)
                {
                    Debug.Log(auxSalto);
                    rd2D.AddForce(new Vector2(0, (fuerzaSalto * 0.55f)));
                    auxSalto++;
                }

                if (gameObject.transform.parent != null)
                {
                    gameObject.transform.parent = null;
                }
            }
        }

        else if (compFinalLevel == 1)
        {
            if (sp.flipX == true)
            {
                sp.flipX = false;
            }
            else
            {
                rd2D.velocity = new Vector2(5, rd2D.velocity.y);
                animator.SetBool("Andando", true);
            }
            

            if (compTransicción == true)
            {
                animator.SetBool("Andando", false);
            }

        }

        if(rd2D.velocity != new Vector2(0,0) && compPlatMov == false)
        {
            rd2D.isKinematic = false;
            gameObject.transform.parent = null;
        }

    }

    public void compruebaBoss()
    {
        if (boss.activeSelf == false)
        {
            compFinalLevel = 1;
        }
    }

    IEnumerator LevelReset()
    {
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator reinicio_Limite()
    {
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator MuertoCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Muerto", true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terreno")
        {
            auxSalto = 0;
            salto = false;
            //rd2D.velocity = new Vector2(rd2D.velocity.x, 0);
            animator.SetBool("Saltando", false);
        }
        
        if (collision.gameObject.tag == "Limite")
        {
            rd2D.mass = 1000;
            explosion.SetActive(true);
            StartCoroutine(reinicio_Limite());
        }

        if (collision.gameObject.tag == "Enemigo")
        {
            if (collision.gameObject.name == "DmgItem" || collision.gameObject.name == "fireball-red-tail-med")
            {
                compFinalLevel = 2;
                animator.SetBool("Muerto", true);
                StartCoroutine(LevelReset());
            }

            pj.enabled = false;
            StartCoroutine(MuertoCoroutine());
            
            StartCoroutine(LevelReset());
        }

        if (collision.gameObject.tag == "bala_Enemigo")
        {
            compFinalLevel = 2;
            gameObject.GetComponent<Jugador>().enabled = false;
            StartCoroutine(MuertoCoroutine());
            StartCoroutine(LevelReset());
        }

        if (collision.gameObject.tag == "Projectile")
        {
            vidas = vidas - 1;

            if (vidas == 0)
            {
                compFinalLevel = 2;
                animator.SetBool("Muerto", true);
                StartCoroutine(LevelReset());
            }
            
        }

        if (collision.gameObject.tag == "recogible")
        {
            
            objRecog = objRecog + 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Finish")
        {
            string nom_scene = SceneManager.GetActiveScene().name;
            if (nom_scene == "Lv1")
            {
                compTransicción = true;
                PlayerPrefs.SetString("Nivel", "2");
                mng.FinNivel();
            }
            else if (nom_scene == "Lv2")
            {
                compTransicción = true;
                PlayerPrefs.SetString("Nivel", "3");
                mng_lv2.FinNivel();
            }
            else if (nom_scene == "Lv3")
            {
                compTransicción = true;
                PlayerPrefs.SetString("Nivel", "3");
                PlayerPrefs.SetString("Hard", "true");
                mng_lv3.FinNivel();
            }
            
        }

        if(collision.gameObject.name == "TP Plat_Mov_Hor" || collision.gameObject.name == "TP Plat_Mov_Ver" || collision.gameObject.name == "TP Plat_Mov_Diag_Sup" || collision.gameObject.name == "TP Plat_Mov_Diag_Inf")
        {
            //rd2D.isKinematic = true;
            gameObject.transform.parent = collision.transform;
            compPlatMov = true;
        }
        else
        {
            compPlatMov = false;
        }

    }
}
