using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float moveDistance = 2f;         // Cuánto se mueve la pared hacia arriba
    public float moveSpeed = 2f;            // Qué tan rápido se mueve
    public float waitTime = 2f;             // Tiempo de espera entre subidas y bajadas

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.up * moveDistance;
        StartCoroutine(MoveWall());
    }

    System.Collections.IEnumerator MoveWall()
    {
        while (true)
        {
            Vector3 destination = movingUp ? targetPosition : startPosition;

            // Movimiento suave
            while (Vector3.Distance(transform.position, destination) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Corregir posición final
            transform.position = destination;

            // Espera antes de cambiar de dirección
            yield return new WaitForSeconds(waitTime);

            // Cambia dirección
            movingUp = !movingUp;
        }
    }
}

