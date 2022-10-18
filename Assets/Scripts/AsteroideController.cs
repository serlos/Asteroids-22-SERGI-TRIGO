using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideController : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public AsteroidManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range (-1f,1f), Random.Range(-1f,1f)); // este random.range me pasa un numero aleatorio entre los dos floats que le indicamos, este caso -1 y 1
        Debug.Log(direccion); 
        direccion = direccion * Random.Range(speed_min, speed_max); // para modificar la direccion (el largo del vector para especificar que vamos mas rapidos o mas lentos) multiplicamos y le decimos que son esos dos public para modificar desde fuera
        rb.AddForce(direccion); // le añadimos fuerza para que se mueva 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Muerte()  // funciones siempre van fuera de otras funciones y si pones void es q no queremos una respuesta, que no nos devuelva nada
    {
        if (transform.localScale.x > 0.25)
        {
       
        GameObject temp1 = Instantiate(manager.asteroide, transform.position,transform.rotation);
        temp1.GetComponent <AsteroideController>().manager = manager;
        temp1.transform.localScale = transform.localScale * 0.5f;

        GameObject temp2 = Instantiate(manager.asteroide, transform.position, transform.rotation);
        temp2.GetComponent <AsteroideController>().manager = manager;
        temp2.transform.localScale = transform.localScale * 0.5f;
        
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) //funcion ontrigger nos la da unity y nos dice q cualquier cosa que entre en nuestro trigger nos dira que ha entrado
    {
        if (collision.tag == "Player") //con un = dice que algo contiene algo, si ponemos 2 es para comparar
        {
            collision.GetComponent<PlayerMovement>().Muerte();  //pillamos la funcion de PlayerMovement y asi le decimos que morimos cuando nos chocamos con el asteroide

        }
    }

}