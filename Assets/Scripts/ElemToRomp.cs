using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemToRomp : MonoBehaviour
{

    public int vidasCajas = 6;

    public GameObject impacto;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        impacto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(vidasCajas == 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "ElemToRomp")
        {
            if(collision.gameObject.tag == "bala") 
            {
                vidasCajas--;
                impacto.transform.position = transform.position;
                impacto.SetActive(true);
                ps.Play();
            }
        }
    }
}
