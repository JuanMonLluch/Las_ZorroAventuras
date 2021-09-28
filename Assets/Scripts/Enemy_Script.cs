using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    //VARIABLE PARA IDENTIFICAR LA DIRECCIÓN; 1 = DERECHA; 0 = IZQUIERDA
    public int auxFlip = 1;

    private int auxWalk = 0;
    public int speedEnemy = 4;
    
    public GameObject pj;

    public SpriteRenderer sp2d;
    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 v1 = new Vector2(0, transform.position.y);
        Vector2 v2 = new Vector2(0, pj.transform.position.y);
        Debug.Log(Vector2.Distance(v1, v2));
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - pj.transform.position.x >= 7) || (transform.position.x - pj.transform.position.x <= -7))
        {
            enemyAnimator.enabled = true;
            enemyAnimator.SetBool("Andar", true);
            if (auxFlip == 1 && auxWalk == 0)
            {
                gameObject.transform.Translate(new Vector2(speedEnemy * Time.deltaTime, 0));
            }
            else if (auxFlip == 0 && auxWalk == 0)
            {
                gameObject.transform.Translate(new Vector2(-speedEnemy * Time.deltaTime, 0));
            }
        }

        else if ((transform.position.x - pj.transform.position.x < 7) || (transform.position.x - pj.transform.position.x > -7))
        {
            Vector2 v1y = new Vector2(0, transform.position.y);
            Vector2 v2y = new Vector2(0, pj.transform.position.y);
            Vector2 v1x = new Vector2(transform.position.x, 0);
            Vector2 v2x = new Vector2(pj.transform.position.x, 0);
            
            Debug.Log("Y es: " + Vector2.Distance(v1y, v2y));
            
            enemyAnimator.enabled = false;
            
            if (transform.position.x - pj.transform.position.x < 0)
            {
                sp2d.flipX = false;
                auxFlip = 1;
            }
            if (transform.position.x - pj.transform.position.x > 0)
            {
                sp2d.flipX = true;
                auxFlip = 0;
            }

            if (Vector2.Distance(v1y,v2y) < 1)
            {
                enemyAnimator.enabled = true;
                enemyAnimator.SetBool("Andar", true);
                Debug.Log("X es: " + Vector2.Distance(v1x, v2x));

                Vector3 target = pj.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, target, 4 * Time.deltaTime);
                if(transform.position.x - pj.transform.position.x < 0)
                {
                    sp2d.flipX = false;
                    auxFlip = 1;
                }
                if (transform.position.x - pj.transform.position.x > 0)
                {
                    sp2d.flipX = true;
                    auxFlip = 0;
                }
                if (Vector2.Distance(v1x,v2x) <= 2)
                {
                    pj.gameObject.GetComponent<Jugador>().enabled = false;
                    enemyAnimator.SetBool("Andar", false);
                    transform.position = Vector3.MoveTowards(transform.position, target, 0.5f * Time.deltaTime);
                }
            }
                
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pared")
        {
            if(auxFlip == 0)
            {
                auxFlip = 1;
                sp2d.flipX = false;
            }
            else if(auxFlip == 1)
            {
                sp2d.flipX = true;
                auxFlip = 0;
            }
        }

        if(collision.gameObject.tag == "bala")
        {
            Destroy(gameObject);
        }
    }
}
