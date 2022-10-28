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
        Vector2 direccion = new Vector2(Random.Range (-1f,1f), Random.Range(-1f,1f));  
        direccion = direccion * Random.Range(speed_min, speed_max); 
        rb.AddForce(direccion);
        //manager.asteroides += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.limpiar)
        {
            Destroy(this.gameObject);

        }
    }

    public void Muerte()  
    {
        if (transform.localScale.x > 0.25)
        {
       
        GameObject temp1 = Instantiate(manager.asteroide, transform.position,transform.rotation);
        temp1.GetComponent <AsteroideController>().manager = manager;
        temp1.transform.localScale = transform.localScale * 0.5f;

        GameObject temp2 = Instantiate(manager.asteroide, transform.position, transform.rotation);
        temp2.GetComponent <AsteroideController>().manager = manager;
        temp2.transform.localScale = transform.localScale * 0.5f;
        manager.asteroides += 2;
        

        }
        GameManager.instance.puntuacion += 100;
        manager.asteroides -= 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
       if (collision.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerMovement>().Muerte();
        }
    }
}
