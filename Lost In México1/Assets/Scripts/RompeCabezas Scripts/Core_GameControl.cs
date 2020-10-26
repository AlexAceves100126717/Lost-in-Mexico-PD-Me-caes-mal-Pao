// Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cambio de escena libreria
using UnityEngine.SceneManagement;


public class Core_GameControl : MonoBehaviour
    
{
    // Se da de alta varuable donde se asignará la escena a donde se mandará
    public string nextLevel;
    // SerializeField es que puedas elegir el tamaño y respecto a ese tamaño podrás incluir mas o menos elementos, en este caso es de las piezas del puzzle
    [SerializeField]
    private Transform[] picture;

    // El texto que se pondrá cuando se complete el puzzle
    [SerializeField]
    private GameObject winText;

    //Un bool de ganar
    public static bool youWin;

    // Start is called before the first frame update
    void Start()
    {
        //Este hola se puede ignorar era pura prueba pero lo deje jeje
        Debug.Log("Hola");
        // Tanto el bool como el texto estarán en falso = descativados
        winText.SetActive(false);
        youWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Si todas las piezas están en el lugar que deben estar (Solo puse x para no hacer el código mas largo) Se activara lo siguiente
        if (picture[0].position.x == -7.421f &&
            picture[1].position.x == -6.295f &&
            picture[2].position.x == -5.092f &&
            picture[3].position.x == -3.866f &&
            picture[4].position.x == -2.735f &&
            picture[5].position.x == -7.421f &&
            picture[6].position.x == -6.299f &&
            picture[7].position.x == -5.102f &&
            picture[8].position.x == -3.866f &&
            picture[9].position.x == -2.738f &&
            picture[10].position.x == -7.421f &&
            picture[11].position.x == -6.298f &&
            picture[12].position.x == -5.108f &&
            picture[13].position.x == -3.876f &&
            picture[14].position.x == -2.746f &&
            picture[15].position.x == -7.421f &&
            picture[16].position.x == -6.299f &&
            picture[17].position.x == -5.106f &&
            picture[18].position.x == -3.877f &&
            picture[19].position.x == -2.748f )
        {

            //  Cuando todas las piezas  esten en su lugar el bool, el texto se harán visibles..
            youWin = true;
            winText.SetActive(true);
            //Se invoca un cambio de escena con el timepo de 1 segundo (Osea que cuando se active todo pasará 1 seg y se invocará changescene)
            Invoke("ChangeScene", 1);

        }
    }
    //Una variable para el cambio de escena
    void ChangeScene()
    {
        //Se cambia de escena de acuerdo a la escena que se ponga
        SceneManager.LoadScene(nextLevel);

    }
}
