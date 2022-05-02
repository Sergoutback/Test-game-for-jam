using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 25.0f;
    public float minDistance = 50.0f;
    public float maxDistance = 300.0f;
    public GameObject stars;
    private bool direction = true;
    private bool isPatrolling = true;
    private bool isChasing = false;
    private bool readyToAttack = true;

    public HealthBarBehaviour healthBar;

    public int maxHealth = 3;
    public int health = 3;

    private GameObject player;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player" && isPatrolling) {
            startChase(col.gameObject);
        }
    }

    void startChase(GameObject p) {
        isPatrolling = false;
        StopCoroutine(DirectionCoroutine());
        isChasing = true;
        player = p;
    }

    void stopChase() {
        isPatrolling = true;
        StartCoroutine(DirectionCoroutine());
        isChasing = false;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<Player>().takeDamage(1);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        healthBar.setHealth(health, maxHealth);
        StartCoroutine(DirectionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0.0f) {       // to pause for dialog
            
            if (isPatrolling) {
                Vector2 directionTranslation = (direction) ? transform.right : -transform.right;
                directionTranslation *= Time.deltaTime * movementSpeed;
                transform.Translate(directionTranslation);
            }

            if (isChasing) {
                
                if (Vector2.Distance(transform.position, player.transform.position) >= minDistance) {
                    transform.position =  Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * 4 * Time.deltaTime);

                }
                if (Vector2.Distance(transform.position, player.transform.position) <= minDistance) {
                    if (readyToAttack) DashAttack();
                }
                if (Vector2.Distance(transform.position, player.transform.position) >= maxDistance) {
                    stopChase();
                }
            }

        }
    }

    void DashAttack() {
        readyToAttack = false;

        Vector3 prevPosition = transform.position;
        transform.position =  Vector2.MoveTowards(player.transform.position, prevPosition, movementSpeed * 50 * Time.deltaTime);
        
        StartCoroutine(ReloadAttackCoroutine());
    }

    public void takeDamage(int damage) {
        health -= damage;
        healthBar.setHealth(health, maxHealth);
        if (health <= 0) die();
    }

    private void die() {
        Destroy(gameObject);
    }

    public void getStunned() {
        // visually confirm stun
        // add starts
        StartCoroutine(StunCoroutune());
    }

    IEnumerator StunCoroutune() {
        stopChase();
        isPatrolling = false;
        GameObject tempStars = Instantiate(stars, transform); 
        tempStars.transform.localPosition = new Vector2(0, 45f);
        yield return new WaitForSeconds(4f);
        isPatrolling = true;
        Destroy(tempStars);
    }

    IEnumerator ReloadAttackCoroutine() {
        yield return new WaitForSeconds(2f);
        readyToAttack = true;
    }

    IEnumerator DirectionCoroutine()
    {
        yield return new WaitForSeconds(3);
        direction = !direction;
        StartCoroutine(DirectionCoroutine());
    }

    void OnDestroy() {
        StopAllCoroutines();
    }
}
