using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class basicFunction : MonoBehaviour
{
    public Button botonPausa, Next, ayudaSiguiente, ayudaAnterior;
    public GameObject Pausado, fondo, Ayuda, Final;
    public GameObject[] ayudas;
    public int actividad;

    private bool gameRunning;
    private static readonly string nivel = "Nivel";
    private static readonly string vibracion = "Vibracion";
    private int ayuda_actual;


    // Start is called before the first frame update
    void Start()
    {
        botonPausa.gameObject.SetActive(true);
        Pausado.SetActive(false);
        Ayuda.SetActive(false);
        fondo.SetActive(false);
        Final.SetActive(false);
        if (actividad == 1)        Next.interactable = false;
        if (actividad == 4 || actividad == 2 || actividad == 5) Next.gameObject.SetActive(false);  
        gameRunning = true;
        ayuda_actual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }


    public void clickSalir()
    {
        if(actividad == 1)        PlayerPrefs.SetInt(nivel,1);
        else if(actividad == 2 || actividad == 3 || actividad == 4) PlayerPrefs.SetInt(nivel, 2);
        else PlayerPrefs.SetInt(nivel, 3);
        sceneLoad(0);
    }

    public void clickPausa()
    {
        Pausado.SetActive(true);
        fondo.SetActive(true);
        ChangeGameRunningState();
    }

    public void clickAyuda()
    {
        Ayuda.SetActive(true);
        Pausado.SetActive(false);
        ayudaSiguiente.gameObject.SetActive(true);
        ayudaAnterior.gameObject.SetActive(false);
        ayudas[0].SetActive(true);
        for(int i = 1; i < ayudas.Length; i++)
        {
            ayudas[i].SetActive(false);
        }
        ayuda_actual++;
    }

    public void clickAtras()
    {
        ayuda_actual = 0;
        Pausado.SetActive(true);
        Ayuda.SetActive(false);
    }

    public void ChangeGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            //juego activo.
            Debug.Log("Juego corriendo");
            botonPausa.interactable = true;
            bool correcto = FindObjectOfType<activity1Manager>().getCorrecto(FindObjectOfType<activity1Manager>().getNumeroActividad());
            if (actividad != 1 || ((actividad == 1) && correcto)) Next.interactable = true;
            Time.timeScale = 1f;

        }
        else
        {
            //juego pausado.
            Debug.Log("Juego pausado");
            botonPausa.interactable = false;
            Next.interactable = false;
            Time.timeScale = 0f;
        }

    }

    public void clickContinuar()
    {
        Pausado.gameObject.SetActive(false);
        fondo.SetActive(false);
        ChangeGameRunningState();
    }

    public void clickReiniciar()
    {
        sceneLoad(actividad);
    }

    public void sceneLoad(int levelACargar)
    {
        SceneManager.LoadScene(levelACargar);
    }

    public void VibracionButton()
    {
        //si es 1: vibracion activada, sino 0: desactivada
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
        ayudas[ayuda_actual-1].SetActive(false);
        ayudas[(ayuda_actual - 1) -1].SetActive(true);
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
