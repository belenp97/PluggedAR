using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public GameObject suelo, puntoPartida;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Si la esfera se saliera del plano, devolvería la esfera al punto de partida para empezar de nuevo.
        if (transform.position.y < suelo.transform.position.y - 10)
        {
            transform.position = puntoPartida.transform.position;
        }
    }
}
