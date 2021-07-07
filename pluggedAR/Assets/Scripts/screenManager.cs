using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/***********    Este script trata el flujo entre las diferentes activities, así como sus elementos UI    *************/

public class screenManager : MonoBehaviour
{
    public GameObject menuPrincipal, Niveles, Ayuda, Config, Actividades, act1, act2, act3;
    public GameObject[] ayudas;
    public Button vibracionOn, vibracionOff, ayudaSiguiente, ayudaAnterior;

    private int ayuda_actual;
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string nivel = "Nivel";
    private static readonly string vibracion = "Vibracion";
    private int firstPlayInt;


    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            menuPrincipal.SetActive(true);
            Niveles.SetActive(false);
            Ayuda.SetActive(false);
            Config.SetActive(false);
            Actividades.SetActive(false);
            act1.SetActive(false);
            act2.SetActive(false);
            act3.SetActive(false);
            vibracionOn.gameObject.SetActive(true);
            vibracionOff.gameObject.SetActive(false);
            PlayerPrefs.SetInt(FirstPlay, 1);
            PlayerPrefs.SetInt(vibracion, 0);
            PlayerPrefs.SetInt(nivel, 0);
        }
        else
        {
            if (PlayerPrefs.GetInt(nivel) > 0)
            {
                menuPrincipal.SetActive(false);
                Ayuda.SetActive(false);
                Config.SetActive(false);
                onClickNivel(PlayerPrefs.GetInt(nivel));
            }
            else
            {
                menuPrincipal.SetActive(true);
                Niveles.SetActive(false);
                Ayuda.SetActive(false);
                Config.SetActive(false);
                Actividades.SetActive(false);
                act1.SetActive(false);
                act2.SetActive(false);
                act3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(vibracion) == 0)
            {
                vibracionOn.gameObject.SetActive(true);
                vibracionOff.gameObject.SetActive(false);
            }
            else
            {
                vibracionOn.gameObject.SetActive(false);
                vibracionOff.gameObject.SetActive(true);
            }

        }

        ayuda_actual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }
    }

    //Acción según qué botón se cliquea.

    public void onClickSalir()
    {
        PlayerPrefs.SetInt(FirstPlay, 0);
        PlayerPrefs.SetInt(vibracion, 0);
        PlayerPrefs.SetInt(nivel, 0);
        Application.Quit();

    }

    public void onClickPlay()
    {
        menuPrincipal.SetActive(false);
        Niveles.SetActive(true);
    }

    public void onClickAyuda()
    {
        menuPrincipal.SetActive(false);
        Ayuda.SetActive(true);
        ayudaSiguiente.gameObject.SetActive(true);
        ayudaAnterior.gameObject.SetActive(false);
        ayudas[0].SetActive(true);
        for (int i = 1; i < ayudas.Length; i++)
        {
            ayudas[i].SetActive(false);
        }
        ayuda_actual++;
    }

    public void onClickConfig()
    {
        menuPrincipal.SetActive(false);
        Config.SetActive(true);
    }

    public void onClickNivel(int nivel_elegido)
    {

        Niveles.SetActive(false);
        Actividades.SetActive(true);

        switch (nivel_elegido)
        {
            case 1:
                act1.SetActive(true);
                act2.SetActive(false);
                act3.SetActive(false);
                break;
            case 2:
                act1.SetActive(false);
                act2.SetActive(true);
                act3.SetActive(false);
                break;
            case 3:
                act1.SetActive(false);
                act2.SetActive(false);
                act3.SetActive(true);
                break;
            default:
                break;
        }
    }

    //Ir marcha atrás
    public void marchaAtras(GameObject actual)
    {
        if(actual == Niveles)
        {
            Niveles.SetActive(false);
            menuPrincipal.SetActive(true);
        }
        else if(actual == Config)
        {
            Config.SetActive(false);
            menuPrincipal.SetActive(true);
        }
        else if(actual == Ayuda)
        {
            ayuda_actual = 0;
            Ayuda.SetActive(false);
            menuPrincipal.SetActive(true);
        }
        else if(actual == Actividades)
        {
            act1.SetActive(false);
            act2.SetActive(false);
            act3.SetActive(false);
            Actividades.SetActive(false);
            Niveles.SetActive(true);
        }
    }

    public void selectActivity(int actividad)           //1: num binarios, 2: representacion, 3: leng. programacion, 4: grafos, 5: arboles.
    {
      
        switch (actividad)
        {
            case 1: 
                loadLevel(1);
                break;
            case 2:
                loadLevel(2);
                break;
            case 3:
                loadLevel(3);
                break;
            case 4:
                loadLevel(4);
                break;
            case 5:
                loadLevel(5);
                break;
            default:
                break;
        }
    }

    //Cargar escena de juego
    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void onClickVibracion()
    {
        if (PlayerPrefs.GetInt(vibracion) == 0)
        {
            PlayerPrefs.SetInt(vibracion, 1);
            vibracionOn.gameObject.SetActive(false);
            vibracionOff.gameObject.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt(vibracion, 0);
            vibracionOn.gameObject.SetActive(true);
            vibracionOff.gameObject.SetActive(false);
        }
    }

    public void VibracionButton()
     {
        //si es 0: vibracion activada, si 1: desactivada
         if (PlayerPrefs.GetInt(vibracion) == 0)
        {
            Handheld.Vibrate();
        }
     }

    public void clickAyudaSiguiente()
    {
        ayudas[ayuda_actual - 1].SetActive(false);
        ayudas[ayuda_actual].SetActive(true);
        ayuda_actual++;

        if (ayuda_actual != 1)
        {
            ayudaAnterior.gameObject.SetActive(true);
        }

        if (ayuda_actual == ayudas.Length)
        {
            ayudaSiguiente.gameObject.SetActive(false);
        }
    }

    public void clickAyudaAnterior()
    {
        ayudas[ayuda_actual - 1].SetActive(false);
        ayudas[(ayuda_actual - 1) - 1].SetActive(true);
        ayuda_actual--;

        if (ayuda_actual != ayudas.Length)
        {
            ayudaSiguiente.gameObject.SetActive(true);
        }


        if (ayuda_actual == 1)
        {
            ayudaAnterior.gameObject.SetActive(false);
        }
    }
}