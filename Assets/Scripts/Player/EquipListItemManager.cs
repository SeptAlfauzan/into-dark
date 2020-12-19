using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipListItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> itemEquipedList;

    private void ItemEquiped(Transform item){
        item.GetComponent<ItemsBehavior>().parent = this.transform;
        item.GetComponent<ItemsBehavior>().IsEquiped = true;
       
        itemEquipedList.Add(item);//add item to list
    }


    private void Update() {
        foreach (var item in itemEquipedList)
        {
            item.position = (this.transform.position + new Vector3(0, -0.08f, 0));
        }
    }

    void DropItem(){
        Debug.Log("Item dropped");
        itemEquipedList[0].GetComponent<WeaponBehavior>().parent = null;
        itemEquipedList[0].GetComponent<ItemsBehavior>().IsEquiped = false;//change isequiped value to false 
        // //set item rotaion back to normal
        itemEquipedList[0].GetComponent<WeaponBehavior>().weaponRb.rotation = 0f;
        
        itemEquipedList.Remove(itemEquipedList[0].transform);//then remove item from list
    }
    
    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "Item")
        {
            //if player press ebutton and is equiped status is false
            if(Input.GetKeyDown("e") && !collider.GetComponent<ItemsBehavior>().IsEquiped){
                ItemEquiped(collider.gameObject.transform);
                // Debug.Log(collider.GetComponent<ItemsBehavior>().IsEquiped);
            }

            else if(Input.GetKeyDown("e") && collider.GetComponent<ItemsBehavior>().IsEquiped){
                DropItem();
            }
                // collider.transform.parent = this.transform;

                // // disable collider
                // collider.enabled = false;
                // collider.enabled = false;
            
        }
    }
    
}
