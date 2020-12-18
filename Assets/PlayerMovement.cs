using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called asdbefore the first frame update
    Vector2 movementInput;
    public float speed;
    Rigidbody2D playerRb;
    void Start()
    {
        Debug.Log("Starting");
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(movementInput.x * speed, movementInput.y * speed);
        movement *= Time.fixedDeltaTime;

        playerRb.MovePosition(playerRb.position + movement);
    }
}
