using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehavior : MonoBehaviour
{
    public bool IsEquiped;
    // Start is called before the first frame update
    void Start()
    {
        // IgnoreCollisionPlayer();//ignore collision from item object with player
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void IgnoreCollisionPlayer(){
    //     Collider2D[] playerCollisions = GameObject.FindGameObjectWithTag("Player").GetComponents<Collider2D>();

    //     foreach (Collider2D collision in playerCollisions)
    //     {
    //         Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
    //     }
    // }
}
