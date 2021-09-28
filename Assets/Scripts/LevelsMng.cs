using System.Collections;
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

    public Jugador pj;
    public BossScript bossScript;
    public CamaraScript cs;

    // Start is called before the first frame update
    void Start()
    {
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

        if (finNivel == true)
        {
            fnd_transic.color = new Color(fnd_transic.color.r, fnd_transic.color.g, fnd_transic.color.b, fnd_transic.color.a + setoutfnd);
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

    }

    public void Salir()
    {
        Application.Quit();
    }

    public void FinNivel()
    {
        finNivel = true;
    }
}
