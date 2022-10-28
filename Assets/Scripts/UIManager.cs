using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI municion;
    public TextMeshProUGUI vidas;
    public GameObject pantallagameover;
    public Button reintentar;
    public TextMeshProUGUI puntuacionfinal;

    // Start is called before the first frame update
    void Start()
    {
       
    }
     

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.vida > 0)
        {
            tiempo.text = Time.time.ToString("00.00");
            puntuacion.text = GameManager.instance.puntuacion.ToString("00000000");
            municion.text = GameManager.instance.municion.ToString("00");
            
        } 
        else 
        {
            pantallagameover.SetActive(true);
            puntuacionfinal.text = GameManager.instance.puntuacion.ToString("00000000");
        
        }

        vidas.text = GameManager.instance.vida.ToString("0");

    }

    public void onclick() 
    {
        GameManager.instance.reiniciar();
        pantallagameover.SetActive(false);

    }
   
}
