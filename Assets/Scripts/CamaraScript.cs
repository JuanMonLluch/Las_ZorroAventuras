using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{

    public bool auxCam = true;
    public bool movCam = true;
    public int velCam;

    public GameObject canvas;
    public GameObject pj;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(canvas.activeSelf == true)
            {
                canvas.SetActive(false);
                auxCam = true;

            }
            else
            {
                canvas.SetActive(true);
                auxCam = false;
                
            }
        }

        if ( canvas.activeSelf == true)
        {
            pj.GetComponent<Jugador>().enabled = false;
        }
        else if (canvas.activeSelf == false && movCam == true)
        {
            pj.GetComponent<Jugador>().enabled = true;
            transform.Translate(new Vector3(velCam * Time.deltaTime, 0, 0));
        }
    }

    public void compruebaBoss()
    {
        if (boss.activeSelf == false)
        {
            movCam = true;
        }
    }

    /*public void moverCam(bool auxcam)
    {
        if (auxcam == true)
        {
            pj.GetComponent<Jugador>().enabled = true;
            transform.Translate(new Vector3(2 * Time.deltaTime, 0, 0));
        }
        else if (auxcam == false)
        {
            pj.GetComponent<Jugador>().enabled = false;
        }
    }*/

    
}
