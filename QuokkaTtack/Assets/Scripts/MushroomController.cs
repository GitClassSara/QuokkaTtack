using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;

    private GameObject _target;


    public GameObject bulletPrefab;
    private Transform _firePoint;

    public int maxHealth = 2;
    private int currentHealth;

    public float attackRange = 5f;
    public float attackCooldown = 2f;
    private Transform player;
    private float lastAttackTime = -Mathf.Infinity;
    private bool isAttacking = false;

    private bool isFacingRight = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        _firePoint = transform.Find("FirePoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && IsPlayerInFront())
        {
            if (!isAttacking && Time.time >= lastAttackTime + attackCooldown)
            {
                StartCoroutine(Shoot());
            }
        }
    }


    private void UpdateTarget()
    {
        // If first time, create target in the left
        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }

        if (_target.transform.position.x == minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);  // Mira a la izquierda
            isFacingRight = false;
        }
        else if (_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);   // Mira a la derecha
            isFacingRight = true;
        }
    }

    private IEnumerator PatrolToTarget()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            if (!isAttacking)
            {
                Vector2 direction = (_target.transform.position - transform.position).normalized;
                Vector2 newPos = rb.position + direction * speed * Time.deltaTime;
                rb.MovePosition(newPos);
            }

            yield return null;
        }

        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        yield return new WaitForSeconds(waitingTime);
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    IEnumerator Shoot()
    {
        if (bulletPrefab != null && _firePoint != null)
        {
            isAttacking = true;
            lastAttackTime = Time.time;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.zero;

            // Apuntar hacia el jugador
            Vector2 direction = (player.position - _firePoint.position).normalized;

            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

            Bala bulletComponent = myBullet.GetComponent<Bala>();

            if (transform.localScale.x > 0f)
            {
                // Left
                bulletComponent.direction = Vector2.left; // new Vector2(-1f, 0f)
            }
            else
            {
                // Right
                bulletComponent.direction = Vector2.right; // new Vector2(1f, 0f)
            }
            yield return new WaitForSeconds(attackCooldown);
            isAttacking = false;
        }
    }

    private bool IsPlayerInFront()
    {
        float directionToPlayer = player.position.x - transform.position.x;

        if (isFacingRight && directionToPlayer < 0)
            return true;

        if (!isFacingRight && directionToPlayer > 0)
            return true;

        return false;
    }


    public void AddDamage()
    {
        gameObject.SetActive(false);
    }
}
