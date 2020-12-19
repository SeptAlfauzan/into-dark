using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    
     public Rigidbody2D weaponRb;
     Vector2 mousePos;
     SpriteRenderer playerSpriteRenderer = null;
     SpriteRenderer spriteRenderer;
     public Transform parent = null;

     public bool isEquiped;
    void Start()
    {
        weaponRb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //check whether this weapon object has parent object(equiped by player) or not
        if (isEquiped)
        {
            playerSpriteRenderer = parent.GetComponent<SpriteRenderer>();
        }else{
            playerSpriteRenderer = null;
        }

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate() {
        Vector2 lookDir = mousePos - weaponRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 0f;

        if (isEquiped)
        {//if this weapon is equiped change rotation and direction of it base on mouseposition    
            weaponRb.rotation = angle;
            ChangeDirectionPlayerAndWeapon(angle, playerSpriteRenderer);    
        }
    }

    void ChangeDirectionPlayerAndWeapon(float angle, SpriteRenderer playerSprite){
        if(angle < -90f || angle > 90f){
            playerSprite.flipX = true;
            spriteRenderer.flipY = true;
        }else{
            playerSprite.flipX = false;
            spriteRenderer.flipY = false;
        }
    }

}
