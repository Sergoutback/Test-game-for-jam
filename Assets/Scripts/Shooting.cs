using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject strike;
    public Transform firePoint;
    public float bulletSpeed = 50;
    public GameObject Other;
    Vector2 lookDirection;
    float lookAngle;

    private bool stunReady = true;

    void Update()
    {
        if (Time.timeScale != 0.0f) {

            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (lookDirection - (Vector2) transform.position).normalized;
            lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject bulletClone = Instantiate(bullet);
                bulletClone.transform.position = firePoint.position;
                bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle - 180);

                bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
                Destroy(bulletClone, 5);
            }

            if (Input.GetMouseButtonDown(1) && stunReady)
            {
                stunReady = false;
                GameObject strikeClone = Instantiate(strike);
                strikeClone.transform.position = (Vector2) transform.position + direction * 30;
                strikeClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle + 90);
                Destroy(strikeClone, 0.2f);
                StartCoroutine(CoolDownCoroutine());

            }
        }

    }


    IEnumerator CoolDownCoroutine() {
        yield return new WaitForSeconds(1f);
        stunReady = true;
    }
    
}
    

    

  