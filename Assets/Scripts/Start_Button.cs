using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Start_Button : MonoBehaviour
{

    public GameObject canvas_inicial;
    public GameObject canvas_Niveles;
    public GameObject canvas_Controles;
    public Canvas cnv_fnd;
    public Image img_negro;
    public Button btn_1;
    public Button btn_2;
    public Button btn_3;
    public Text txt_Nuevos_cambios;


    public float auxColorA = 0;
    private bool auxSetInimgNegro;
    float aux;
    bool auxCambiaNivel;
    public string nom_nivel;
    private Color gris = new Color(0,0,0,255);
    private Color naranja = new Color(180,0,0,161);


    //VARIABLE PARA GUARDAR EL PROCESO DE NIVELES
    
    public string nivel;

    // Start is called before the first frame update
    void Start()
    {
        btn_1.enabled = true;
        btn_2.enabled = false;
        btn_3.enabled = false;
        btn_1.image.color = naranja;
        btn_2.image.color = gris;
        btn_3.image.color = gris;
        txt_Nuevos_cambios.enabled = false;


        cnv_fnd.enabled = false;
        canvas_Niveles.SetActive(false);
        canvas_Controles.SetActive(false);

        
        nivel = PlayerPrefs.GetString("Nivel");

        /*if (nivel == "1")
        {
            btn_1.enabled = true;
            btn_1.image.color = naranja;
        }*/
        if (nivel == "2")
        {
            btn_1.enabled = true;
            btn_2.enabled = true;
            btn_1.image.color = naranja;
            btn_2.image.color = naranja;
        }
        else if (nivel == "3")
        {
            btn_1.enabled = true;
            btn_2.enabled = true;
            btn_3.enabled = true;
            btn_1.image.color = naranja;
            btn_2.image.color = naranja;
            btn_3.image.color = naranja;
            txt_Nuevos_cambios.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        aux = img_negro.color.a;
        if (auxSetInimgNegro==true)
        {
            img_negro.color = new Color(img_negro.color.r, img_negro.color.g, img_negro.color.b, img_negro.color.a + 0.003f);
        }
        if (aux >= 1)
        {
            auxCambiaNivel = true;
            cargaNivel(nom_nivel);
        }
    }

    public void cambiaCanvas()
    {
        canvas_inicial.SetActive(false);
        canvas_Niveles.SetActive(true);
    }

    public void salir()
    {
        Debug.Log("Fuera");
        Application.Quit();
    }

    public void cargaNivel(string nivel)
    {
        nom_nivel = nivel;
        cnv_fnd.enabled = true;
        auxSetInimgNegro = true;
        /*float aux = img_negro.color.a;
        while (auxColorA < 1)
        {
            
            aux += 0.001f;
            img_negro.color = new Color(img_negro.color.r, img_negro.color.g, img_negro.color.b, aux);
            Debug.Log(img_negro.color.a);
            auxColorA = aux;
        }*/
        if (auxCambiaNivel == true)
        {
            SceneManager.LoadScene(nivel);
        }
    }

    public void Controles()
    {
        canvas_inicial.SetActive(false);
        canvas_Controles.SetActive(true);
    }
    public void cierraControles()
    {
        canvas_Controles.SetActive(false);
        canvas_inicial.SetActive(true);
    }

    public void cierraNiveles()
    {
        canvas_Niveles.SetActive(false);
        canvas_inicial.SetActive(true);
    }
}
