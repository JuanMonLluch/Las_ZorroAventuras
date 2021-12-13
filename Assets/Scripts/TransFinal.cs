using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransFinal : MonoBehaviour
{
    public Image fnd_blanco;

    public Text text1;

    public float setOutfnd;
    private bool auxSetOut;

    // Start is called before the first frame update
    void Start()
    {
        fnd_blanco.color = new Color(fnd_blanco.color.r, fnd_blanco.color.g, fnd_blanco.color.b, 0);
        text1.color = new Color(text1.color.r, text1.color.g, text1.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (auxSetOut == false)
        {
            fnd_blanco.color = new Color(fnd_blanco.color.r, fnd_blanco.color.g, fnd_blanco.color.b, Mathf.Clamp(fnd_blanco.color.a + setOutfnd, 0, 1));
            text1.color = new Color(text1.color.r, text1.color.g, text1.color.b, Mathf.Clamp(text1.color.a + setOutfnd, 0, 1));
        }
        else if (auxSetOut == true)
        {
            fnd_blanco.color = new Color(fnd_blanco.color.r, fnd_blanco.color.g, fnd_blanco.color.b, Mathf.Clamp(fnd_blanco.color.a - setOutfnd, 0, 1));
            text1.color = new Color(text1.color.r, text1.color.g, text1.color.b, Mathf.Clamp(text1.color.a - setOutfnd, 0, 1));
        }

        if (Input.anyKey)
        {
            auxSetOut = true;
        }

        if (fnd_blanco.color.a == 0)
        {
            SceneManager.LoadScene("Creditos");
        }
    }
}
