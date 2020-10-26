//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core_llorona : MonoBehaviour
{
    //Se da una velocidad al personaje, pero esta es modificable
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            //Esto sirve ppara que el objeto no desaparezca aunque no este en camara, pero cuando este en camara visible o antes se moverá.
            
        }
    }
}
