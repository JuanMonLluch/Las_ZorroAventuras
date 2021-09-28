using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parallax_level : MonoBehaviour
{

    public Renderer[] BG_parralax;
    public Vector2[] aux_BG_parralax;

    public float[] velocidad;

    public bool aux_Parralax = true;

    public GameObject canvas_pause;
    public GameObject camera;
    private bool auxMovCam;
    private float tiempoTransSinPausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(aux_Parralax);
        auxMovCam = camera.GetComponent<CamaraScript>().movCam;
        if (auxMovCam == true && canvas_pause.activeSelf == false)
        {
            aux_Parralax = true;
            
        }
        else
        {
            aux_Parralax = false;
            
        }

        
        mueveBG();
    }

    private void mueveBG()
    {
        if (aux_Parralax == true)
        {

            /*for (int i = 0; i < BG_parralax.Length; i++)
            {
                aux_BG_parralax[i] = BG_parralax[i];
                BG_parralax[i] = aux_BG_parralax[i];
            }*/

            
            for (int i = 0; i < BG_parralax.Length; i++)
            {
                //BG_parralax[i].material.SetTextureOffset("_Maintex", aux_BG_parralax[i]);

                //float offset = Time.time * velocidad[i];

                //tiempoTransSinPausa = tiempoTransSinPausa + Time.deltaTime * velocidad[i];

                BG_parralax[i].material.SetTextureOffset("_MainTex", new Vector2(BG_parralax[i].material.mainTextureOffset.x + velocidad[i]*Time.deltaTime, 0.0f));
                Debug.Log(BG_parralax[0].material.mainTextureOffset);
                aux_BG_parralax[i] = BG_parralax[i].material.mainTextureOffset;
                
                //aux_BG_parralax[i].material.mainTextureOffset = BG_parralax[i].material.mainTextureOffset;
                //aux_BG_parralax[i].material.SetTextureOffset("_MainTex", BG_parralax[i].material.mainTextureOffset);
            }



        }
        else if (aux_Parralax == false)
        {
            for (int i = 0; i < BG_parralax.Length; i++)
            {
                //float offset = float.Parse(aux_BG_parralax[i].ToString());
                BG_parralax[i].material.SetTextureOffset("_MainTex", aux_BG_parralax[i]);
                
                Debug.Log(BG_parralax[0].material.mainTextureOffset);
                /*float offset = Time.time * velocidad[i] * 0;
                BG_parralax[i].material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));*/
            }
        }
        
    }
}
