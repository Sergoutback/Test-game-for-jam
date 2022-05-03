using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoves : MonoBehaviour
{
    public int speed = 300;
    private int maxSpeed;
    public int speedRotation = 2;
    private bool isWalking = false;

    private Animator anim;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maxSpeed = speed;
        anim = gameObject.GetComponent<Animator>();

        StartCoroutine(PlayWalkSound());
    }

    [System.Obsolete]
    void Update()
    {
        isWalking = false;

        if (Time.timeScale != 0.0f) {
            anim.SetInteger("pose", 3);
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetInteger("pose", 0);
                transform.position += transform.up * speed * Time.deltaTime;
                isWalking = true;
            } 
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetInteger("pose", 1);
                transform.position -= transform.up * speed * Time.deltaTime;
                isWalking = true;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetInteger("pose", 2);
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                transform.position -= transform.right * speed * Time.deltaTime;
                isWalking = true;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetInteger("pose", 2);
                gameObject.transform.localScale = new Vector3(1,1,1);
                transform.position += transform.right * speed * Time.deltaTime;
                isWalking = true;
            } 
        } 
    }

    IEnumerator PlayWalkSound() {
        yield return new WaitForSeconds(0.4f);
        if (isWalking) audioSource.Play();
        StartCoroutine(PlayWalkSound());
    }

    void OnDestroy() {
        StopAllCoroutines();
    }

}
