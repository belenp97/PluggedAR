using System;
using UnityEngine;
using UnityEngine.UI;

public struct Order
{
    public bool pepperoni;
    public bool pineapple;
    public bool mushroom;

    public static implicit operator Order(bool v)
    {
        throw new NotImplementedException();
    }
}

public class activity3Manager : MonoBehaviour
{
    public GameObject pizza, pepperoni, mushroom, pineapple;
    public Button activarPe, activarM, activarPi;
    public Text Texto, error;
    public RawImage[] estrellasOn, estrellasOff;

    private int num_pedido = 0;
    private Order[] pedidos = new Order[3];
    private string[] TextoPedidos = new string[3]; 
    private bool[] correctos;

    // Start is called before the first frame update
    void Start()
    {
        pepperoni.SetActive(false);
        mushroom.SetActive(false);
        pineapple.SetActive(false);
        error.gameObject.SetActive(false);
        correctos = new bool[3] { false, false, false };

        for (int i = 0; i < 3; i++)
        {
            pedidos[i].pepperoni = UnityEngine.Random.value >= 0.5;
            pedidos[i].pineapple = UnityEngine.Random.value >= 0.5;
            pedidos[i].mushroom = UnityEngine.Random.value >= 0.5;
            string texto="";

            if (!pedidos[i].pepperoni && !pedidos[i].pineapple && !pedidos[i].mushroom) texto = "No añadir ningún ingrediente.";
            else
            {
                if (pedidos[i].pepperoni) texto = texto + "Añadir pepperoni.\n";
                if (pedidos[i].pineapple) texto = texto + "Añadir piña.\n";
                if (pedidos[i].mushroom) texto = texto + "Añadir setas.\n";
            }

            TextoPedidos[i] = texto;
        }

        FindObjectOfType<basicFunction>().Next.gameObject.SetActive(true);
        Texto.text = TextoPedidos[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickPepperoni(){
        if (pepperoni.activeSelf) pepperoni.SetActive(false);
        else pepperoni.SetActive(true);
    }

    public void clickMushroom() {
        if (mushroom.activeSelf) mushroom.SetActive(false);
        else mushroom.SetActive(true);
    }

    public void clickPineapple() {
        if (pineapple.activeSelf) pineapple.SetActive(false);
        else pineapple.SetActive(true);
    }

    public void clickNext()
    {
        
        if (pedidos[num_pedido].pepperoni != pepperoni.activeSelf || pedidos[num_pedido].pineapple != pineapple.activeSelf || pedidos[num_pedido].mushroom != mushroom.activeSelf)
        {
            error.gameObject.SetActive(true);
        }
        else
        {
            setCorrecto(num_pedido);
            num_pedido++;
            if (num_pedido >= 3)
            {
                FindObjectOfType<basicFunction>().ChangeGameRunningState();
                FindObjectOfType<basicFunction>().Final.SetActive(true);
                FindObjectOfType<basicFunction>().fondo.SetActive(true);
                int contador = 0;
                for (int i = 0; i < correctos.Length; i++)
                {
                    if (correctos[i]) contador++;
                }

                int final = (int)((contador * 3) / pedidos.Length);
                for (int i = 0; i < final; i++)
                {
                    estrellasOff[i].gameObject.SetActive(false);
                    estrellasOn[i].gameObject.SetActive(true);
                }
            }
            else
            {
                pepperoni.SetActive(false);
                pineapple.SetActive(false);
                mushroom.SetActive(false);
                error.gameObject.SetActive(false);
                Texto.text = TextoPedidos[num_pedido];
            }
        }
    }

    public void setCorrecto(int actividad)
    {
        correctos[actividad] = true;
    }
}
