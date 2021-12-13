using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class Arma : MonoBehaviour
{

    public GameObject bala;
    public GameObject balaIzq;
    public Jugador pj;
    public GameObject pj_gameobject;
    public Image energia;
    public Image circ_int_energia;

    public bool auxArma;
    private bool auxReg_Energ;

    System.Timers.Timer timer_Reg_Energ = new System.Timers.Timer();

    // Start is called before the first frame update
    void Start()
    {
        timer_Reg_Energ.Elapsed += new System.Timers.ElapsedEventHandler(timerOut);
        timer_Reg_Energ.Interval = 1250;
        timer_Reg_Energ.Enabled = true;
    }

    private void timerOut(object sender, ElapsedEventArgs e)
    {
        auxReg_Energ = true;
    }
    // Update is called once per frame
    void Update()
    {
        energia.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f);

        if (auxReg_Energ == true)
        {
            energia.fillAmount = Mathf.Clamp(energia.fillAmount + 0.005f, 0, 1);
            energia.color = new Color(energia.color.r, energia.color.g, energia.color.b, Mathf.Clamp(energia.color.a - 0.005f, 0, 1));
            circ_int_energia.color = new Color(circ_int_energia.color.r, circ_int_energia.color.g, circ_int_energia.color.b, Mathf.Clamp(circ_int_energia.color.a - 0.005f, 0, 1));
        }

        if (pj.compFinalLevel == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                auxReg_Energ = false;
                timer_Reg_Energ.Stop();
                timer_Reg_Energ.Start();
                energia.color = new Color(energia.color.r, energia.color.g, energia.color.b,Mathf.Clamp(energia.color.a + 1, 0, 1));
                circ_int_energia.color = new Color(circ_int_energia.color.r, circ_int_energia.color.g, circ_int_energia.color.b, Mathf.Clamp(circ_int_energia.color.a + 1, 0, 1));
                
                if (auxArma == true && energia.fillAmount > 0)
                {
                    Instantiate(bala, new Vector3(transform.position.x + 0.6f, transform.position.y), bala.transform.rotation);
                }

                if (auxArma == false && energia.fillAmount > 0)
                {
                    Instantiate(balaIzq, new Vector3(transform.position.x - 2.2f, transform.position.y), balaIzq.transform.rotation);
                }
                energia.fillAmount = Mathf.Clamp(energia.fillAmount - 0.15f, 0, 1);


            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log(auxArma);
                if (auxArma == true)
                {
                    auxArma = false;
                    //transform.position = new Vector3(transform.position.x - 4, transform.position.y);
                }
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                //Bala bala = new Bala();
                //bala.velBala = 0.05f;
                Debug.Log(auxArma);
                if (auxArma == false)
                {
                    auxArma = true;
                    //transform.position = new Vector3(transform.position.x + 4, transform.position.y);
                }
            }
        }
        
    }
}
