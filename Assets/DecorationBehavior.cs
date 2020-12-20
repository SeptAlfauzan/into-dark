using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float transparancy = 100f;
    Color transparent;
    Color normal;
    void Start()
    {
        transparent = GetComponent<SpriteRenderer>().color;
        normal = GetComponent<SpriteRenderer>().color;
        transparent.a = 0.5f;
        normal.a = 1f;
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = transparent;
        }
    }
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = normal;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
