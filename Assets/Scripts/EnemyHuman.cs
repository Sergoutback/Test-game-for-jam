using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHuman : MonoBehaviour
{
    public GameObject arrow;
    public GameObject strike;

    public float movementSpeed = 25.0f;
    public float minDistance = 50.0f;
    public float maxDistance = 300.0f;
    public GameObject stars;
    private bool direction = true;
    private bool isPatrolling = true;
    private bool isChasing = false;
    private bool isStunned = false;
    private bool readyToAttack = true;

    public HealthBarBehaviour healthBar;

    public int maxHealth = 3;
    public int health = 3;

    private GameObject player;

    public GameObject bloodSpill;
    private Animator anim;

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

    // void OnCollisionEnter2D(Collision2D col) {
    //     if (col.gameObject.tag == "Player" && !isStunned) {
    //         col.gameObject.GetComponent<Player>().takeDamage(1);
    //     }
    // }


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        healthBar.setHealth(health, maxHealth);
        StartCoroutine(DirectionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0.0f) {       // to pause for dialog
            
            if (isPatrolling) {
                anim.SetInteger("pose", 1);
                Vector2 directionTranslation = (direction) ? transform.right : -transform.right;
                directionTranslation *= Time.deltaTime * movementSpeed;
                transform.Translate(directionTranslation);
            }

            if (isChasing) {
                anim.SetInteger("pose", 1);
                if (Vector2.Distance(transform.position, player.transform.position) >= minDistance) {
                    transform.position =  Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * 4 * Time.deltaTime);

                }
                if (Vector2.Distance(transform.position, player.transform.position) <= minDistance) {
                    if (readyToAttack) Attack();
                }
                if (Vector2.Distance(transform.position, player.transform.position) >= maxDistance) {
                    stopChase();
                }
            }

        }
    }

    void Attack() {
        readyToAttack = false;

        // Vector3 prevPosition = transform.position;
        // transform.position =  Vector2.MoveTowards(player.transform.position, prevPosition, movementSpeed * 50 * Time.deltaTime);

        Vector2 direction = (Vector2)(player.transform.position - transform.position).normalized;
        float lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject strikeClone = Instantiate(strike);
        strikeClone.transform.position = (Vector2) transform.position + direction * 30;
        strikeClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle + 90);
        Destroy(strikeClone, 0.2f);

        StartCoroutine(ReloadAttackCoroutine());
    }

    public void takeDamage(int damage) {
        health -= damage;
        healthBar.setHealth(health, maxHealth);
        if (health <= 0) die();
    }

    private void die() {
        Vector3 pos = gameObject.transform.position;
        Destroy(gameObject);
        GameObject blClone = Instantiate(bloodSpill, pos, Quaternion.identity);
        Destroy(blClone, 4f);
    }

    public void getStunned() {
        // visually confirm stun
        // add starts
        StartCoroutine(StunCoroutune());
    }

    IEnumerator StunCoroutune() {
        anim.SetInteger("pose", 3);
        isStunned = true;
        stopChase();
        isPatrolling = false;
        GameObject tempStars = Instantiate(stars, transform); 
        tempStars.transform.localPosition = new Vector2(0, 45f);
        yield return new WaitForSeconds(4f);
        isPatrolling = true;
        Destroy(tempStars);
        isStunned = false;
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
