using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;
    public GameObject Other;
    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        if (Time.timeScale != 0.0f) {

            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject bulletClone = Instantiate(bullet);
                bulletClone.transform.position = firePoint.position;
                bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle - 180);

                bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
                Destroy(bulletClone, 5);
            }

            if (Input.GetMouseButton(1))
            {
                GameObject bulletClone = Instantiate(bullet);
                bulletClone.transform.position = firePoint.position;
                bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle - 180);

                bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
                Destroy(bulletClone, 1);
            }
        }

    }
    
}
    

    

  