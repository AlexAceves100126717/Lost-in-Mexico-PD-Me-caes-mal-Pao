//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Biblioteca de Next Level
using UnityEngine.SceneManagement;


public class Core_Inspector : MonoBehaviour
{
    //Velocidad del inspector
    public float movVel = 0.01f;
    //Piso para 1 salto
    public bool EnelPiso = false;
    //Para hacer animaciones
    private Animator anima;
    //Para elegir el siguiente nivel
    public string nextLevel;
    //Se declara la vida y su valor de 100%
    private int Vida = 100;

    // Start is called before the first frame update
    void Start()
    {
        // Se pone al principio para usar las anim

        anima = GetComponent<Animator>();
        //Seleciona vida pero no creo que se ocupe pero se deja por si acaso jaja
        Debug.Log("Tu vida es: "); Debug.Log(Vida);
    }

    // Update is called once per frame
    void Update()
    {
        //Si en el piso es falso se hara la anim de saltar
        if (EnelPiso == false)

        {
            anima.SetBool("Piso", false);
        }
        //Condicion donde piso es true y el bool sera true

        if (EnelPiso == true)
        {
            anima.SetBool("Piso", true);
        }
        // Esto es para el movimiento y que sea de acuerdo con el timpo real o lo mas parecido
        Salto();
        Vector3 movimiento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimiento * Time.deltaTime * movVel;

        //Girar dependiendo dirección
        
        Vector3 characterScale = transform.localScale;
        //Si se mueve al otro lado la escala se mueve igual al igual que la anim asignada que en este caso es la de caminar
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1f;
            anima.SetFloat("Velocidad", 1f);

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1f;
            anima.SetFloat("Velocidad", 1f);

        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            //Se quitara la anim de Correr y se pondra la de idle
            anima.SetFloat("Velocidad", 0f);
        }

        transform.localScale = characterScale;
    }

  
        // Si se presiona salto y enelpiso es verdadero saltara
    void Salto() {
        if (Input.GetButtonDown("Jump") && EnelPiso == true)
        {
            //Para que el personaje salto y se de un impulso
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0f,5f),ForceMode2D.Impulse);
        }
    
    }
    // Colisiones con tag
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si se toca al tag mariachi se ira al siguiente lvl
        if (collision.collider.tag == "Mariachi")
        {
            SceneManager.LoadScene(nextLevel);

        }
        // Si toca el pelaje este dira que agarro pieza de rompecabeza en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego
        if (collision.collider.tag == "Pieza")
        {
            Debug.Log("Agarraste pieza de rompecabezas");
            Destroy(collision.gameObject);
        }

        // Si toca el pelaje este dira que agarro pelaje en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego
        if (collision.collider.tag == "Pelaje")
        {
            Debug.Log("Agarraste Pelaje");
                Destroy(collision.gameObject);
        }
        // Si toca el pelaje este dira que agarro uñas en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego

        if (collision.collider.tag == "Uñas")
        {
            Debug.Log("Agarraste Uñas");
            Destroy(collision.gameObject);
        }
        // Si toca el pelaje este dira que agarro sombrero en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego

        if (collision.collider.tag == "Sombrero")
        {
            Debug.Log("Agarraste Sombrero");
            Destroy(collision.gameObject);
        }
        // Si toca el pelaje este dira que agarro monedas en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego

        if (collision.collider.tag == "Monedas")
        {
            Debug.Log("Agarraste Monedas");
            Destroy(collision.gameObject);
        }
        // Si toca el pelaje este dira que agarro foto de niña en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego

        if (collision.collider.tag == "Niña")
        {
            Debug.Log("Agarraste Foto de niña");
            Destroy(collision.gameObject);
        }
        // Si toca el pelaje este dira que agarro foto de inspector en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego

        if (collision.collider.tag == "Insp")
        {
            Debug.Log("Agarraste foto tuya");
            Destroy(collision.gameObject);
        }
        // Si toca el pelaje este dira que agarro foto de mariachi en la consola  y se destruirá para que no se pueda agarrar más veces, prox en hub del juego

        if (collision.collider.tag == "Mariachi_foto")
        {
            Debug.Log("Agarraste foto de mariachi");
            Destroy(collision.gameObject);
        }

    }
}
