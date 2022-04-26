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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += player.transform.up * speed * Time.deltaTime;
            anim.SetInteger("Pose", 1);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position -= player.transform.up * speed * Time.deltaTime;
            anim.SetInteger("Pose", 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position -= player.transform.right * speed * Time.deltaTime;
            anim.SetInteger("Pose", 2);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position += player.transform.right * speed * Time.deltaTime;
            anim.SetInteger("Pose", 2);
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
    }

}
