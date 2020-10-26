// Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Libreria para usar piezas como SortingGroup
using UnityEngine.Rendering;
// Libreria de Siguiente nivel
using UnityEngine.SceneManagement;

public class Core_Piezas : MonoBehaviour
{
    /* Se da de alta los siguiente valores: 
     En posicion correcta, selecionado y vector 3 con valor de posicion correcta*/
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    // Start is called before the first frame update
    void Start()
    {
        // Posición correcta es igual a donde esta en el principio
        RightPosition = transform.position;
        // Las piezas se moveran aleatoriamente en el rango asignado para que no salgan fuera de cámara
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(2.8f, -1));
    }

    // Update is called once per frame
    void Update()
    {
        /* Si el vector3 esta en la posicion correcta menor a 0.5  esta se quedará ahi y ya no se podrá mover,
         Sin embargo si esta no esta en su lugar correcto se puede seguir moviendo*/
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }
    // Variable de cuando se completa el puzzle, si estan todas las piezas en su lugar Dira "Victoria"
    public void PuzzleComplete()
    {
        if (InRightPosition == true)
        {
            Debug.Log("Victoria");
        }
    }
}
