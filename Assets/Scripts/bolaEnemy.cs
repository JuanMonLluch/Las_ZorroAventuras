using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaEnemy : MonoBehaviour
{

    public GameObject pj;

    public int velBola = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -velBola * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
    }
}
