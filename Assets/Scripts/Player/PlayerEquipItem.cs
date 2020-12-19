using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipItem : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> itemEquipedList;
    Transform Item;
    void Start()
    {
        Item = GameObject.Find("Testing object").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
    }
    private void OnCollisionStay(Collision collision) {
        
    }

    private void ItemEquiped(Transform item){
        item.parent = this.transform;
        item.localPosition = new Vector3(0, -0.08f, 0);
        itemEquipedList.Add(item);//add item to list
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "Item")
        {
            Debug.Log("object nearby");
            //if player press ebutton and is equiped status is false
            if(Input.GetKeyDown("e") && !collider.GetComponent<ItemsBehavior>().IsEquiped){
                ItemEquiped(collider.gameObject.transform);
                collider.transform.parent = this.transform;
            }
        }
    }
    
}
