using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int asteroides_min = 2;
    public int asteroides_max = 8;
    public float limitX = 10;
    public float limitY = 6;
    public GameObject asteroide;  //Gameobject es un objeto generico pero arrastraremos el prefab que acabamos de crear
    // Start is called before the first frame update
    void Start()
    {
        int asteroides = Random.Range (asteroides_min, asteroides_max);

        for (int i = 0; i < asteroides; i++)  // for es un bucle y se ejecuta tantas veces como le digamos en este caso el length son los asteroides escribo for y doble tabulacion y escribe todo
        {
        Debug.Log("Instanciando asteroide: " + i);
        Vector3 posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
        Vector3 rotacion = new Vector3(0,0,Random.Range(0f,360f)); // la rotacion 2d le damos a la Z un numero aleatorio entre el0 y el 360
        GameObject temp = Instantiate(asteroide, posicion, Quaternion.Euler(rotacion));  //Instantiate spawnea objetos, lo clona / el Euler son los 360 grados y le pasamos al quaternion la rotacion aleatoria que hemos puesto arriba/ el quaternion identity se pone la rotaion por defecto la pone 0 0 0
        temp.GetComponent<AsteroideController >().manager = this;  //pillamos el asteroid controler y le decimos que el objeto asteroide de la escena y el this se refiere al componente actual
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
