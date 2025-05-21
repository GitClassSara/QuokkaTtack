using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    public float livingTime = 3f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Destruye la bala
        Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Mover la bala
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisi�n detectada con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth2D enemy = collision.gameObject.GetComponent<EnemyHealth2D>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        
        Destroy(gameObject);
    }
}
