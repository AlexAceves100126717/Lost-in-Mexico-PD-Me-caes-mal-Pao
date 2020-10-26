//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Libreria para cambio de escena
using UnityEngine.SceneManagement;


public class Memorama_Controlador : MonoBehaviour
{
    // a que nivel se quiere mandar
    public string nextLevel;

    // las tarjeta que se haran en y, x y su espaciio entre ellas
    public const int gridRows = 3;
    public const int gridCols = 4;
    public const float offsetX = 4f;
    public const float offsetY = 1f;

    //Para mandar la carta princpilas, poner mas cartas, y texto de ganar
    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField]
    private GameObject winTextM;
    public static bool youWinM;

    // Start is called before the first frame update
    private void Start()
    {
        // Se da valor al vector 3 y su posicion es igual a la carta original y su posicion
        Vector3 startPos = originalCard.transform.position;
        // Cuantas cartas se haran en mi caso son 6
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        // De acuerdo al numero de cartas y su par se pondrán aleatoriamente 
        numbers = ShuffleArray(numbers);
        /* Para i y j que i = gridCols y j = GridRows estos se sumaarán para poner las tarjetas en orden  */
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                /* Aqui se dice que las cartas se pondran a cierta distancia y que cuando se toque una se pondra una imagen*/
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);


                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetX * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
        // El texto esta apagado
        winTextM.SetActive(false);
        youWinM = false;

    }
    // La carta vuelve cuando es incorrecta la otra
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //Cuando la carta de atras se revela
    // Se voltea una carta, se voltea otra si son igual se quedan desvolteadas pero si no se voltaran oara que no se vea su imagen
    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    private int _score = 0;
    [SerializeField] private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;

        }

        else
        {

            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }
    //Si los pares son iguales por lo tanto las id se indentifican y se quedarán en su lugar mas que el score aumentará su valor
    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();

        }

        _firstRevealed = null;
        _secondRevealed = null;
        // Si score es 6 se pondra el texto de ganar al igual que en 1 seg se cambiará de escena ya que se invoca changescene 
        if (_score == 6)
        {
            Debug.Log("Ganasteeee");
            youWinM = true;
            winTextM.SetActive(true);
            if (youWinM && winTextM == true)
            {
                Invoke("ChangeScene", 1);


                }

        }
    }
    void ChangeScene ()
    {
        SceneManager.LoadScene(nextLevel);

    }
}


