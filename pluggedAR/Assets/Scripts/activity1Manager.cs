using UnityEngine;
using UnityEngine.UI;

/***********    Este script trata las acciones realizadas durante el ejercicio de números binarios 
                las distintas respuestas y sus repercusiones en los elementos UI                      *************/

public class activity1Manager : MonoBehaviour
{
    public GameObject[] textoCorrecto, textoIncorrecto;
    public Text enunciado;
    public RawImage pregunta;
    public RawImage[] estrellasOn, estrellasOff;
    public Texture[] Impreguntas;

    private int numero_actividad, numero_pregunta;
    private int[] valoresEnunciado = {25, 16, 2, 31 };
    private bool[] correctos;


    // Start is called before the first frame update
    void Start()
    {
       
        numero_actividad = 0;
        numero_pregunta = 0;
        enunciado.text = valoresEnunciado[numero_actividad].ToString();
        pregunta.texture = Impreguntas[numero_pregunta];
        correctos = new bool[3] { false, false, false };
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int getNumeroActividad()
    {
        return numero_actividad;
    }

    public void setNumeroActividad(int nuevoValor)
    {
        this.numero_actividad = nuevoValor;
    }
    
    public void clickNext()
    {
        if (numero_actividad <= 2)
        {
            numero_actividad++;
            numero_pregunta++;
            enunciado.text = valoresEnunciado[numero_actividad].ToString();
            pregunta.texture = Impreguntas[numero_pregunta];
            FindObjectOfType<basicFunction>().Next.interactable =false;
        }
        else
        {
            FindObjectOfType<basicFunction>().ChangeGameRunningState();
            FindObjectOfType<basicFunction>().Final.SetActive(true);
            FindObjectOfType<basicFunction>().fondo.SetActive(true);
            int contador = 0;
            for(int i = 0; i < correctos.Length; i++)
            {
                if (correctos[i]) contador++;
            }

            int final = (int)((contador * 3) / valoresEnunciado.Length);
            for(int i = 0; i < final; i++)
            {
                estrellasOff[i].gameObject.SetActive(false);
                estrellasOn[i].gameObject.SetActive(true);
            }
        }
    }

    public void setCorrecto(int actividad)
     {
        correctos[actividad] = true;
    }

    public bool getCorrecto(int actividad)
    {
        return correctos[actividad];
    }
}

