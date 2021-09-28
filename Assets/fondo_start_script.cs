using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo_start_script : MonoBehaviour
{

    public MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshCollider.contactOffset = meshCollider.contactOffset + 1;

        if (gameObject.name == "FONDO1")
        {
            meshCollider.contactOffset = meshCollider.contactOffset + 1;
        }
    }
}
