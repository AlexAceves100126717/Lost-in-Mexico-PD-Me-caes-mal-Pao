//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnElSuelo : MonoBehaviour
{
    // Se trae al objeto padre 
    GameObject Inspector;
    // Start is called before the first frame update
    void Start()
    {
        //Aquui se dice que Insp es el padre del enelsuelo
        Inspector = gameObject.transform.parent.gameObject; 
    }

    // Update is called once per frame
    void Update()
    { }
    // Cuando enelsuelo coque con el tag piso este podra saltar, se manda al core_Inspector de que suelo es true y lo deja saltar
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Piso")
        {
            Inspector.GetComponent<Core_Inspector>().EnelPiso = true;
        }
    }
    // lo contrario si piso es falso del tag y no hay choque pues no podrá saltar hasta que sea true
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Piso")
        {
            Inspector.GetComponent<Core_Inspector>().EnelPiso = false;
        }
    }
}
