using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajaro_Boss_Vuelo : MonoBehaviour
{

    public int vel;

    public float anguloQuatBala;

    private GameObject[] arr_balas_act;
    // True derecha, false Izq
    private bool auxFlip;

    public Boss_Lv3 boss_lv3;

    public GameObject bola;

    public SpriteRenderer sp2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boss_lv3.vida > 0)
        {
            if (auxFlip == false)
            {
                sp2d.flipX = true;
                transform.Translate(new Vector3(-vel * Time.deltaTime, 0));
            }
            else
            {
                sp2d.flipX = false;
                transform.Translate(new Vector3(vel * Time.deltaTime, 0));
            }

            arr_balas_act = GameObject.FindGameObjectsWithTag("Projectile");
            float rmd = Random.Range(0, 100);
            if (rmd < 0.05 && arr_balas_act.Length < 7 && boss_lv3.limDisp == true)
            {
                Quaternion quaternion = new Quaternion(bola.transform.rotation.x, bola.transform.rotation.y, anguloQuatBala, bola.transform.rotation.w);
                Instantiate(bola, new Vector3(transform.position.x, transform.position.y - 2), quaternion);
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Limite")
        {
            if (auxFlip == true)
            {
                auxFlip = false;
            }
            else
            {
                auxFlip = true;
            }
        }
    }
}
