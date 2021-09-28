using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_pj_startmenu : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Corriendo", true);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2(2 * Time.deltaTime,0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Limite")
        {
            transform.position = new Vector2(-12, transform.position.y);
        }
    }
}
