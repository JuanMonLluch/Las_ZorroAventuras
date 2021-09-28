using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Limite_Script : MonoBehaviour
{

    public GameObject camera;

    public CamaraScript camScr;
    public BossScript bs;


    // Start is called before the first frame update
    void Start()
    {
        camScr = camera.GetComponent<CamaraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.05f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
        if (collision.gameObject.tag == "LimBoss")
        {
            camScr.movCam = false;
            bs.limDisp = true;
        }
    }
}
