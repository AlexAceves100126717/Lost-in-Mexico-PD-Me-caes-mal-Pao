//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camara : MonoBehaviour
{
    // Se declara variable de jugador y transformador, con offset
    private Transform playerTransform;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        // La camará estara buscando siempre donde esta el jugador con el tag "Player"
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    //LateUpdate se usa porque es  mas preciso que Update solo, este se estará checando y confirmando a cada rato
    void LateUpdate()
    {
        //Aqui lo que dice es que siempre estara enfocado al jugador con tanto de offset y si este se mueve  pues la camara lo sigue
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        transform.position = temp;
        temp.x += offset;
    }
}
