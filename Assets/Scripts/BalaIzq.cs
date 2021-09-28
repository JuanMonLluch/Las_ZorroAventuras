using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

public class BalaIzq : MonoBehaviour
{

    System.Timers.Timer timerDestruccion = new System.Timers.Timer();
    private bool Destruccion = false;
    private float velBala = 14;
    private bool auxInterval = true;

    private GameObject[] arrRec;

    // Start is called before the first frame update
    void Start()
    {
        timerDestruccion.Elapsed += new System.Timers.ElapsedEventHandler(timerOut);
        timerDestruccion.Interval = 450;
        timerDestruccion.Enabled = true;
        //timerDestruccion.Start();
    }

    private void timerOut(object sender, ElapsedEventArgs e)
    {
        Debug.Log("riiiiiin");
        Destruccion = true;
    }

    // Update is called once per frame
    void Update()
    {
        //La dirección del movimiento es diferente porque hemos girado el sprite para que tenga un sentido y dirección correctos
        transform.Translate(new Vector3(0, -velBala * Time.deltaTime));

        timerDestruccion.Start();

        if (Destruccion == true)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
            timerDestruccion.Stop();
        }

        arrRec = GameObject.FindGameObjectsWithTag("recogible");
        if (arrRec.Length == 0 && auxInterval == true)
        {
            auxInterval = false;
            timerDestruccion.Interval = 600;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" || collision.gameObject.tag != "bala")
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
            timerDestruccion.Stop();
        }
    }
}
