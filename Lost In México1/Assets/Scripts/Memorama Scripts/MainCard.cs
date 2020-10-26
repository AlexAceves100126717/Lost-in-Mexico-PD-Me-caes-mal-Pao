//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    //Para poner el controlador del juego
    [SerializeField]
    private Memorama_Controlador controller;

    //Para poner la carta de atras y se duplique
    [SerializeField]
    private GameObject Carta_Atras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // cuando se presiona el mouse en una carta esta se revelará
    public void OnMouseDown()
    {
        if (Carta_Atras.activeSelf && controller.canReveal)
        {
            Carta_Atras.SetActive(false);
            controller.CardRevealed(this);
        }
    }
    // Se da de alta la variable id para las cartas
    private int _id;
    public int id
    {
        //Si no es la misma id se regresa a carta atras
        get { return _id; }
    }
    // Se muestra la imagen de la carta y se comparan ids
    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    // No se revelará cuando carta atras este activa y sea verdadera
    public void Unreveal()
    {
        Carta_Atras.SetActive(true);
    }
}
