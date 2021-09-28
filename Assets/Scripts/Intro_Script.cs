using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_Script : MonoBehaviour
{

    public Image imgNegro;
    public Image imgBlanco;

    public Image iconFox1;
    public Image iconFox2;
    public Image iconFox3;

    public Text dialFox1;
    public Text dialFox2;
    public Text dialFox3;


    public Image iconAld1;
    public Image iconAld2;

    public Text dialAld1;
    public Text dialAld2;

    public float setOutfnd;
    private bool auxSetOut;

    // Start is called before the first frame update
    void Start()
    {
        imgBlanco.color = new Color(imgBlanco.color.r, imgBlanco.color.g, imgBlanco.color.b, 0);
        iconFox1.color = new Color(iconFox1.color.r, iconFox1.color.g, iconFox1.color.b, 0);
        iconFox2.color = new Color(iconFox2.color.r, iconFox2.color.g, iconFox2.color.b, 0);
        iconFox3.color = new Color(iconFox3.color.r, iconFox3.color.g, iconFox3.color.b, 0);
        dialFox1.color = new Color(dialFox1.color.r, dialFox1.color.g, dialFox1.color.b, 0);
        dialFox2.color = new Color(dialFox2.color.r, dialFox2.color.g, dialFox2.color.b, 0);
        dialFox3.color = new Color(dialFox3.color.r, dialFox3.color.g, dialFox3.color.b, 0);
        iconAld1.color = new Color(iconAld1.color.r, iconAld1.color.g, iconAld1.color.b, 0);
        iconAld2.color = new Color(iconAld2.color.r, iconAld2.color.g, iconAld2.color.b, 0);
        dialAld1.color = new Color(dialAld1.color.r, dialAld1.color.g, dialAld1.color.b, 0);
        dialAld2.color = new Color(dialAld2.color.r, dialAld2.color.g, dialAld2.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (auxSetOut == false)
        {
            imgBlanco.color = new Color(imgBlanco.color.r, imgBlanco.color.g, imgBlanco.color.b, Mathf.Clamp(imgBlanco.color.a + setOutfnd, 0, 1));
            iconFox1.color = new Color(iconFox1.color.r, iconFox1.color.g, iconFox1.color.b, Mathf.Clamp(iconFox1.color.a + setOutfnd, 0, 1));
            iconFox2.color = new Color(iconFox2.color.r, iconFox2.color.g, iconFox2.color.b, Mathf.Clamp(iconFox2.color.a + setOutfnd, 0, 1));
            iconFox3.color = new Color(iconFox3.color.r, iconFox3.color.g, iconFox3.color.b, Mathf.Clamp(iconFox3.color.a + setOutfnd, 0, 1));
            dialFox1.color = new Color(dialFox1.color.r, dialFox1.color.g, dialFox1.color.b, Mathf.Clamp(dialFox1.color.a + setOutfnd, 0, 1));
            dialFox2.color = new Color(dialFox2.color.r, dialFox2.color.g, dialFox2.color.b, Mathf.Clamp(dialFox2.color.a + setOutfnd, 0, 1));
            dialFox3.color = new Color(dialFox3.color.r, dialFox3.color.g, dialFox3.color.b, Mathf.Clamp(dialFox3.color.a + setOutfnd, 0, 1));
            iconAld1.color = new Color(iconAld1.color.r, iconAld1.color.g, iconAld1.color.b, Mathf.Clamp(iconAld1.color.a + setOutfnd, 0, 1));
            iconAld2.color = new Color(iconAld2.color.r, iconAld2.color.g, iconAld2.color.b, Mathf.Clamp(iconAld2.color.a + setOutfnd, 0, 1));
            dialAld1.color = new Color(dialAld1.color.r, dialAld1.color.g, dialAld1.color.b, Mathf.Clamp(dialAld1.color.a + setOutfnd, 0, 1));
            dialAld2.color = new Color(dialAld2.color.r, dialAld2.color.g, dialAld2.color.b, Mathf.Clamp(dialAld2.color.a + setOutfnd, 0, 1));
        }
        


        if (Input.anyKey)
        {
            auxSetOut = true;
        }


        if (auxSetOut == true)
        {
            imgBlanco.color = new Color(imgBlanco.color.r, imgBlanco.color.g, imgBlanco.color.b, imgBlanco.color.a - setOutfnd);
            iconFox1.color = new Color(iconFox1.color.r, iconFox1.color.g, iconFox1.color.b, iconFox1.color.a - setOutfnd);
            iconFox2.color = new Color(iconFox2.color.r, iconFox2.color.g, iconFox2.color.b, iconFox2.color.a - setOutfnd);
            iconFox3.color = new Color(iconFox3.color.r, iconFox3.color.g, iconFox3.color.b, iconFox3.color.a - setOutfnd);
            dialFox1.color = new Color(dialFox1.color.r, dialFox1.color.g, dialFox1.color.b, dialFox1.color.a - setOutfnd);
            dialFox2.color = new Color(dialFox2.color.r, dialFox2.color.g, dialFox2.color.b, dialFox2.color.a - setOutfnd);
            dialFox3.color = new Color(dialFox3.color.r, dialFox3.color.g, dialFox3.color.b, dialFox3.color.a - setOutfnd);
            iconAld1.color = new Color(iconAld1.color.r, iconAld1.color.g, iconAld1.color.b, iconAld1.color.a - setOutfnd);
            iconAld2.color = new Color(iconAld2.color.r, iconAld2.color.g, iconAld2.color.b, iconAld2.color.a - setOutfnd);
            dialAld1.color = new Color(dialAld1.color.r, dialAld1.color.g, dialAld1.color.b, dialAld1.color.a - setOutfnd);
            dialAld2.color = new Color(dialAld2.color.r, dialAld2.color.g, dialAld2.color.b, dialAld2.color.a - setOutfnd);

            if (imgBlanco.color.a < 0)
            {
                SceneManager.LoadScene("Lv1");
            }
        }

        
    }
}
