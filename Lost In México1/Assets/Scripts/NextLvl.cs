//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Libreria para cambio de escena
using UnityEngine.SceneManagement;


public class NextLvl : MonoBehaviour
{
    // Se da de alta para poner en el juego a que escena se irá
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Cuando choca o toca (Entra en colision) Se cambiará de escena a la que se puso en el juego
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(nextLevel);
    }
}
