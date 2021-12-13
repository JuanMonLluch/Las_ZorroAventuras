﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMng : MonoBehaviour
{

    public bool auxVidaBoss = true;
    public bool finNivel;
    public float setoutfnd;

    public Text obj_Text;
    public Text vid_Text;

    public GameObject canvas;
    public GameObject cam;
    public GameObject contVida_pn;
    public Image barradeVida;
    public GameObject barra;
    public Image fnd_transic;
    public Text btn_guardar;
    public GameObject tp_dmgItem;
    public AudioSource AS_cs;

    public Jugador pj;
    public BossScript bossScript;
    public CamaraScript cs;

    // Start is called before the first frame update
    void Start()
    {
        AS_cs.volume = 0;
        

        tp_dmgItem.SetActive(false);
        if (PlayerPrefs.GetString("Hard") == "true")
        {
            tp_dmgItem.SetActive(true);
        }

        contVida_pn.SetActive(false);
        barra.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        obj_Text.text = "X " + pj.objRecog.ToString(); 
        
        if (cs.movCam == false)
        {
            if (auxVidaBoss == true)
            {
                contVida_pn.SetActive(true);
                barra.SetActive(true);
            }
        }
        else if (cs.movCam == true || auxVidaBoss==false)
        {
            contVida_pn.SetActive(false);
            barra.SetActive(false);
        }

        if (contVida_pn.activeSelf == true)
        {
            vid_Text.text = "X " + pj.vidas.ToString();

            if (pj.vidas < 0)
            {
                vid_Text.text = "X 0";
            }

            barradeVida.fillAmount = bossScript.vida / bossScript.vidaMax;

            if (barradeVida.fillAmount == 0)
            {
                auxVidaBoss = false;
            }
        }
        if (finNivel == false && AS_cs.volume < 0.25)
        {
            AS_cs.volume = AS_cs.volume + setoutfnd;
        }
        if (finNivel == true)
        {
            fnd_transic.color = new Color(fnd_transic.color.r, fnd_transic.color.g, fnd_transic.color.b, fnd_transic.color.a + setoutfnd);
            AS_cs.volume = AS_cs.volume - setoutfnd;
        }

        if (fnd_transic.color.a > 1)
        {
            SceneManager.LoadScene("TransLv1Lv2");
        }
        
    }

    public void Continuar()
    {
        Debug.Log("Continuuaaa");
        canvas.SetActive(false);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Guardar()
    {
        PlayerPrefs.SetString("Nivel", "1");
        btn_guardar.text = "Guardado";
        StartCoroutine(cambioText_Guardar());
    }

    public void Salir()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    public void FinNivel()
    {
        finNivel = true;
    }

    IEnumerator cambioText_Guardar()
    {
        yield return new WaitForSeconds(2);
        btn_guardar.text = "Guardar";
    }
}
