using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoves : MonoBehaviour
{
    public GameObject player;
    public int speed = 300;
    public int speedRotation = 2;

    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = (GameObject)this.gameObject;
    }

    [System.Obsolete]
    void Update()
    {
        if (Time.timeScale != 0.0f) {
            anim.SetInteger("pose", 3);
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetInteger("pose", 0);
                transform.position += transform.up * speed * Time.deltaTime;
            } 
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetInteger("pose", 1);
                transform.position -= transform.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetInteger("pose", 2);
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetInteger("pose", 2);
                gameObject.transform.localScale = new Vector3(1,1,1);
                transform.position += transform.right * speed * Time.deltaTime;
            } 
        } 
    }

}
