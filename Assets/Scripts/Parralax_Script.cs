using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax_Script : MonoBehaviour
{
    public Renderer[] BG_arboles;
    public float[] velocidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mueveBG();    
    }

    private void mueveBG()
    {
        for (int i = 0; i < BG_arboles.Length; i++)
        {
            float offset = Time.time * velocidad[i];
            BG_arboles[i].material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
        }
    }
}
