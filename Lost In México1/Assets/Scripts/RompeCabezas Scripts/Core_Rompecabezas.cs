//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//Cambiar de nivel libreria
using UnityEngine.SceneManagement;

public class Core_Rompecabezas : MonoBehaviour
{
    // Declarar objeto para en el juego de pieza selecionada
    public GameObject SelectedPiece;
    //Espacio de piezas, no se amontonen

    int espacio = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Si el mouse se presiona en una pieza que tenga el Tag "Puzzle" este activara el Ray cast este RayCast lo que hace es que se activa cuando toca el objeto deseado y lo puede mover de un lugar a otro..
         * Tambien agregamos espacio o que no se amontonen las piezas
         */
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<Core_Piezas>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<Core_Piezas>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = espacio;
                    espacio++;
                }
            }


        }
        /*Aqui decimos que si el mouse ya no esta presionado no seguírá arrastrando la pieza y se soltará donde se dejó.
         * Tambien decimos que se respeten las coordenadas de donde esta el mouse para que se vean las piezas ya que luego no se veía entonces damos el valor de x y x con respecto al mouse y z lo dejamos en 0 siempre.
         * 
         */
        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<Core_Piezas>().Selected = false;
                SelectedPiece = null;
            }
        }
        if (SelectedPiece != null) {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
                }

    }
 
}
