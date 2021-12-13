using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScnMng_Lv3 : MonoBehaviour
{
    public bool auxVidaBoss = true;
    public bool finNivel;
    public float setoutfnd;


    public GameObject canvas_pause;
    public GameObject canvas_UI;
    public Jugador pj;
    public Text obj_Text;
    public Image barradeVida;
    public GameObject barra;
    public GameObject contVida_pn;
    public CamaraScript cs;
    public Boss_Lv3 bs_lv3;
    public Image fnd_transic;
    public GameObject tp_dmgItem;
    public AudioSource AS_cs;
    
    public Text vid_Text;
    public Text btn_guardar;

    // Start is called before the first frame update
    void Start()
    {
        AS_cs.volume = 0;

        tp_dmgItem.SetActive(false);
        if (PlayerPrefs.GetString("Hard") == "true")
        {
            tp_dmgItem.SetActive(true);
        }
        barra.SetActive(false);
        contVida_pn.SetActive(false);
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
        else if (cs.movCam == true || auxVidaBoss == false)
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

            barradeVida.fillAmount = bs_lv3.vida / bs_lv3.vidaMax;

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
            SceneManager.LoadScene("TransFinal");
        }
    }

    public void Continuar()
    {
        Debug.Log("Continuuaaa");
        canvas_pause.SetActive(false);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Guardar()
    {
        PlayerPrefs.SetString("Nivel", "3");
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
