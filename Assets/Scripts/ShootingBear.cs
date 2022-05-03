using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBear : MonoBehaviour
{
    public GameObject roar;
    public GameObject strike;
    Vector2 lookDirection;
    float lookAngle;

    private bool stunReady = true;
    private bool roarReady = true;

    void Update()
    {
        if (Time.timeScale != 0.0f) {

            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (lookDirection - (Vector2) transform.position).normalized;
            lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


            if (Input.GetMouseButtonDown(0) && stunReady)
            {
                stunReady = false;
                GameObject strikeClone = Instantiate(strike);
                strikeClone.transform.position = (Vector2) transform.position + direction * 30;
                strikeClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle + 90);
                Destroy(strikeClone, 0.2f);
                StartCoroutine(CoolDownStrikeCoroutine());

            }
            if (Input.GetMouseButtonDown(1) && roarReady)
            {
                roarReady = false;
                GameObject roarClone = Instantiate(roar);
                roarClone.transform.position = (Vector2) transform.position + direction * 30;
                roarClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle + 180);
                Destroy(roarClone, 0.4f);
                StartCoroutine(CoolDownRoarCoroutine());
            }

        }

    }


    IEnumerator CoolDownStrikeCoroutine() {
        yield return new WaitForSeconds(0.2f);
        stunReady = true;
    }

    IEnumerator CoolDownRoarCoroutine() {
        yield return new WaitForSeconds(1f);
        roarReady = true;
    }
}
