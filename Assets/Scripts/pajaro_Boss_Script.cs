using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pajaro_Boss_Script : MonoBehaviour
{

    public int vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-vel * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Terreno")
        {
            Destroy(gameObject);
        }
        
    }
}
