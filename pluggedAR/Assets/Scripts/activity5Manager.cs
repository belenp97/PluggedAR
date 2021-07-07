using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activity5Manager : MonoBehaviour
{
    public GameObject[] soluciones;
    public Image fondo;
    public Button cerrar;
    public GameObject panel;
    
    private int num_laberinto;


    // Start is called before the first frame update
    void Start()
    {
        this.num_laberinto = 0;
        panel.SetActive(false);
        fondo.gameObject.SetActive(false);
        cerrar.gameObject.SetActive(false);
        for(int i=0;i<soluciones.Length;i++)
            soluciones[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickSolucion()
    {
        fondo.gameObject.SetActive(true);
        panel.SetActive(true);
        cerrar.gameObject.SetActive(true);

        soluciones[0].SetActive(true); 
        soluciones[1].SetActive(false);
                
    }
    public void clickSolucion2()
    {
        fondo.gameObject.SetActive(true);
        panel.SetActive(true);
        cerrar.gameObject.SetActive(true);

        soluciones[0].SetActive(false);
        soluciones[1].SetActive(true);

    }
    public void setNumLaberinto(int num)
    {
        this.num_laberinto = num;
    }

    public void clickCerrar()
    {
        fondo.gameObject.SetActive(false);
        cerrar.gameObject.SetActive(false);
        panel.SetActive(false);
        for(int i=0;i<soluciones.Length;i++)
            soluciones[i].SetActive(false);

    }
}
