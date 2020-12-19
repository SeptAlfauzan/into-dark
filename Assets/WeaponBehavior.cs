using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D weaponRb;
    public Camera camera;
    Vector2 mousePos;
    SpriteRenderer playerSpriteRenderer;
    SpriteRenderer spriteRenderer;
    Transform parent;

    bool isEquiped = false;
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
        if (transform.parent != null && transform.parent.tag == "Player")
        {
            isEquiped = true;
            playerSpriteRenderer = this.transform.parent.GetComponent<SpriteRenderer>();
        }else{
            isEquiped = false;
        }
        GetComponent<ItemsBehavior>().IsEquiped = isEquiped;//update is equiped status in Items Behavior scripts
        
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
