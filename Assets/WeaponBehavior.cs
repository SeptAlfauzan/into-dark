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
    void Start()
    {
        weaponRb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        playerSpriteRenderer = this.transform.parent.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate() {
        Vector2 lookDir = mousePos - weaponRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 0f;
        Debug.Log(angle);
        weaponRb.rotation = angle;

        ChangeDirectionPlayerAndWeapon(angle);    
    }

    void ChangeDirectionPlayerAndWeapon(float angle){
        if(angle < -90f || angle > 90f){
            playerSpriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        }else{
            playerSpriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }
    }
}
