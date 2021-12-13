using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits_Script : MonoBehaviour
{

    public Text creditos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creditos.transform.Translate(new Vector3(0, 2 * Time.deltaTime));
        StartCoroutine(Fin());
    }

    IEnumerator Fin()
    {
        yield return new WaitForSeconds(24);
        SceneManager.LoadScene("Start_Menu");
    }
}
