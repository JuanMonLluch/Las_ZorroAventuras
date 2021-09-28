using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Start_Button : MonoBehaviour
{

    public GameObject canvas_inicial;
    public GameObject canvas_Niveles;
    public Canvas cnv_fnd;
    public Image img_negro;

    public float auxColorA = 0;
    private bool auxSetInimgNegro;
    float aux;
    bool auxCambiaNivel;
    public string nom_nivel;

    // Start is called before the first frame update
    void Start()
    {
        cnv_fnd.enabled = false;
        canvas_Niveles.SetActive(false);
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
}
