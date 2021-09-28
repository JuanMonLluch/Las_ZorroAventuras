using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script_Lv2 : MonoBehaviour
{
    private bool auxDisp = true;
    public int alcanceVision;
    public float anguloQuatBala;
    public int posXbala;
    public int posYbala;
    public float delayDisp;

    public GameObject bola;
    public GameObject pj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v1x = new Vector2(transform.position.x, 0);
        Vector2 v2x = new Vector2(pj.transform.position.x, 0);

        if (Vector2.Distance(v1x, v2x) < alcanceVision && auxDisp == true)
        {

            InvokeRepeating("EnemigoDispara", delayDisp, 2.5f);
            auxDisp = false;
        }
        else if (Vector2.Distance(v1x, v2x) < -1 && auxDisp == false)
        {
            auxDisp = true;
            CancelInvoke();
        }
    }


    public void EnemigoDispara()
    {
        Quaternion quaternion = new Quaternion(bola.transform.rotation.x, bola.transform.rotation.y, anguloQuatBala, bola.transform.rotation.w);
        Instantiate(bola, new Vector3(transform.position.x - posXbala, transform.position.y - posYbala), quaternion);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "bala")
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}
