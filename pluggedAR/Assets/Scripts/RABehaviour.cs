using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

/***********    Este script trata las acciones realizadas durante el ejercicio de números binarios 
                las distintas respuestas y sus repercusiones en los elementos RA                      *************/

public class RABehaviour : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    private Button Next2, verificar2;
    private Text enunciado;
    private GameObject[] resultadoC, resultadoI;
    private int num_actividad;
    private string enunciado1 = "INCÓGNITA 1:\n(1,4)\n\n(1,1,3)\n\n(1,3,1)\n\n(1,1,3)";
    private string enunciado2 = "INCÓGNITA 2:\n(1,3,1)\n\n(2,1,2)\n\n(2,1,2)\n\n(0,5)";
    private string enunciado3 = "INCÓGNITA 3:\n(0,2,2,1)\n\n(0,3,1,1)\n\n(0,1,1,3)\n\n(0,1,2,2)";


    // Start is called before the first frame update
    void Start()
    { 


        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
           OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
            newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            OnTrackingLost();
        }
    }

    protected virtual void OnTrackingFound()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
        }

        /***********    Selección ctividades   ***********/
        if (SceneManager.GetActiveScene().name == "Actividad1")
        {
            Actividad1Behaviour();
        }
        else if(SceneManager.GetActiveScene().name == "Actividad2")
        {
            Actividad2Behaviour();
        }
        else if (SceneManager.GetActiveScene().name == "Actividad3")
        {
            Actividad3Behaviour();
        }
        else if (SceneManager.GetActiveScene().name == "Actividad4")
        {
            Actividad4Behaviour();
        }
        else if(SceneManager.GetActiveScene().name == "Actividad5")
        {
            Actividad5Behaviour();
        }
    }

    protected virtual void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }
    }


    /***********    Actividad 1    ***********/
    private void Actividad1Behaviour()
    {
        Next2 = FindObjectOfType<basicFunction>().Next;
        resultadoC = FindObjectOfType<activity1Manager>().textoCorrecto;
        resultadoI = FindObjectOfType<activity1Manager>().textoIncorrecto;
        num_actividad = FindObjectOfType<activity1Manager>().getNumeroActividad();
        int num_tarjeta;

        if (mTrackableBehaviour.Trackable.Name.Equals("bombillaOn"))            num_tarjeta = 0;
        else            num_tarjeta = 1;

        Debug.Log("N U M E R O   A C T I V I D A D:  " + num_actividad);
        if (((mTrackableBehaviour.Trackable.Name.Equals("bombillaOn")) && (num_actividad == 1 || num_actividad == 3)) || ((mTrackableBehaviour.Trackable.Name.Equals("bombillaOff")) && (num_actividad == 0 || num_actividad == 2)))
        {
            /*Mostrar acierto y sumar puntos*/
            Next2.interactable = true;
            resultadoC[num_tarjeta].SetActive(true);
            resultadoI[num_tarjeta].SetActive(false);
            FindObjectOfType<activity1Manager>().setCorrecto(num_actividad);
        }
        else
        {   
            //se elige mal la respuesta, tanto para bombilla_encendida como para bombilla_apagada.
            resultadoC[num_tarjeta].SetActive(false);
            resultadoI[num_tarjeta].SetActive(true);
        }
    }

    /***********    Actividad 2    ***********/
    private void Actividad2Behaviour()
    {
        enunciado = FindObjectOfType<activity2Manager>().Enunciado;

        if (mTrackableBehaviour.Trackable.Name.Equals("Desconocida_1")){
            setEnunciado(0);
            FindObjectOfType<activity2Manager>().setActividad(0);
        }
        if (mTrackableBehaviour.Trackable.Name.Equals("Desconocida_2"))
        {
            setEnunciado(1);
            FindObjectOfType<activity2Manager>().setActividad(1);
        }
        if (mTrackableBehaviour.Trackable.Name.Equals("Desconocida_3"))
        {
            setEnunciado(2);
            FindObjectOfType<activity2Manager>().setActividad(2);
        }
    }

    /***********    Actividad 3    ***********/
    private void Actividad3Behaviour(){ }

    /***********    Actividad 4    ***********/
    private void Actividad4Behaviour() { }

    /***********    Actividad 5    ***********/
    private void Actividad5Behaviour() {

        if (mTrackableBehaviour.Trackable.Name.Equals("7_5_maze"))
        {
            FindObjectOfType<activity5Manager>().setNumLaberinto(1);
        }
        else
        {
            FindObjectOfType<activity5Manager>().setNumLaberinto(2);
        }

    }


    //Funciones auxiliares.
    public void setEnunciado(int num)
    { 
        if(num  ==  0)
                enunciado.text = enunciado1;
        if(num  ==  1)
                enunciado.text = enunciado2;
        if(num  ==  2)
                enunciado.text = enunciado3;

    }
}
