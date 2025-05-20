using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;

    private Transform _firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        _firePoint = transform.Find("FirePoint");
    }

    void Shoot()
    {
        if (bulletPrefab != null && _firePoint != null && shooter != null) {
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bala bulletComponent = myBullet.GetComponent<Bala>();

            if (shooter.transform.localScale.x < 0f)
            {
                //Izquierda
                bulletComponent.direction = Vector2.left;
            }
            else
            {
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
