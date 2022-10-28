using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int municion;
    public int vida;
    public int puntuacion;
    public List<GameObject> listaBalas;
    public int municionInicial;
    public int vidaInicial;
    public GameObject player;
    public GameObject gestorasteroides;
    public GameObject gestorasteroidesoriginal;


    public void Start()
    {
        gestorasteroides = Instantiate(gestorasteroidesoriginal, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    private void Awake() 
    {
        instance = this;
        puntuacion = 0;
        listaBalas = new List<GameObject>();    
    }
    public void Update()
    {
        if (vida <= 0) 
        
        {
            gestorasteroides.GetComponent<AsteroidManager>().limpiar = true;
        
        }
    }
    public bool ComprobarBalasMoviendose() 
    {
    return listaBalas.Count > 0;
    }
  
    public void reiniciar()
    {
        municion = municionInicial;
        vida = vidaInicial;
        puntuacion = 0;
        Destroy(gestorasteroides);
        gestorasteroides = Instantiate(gestorasteroidesoriginal, new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0)));
        player.GetComponent<PlayerMovement>().restart();
    
    }
}
