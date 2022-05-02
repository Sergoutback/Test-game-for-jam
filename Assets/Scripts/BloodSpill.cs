using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpill : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(UpdateBlood());
    }

    IEnumerator UpdateBlood() {
        foreach(Sprite blood in sprites) {
            spriteRenderer.sprite = blood;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }

}
