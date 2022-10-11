using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float limiteX = 10;
    public float limiteY = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > limiteY)
        {
            transform.position = new Vector3(transform.position.x, -limiteY);  /*para el teletransporte creamos un nuevo Vector3 y le decimos que la posicion X la mantenemos y como estamos trabajando con el eje Y le añadimos el nuevo valor lo mismo con el limite de abajo que pasa de negativo a positivo*/
         
        }
        if (transform.position.y < -limiteY)
        {
            transform.position = new Vector3(transform.position.x, limiteY);
        }

        if (transform.position.x > limiteX)
        {
            transform.position = new Vector3(-limiteX, transform.position.y);
        }

        if (transform.position.x < -limiteX)
        {
            transform.position = new Vector3(limiteX, transform.position.y);
        }
    }
}
