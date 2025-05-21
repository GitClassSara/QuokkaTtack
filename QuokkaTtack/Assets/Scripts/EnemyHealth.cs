using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2D : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    public AudioSource hitSound;        // (opcional)
    public GameObject deathEffect;      // (opcional: partícula o animación)

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (hitSound != null)
            hitSound.Play();

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        if (deathEffect != null)
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
