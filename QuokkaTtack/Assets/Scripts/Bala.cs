using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    public float livingTime = 3f;

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
}
