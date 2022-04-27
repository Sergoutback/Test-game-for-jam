using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField]
    private Animator CamAnim;
    private Animator anim;
    // Start is called before the first frame update

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CamAnim.SetTrigger("StartNarcomanya");
            anim.SetTrigger("explosion");
        }
    }
}
