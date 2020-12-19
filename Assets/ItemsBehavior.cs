using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehavior : MonoBehaviour
{
    public bool IsEquiped;
    public Transform parent = null;
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<WeaponBehavior>().isEquiped = IsEquiped;    
        GetComponent<WeaponBehavior>().parent = parent;    
    }
    

    // void IgnoreCollisionPlayer(){
    //     Collider2D[] playerCollisions = GameObject.FindGameObjectWithTag("Player").GetComponents<Collider2D>();

    //     foreach (Collider2D collision in playerCollisions)
    //     {
    //         Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
    //     }
    // }
}
