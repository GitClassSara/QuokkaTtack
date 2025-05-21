using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadTrigger : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, 10f); // impulso hacia arriba
            }

            Destroy(enemy); // Destruye al enemigo completo
        }
    }
}
