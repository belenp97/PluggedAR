using UnityEngine;
using UnityEngine.UI;


public class activity2Manager : MonoBehaviour
{
    private int[,] respuesta;
    private int[,] solucion1= new int[,] { { 0, 1, 1, 1, 1 }, { 0, 1, 0, 0, 0 }, { 0, 1, 1, 1, 0 }, { 0, 1, 0, 0, 0 } };
    private int[,] solucion2 = new int[,] { { 0, 1, 1, 1, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 1, 1, 1, 1, 1 } };
    private int[,] solucion3 = new int[,] { { 1, 1, 0, 0, 1 }, { 1, 1, 1, 0, 1 }, { 1, 0, 1, 1, 1 }, { 1, 0, 0, 1, 1 } };
    private string cuboName;
    private bool[] correctos;

    public Button Verificacion, Siguiente;
    public Text mensaje, Enunciado;
    public GameObject panelFinal;
    public RawImage[] estrellasOn, estrellasOff;
    private int actividad_actual;

    // Start is called before the first frame update
    void Start()
    {
     /*Inicialización de las matrices soluciones y la matriz respuesta*/   
        respuesta = new int[,] { { 0,0,0,0,0} , { 0,0,0,0,0 }, { 0,0,0,0,0 }, { 0,0,0,0,0 } };
        correctos = new bool[3] { false, false, false };
        Verificacion.enabled = true;
        panelFinal.SetActive(false);
        actividad_actual = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //si hay más de un toque en la pantalla, y el toque de la pantalla acaba de comenzar.
        if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                cuboName = hit.transform.name;
                switch (cuboName)
                {
                    case "Cube11":
                        cambiarEstado(0, 0);
                        cambiarColor(0, 0, hit);
                        break;
                   case "Cube12":
                        cambiarEstado(0, 1);
                        cambiarColor(0, 1, hit); 
                        break;
                    case "Cube13":
                        cambiarEstado(0, 2);
                        cambiarColor(0, 2, hit);
                        break;
                    case "Cube14":
                        cambiarEstado(0, 3);
                        cambiarColor(0, 3, hit);
                        break;
                    case "Cube15":
                        cambiarEstado(0, 4);
                        cambiarColor(0, 4, hit);
                        break;
                    case "Cube21":
                        cambiarEstado(1, 0);
                        cambiarColor(1, 0, hit);
                        break;
                    case "Cube22":
                        cambiarEstado(1, 1);
                        cambiarColor(1, 1, hit);
                        break;
                    case "Cube23":
                        cambiarEstado(1, 2);
                        cambiarColor(1, 2, hit);
                        break;
                    case "Cube24":
                        cambiarEstado(1, 3);
                        cambiarColor(1, 3, hit);
                        break;
                    case "Cube25":
                        cambiarEstado(1, 4);
                        cambiarColor(1, 4, hit);
                        break;
                    case "Cube31":
                        cambiarEstado(2, 0);
                        cambiarColor(2, 0, hit);
                        break;
                    case "Cube32":
                        cambiarEstado(2, 1);
                        cambiarColor(2, 1, hit);
                        break;
                    case "Cube33":
                        cambiarEstado(2, 2);
                        cambiarColor(2, 2, hit);
                        break;
                    case "Cube34":
                        cambiarEstado(2, 3);
                        cambiarColor(2, 3, hit);
                        break;
                    case "Cube35":
                        cambiarEstado(2, 4);
                        cambiarColor(2, 4, hit);
                        break;
                    case "Cube41":
                        cambiarEstado(3, 0);
                        cambiarColor(3, 0, hit);
                        break;
                    case "Cube42":
                        cambiarEstado(3, 1);
                        cambiarColor(3, 1, hit);
                        break;
                    case "Cube43":
                        cambiarEstado(3, 2);
                        cambiarColor(3, 2, hit);
                        break;
                    case "Cube44":
                        cambiarEstado(3, 3);
                        cambiarColor(3, 3, hit);
                        break;
                    case "Cube45":
                        cambiarEstado(3, 4);
                        cambiarColor(3, 4, hit);
                        break;
                    default:
                        break;
                }
            }
        }

    }

    public int getEstado(int x, int y)
    {
        return respuesta[x, y];
    }

    public void cambiarEstado(int x, int y)
    {
        //Se cambia el estado de "pulsado" a "no pulsado" o viceversa.
        if (respuesta[x,y] == 0)
            respuesta[x,y] = 1;
        else
            respuesta[x,y] = 0;
    }

    public void cambiarColor(int x, int y, RaycastHit h)
    {
        if (getEstado(x, y) == 0)       //En caso de que el nuevo valor sea 0 = cambiar a blanco el color.
            h.collider.GetComponent<MeshRenderer>().material.color = Color.white;
        else            //Sino, será negro.
            h.collider.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    public bool corregirRespuesta(int[,] r, int num)
    {
        //array auxiliar donde vamos a guardar la solución correspondiente con la que comparar.
        int[,] s = new int[r.GetLength(0), r.GetLength(1)];
        bool encontrado = true;

        switch (num)
        {
            case 0:
                s = solucion1;
                break;
            case 1:
                s = solucion2;
                break;
            case 2:
                s = solucion3;
                break;
            default:
                break;
        }
        
        //Se comparan las dos matrices, y se comprueba que son iguales.
        for(int i = 0; i < r.GetLength(0); i++)
        {
            for(int j = 0; j < r.GetLength(1); j++)
            {
                //En el momento en que una casilla no corresponde, se finaliza el recorrido.
                if (r[i, j] != s[i, j])
                    encontrado=false;
            }
        }
        return encontrado;
    }

    public int[,] getRespuesta()
    {
        return respuesta;
    }

    public void clickSiguiente()
    {
        //Inicializamos las variables.
        respuesta = new int[,] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        actividad_actual = -1;
        panelFinal.SetActive(false);
    }

    public void clickResuelto()
    {
        FindObjectOfType<basicFunction>().ChangeGameRunningState();
        FindObjectOfType<basicFunction>().Final.SetActive(true);
        FindObjectOfType<basicFunction>().fondo.SetActive(true);
        int contador = 0;
        for (int i = 0; i < correctos.Length; i++)
        {
            if (correctos[i]) contador++;
        }

        int final = (int)((contador * 3) / 3);
        for (int i = 0; i < final; i++)
        {
            estrellasOff[i].gameObject.SetActive(false);
            estrellasOn[i].gameObject.SetActive(true);
        }
    }

    public void setActividad(int nuevoValor)
    {
        this.actividad_actual = nuevoValor;
    }

    public void setCorrecto(int actividad)
    {
        correctos[actividad] = true;
    }


    public void VerificacionOnClick()
    {
        //obtenemos la respuesta final y la comprobamos.
        if (actividad_actual != -1)
         {
             int[,] r = getRespuesta();
            bool resul = this.corregirRespuesta(r, actividad_actual);

             if (resul)
             {
                 mensaje.text = "ENHORABUENA";
                 this.setCorrecto(actividad_actual);
             }
             else  mensaje.text = "PRUEBA OTRA VEZ";

             panelFinal.SetActive(true);
         }


    }

}
