using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Temp ref until levels have players in em
    CharactorController playerChar = new CharactorController();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void DropInventory(int numOfItemsToDrop)
    {
        //get player inventory
        List<ItemBase> inv = playerChar.GetInventory();
        //list index of items drop for no repeats
        List<int> itemIndexDropped = new List<int>();
        //list of items the fool dropped to be placed into the level
        List<ItemBase> itemsDropped = new List<ItemBase>();

        int rndIndex = 0;

        for(int x = 0; (x < numOfItemsToDrop && x < inv.Count); x++)
        {
            rndIndex = Random.Range(1, inv.Count);
            if(!itemIndexDropped.Contains(rndIndex)){
                itemIndexDropped.Add(Random.Range(1, inv.Count)); //add index to repeat tracker
                itemsDropped.Add(inv[rndIndex]); //add item to list to be strewn about the level
                inv.RemoveAt(itemIndexDropped[rndIndex]); //remove the inventory item in question
            }else{
                x--;
            }
        }
        //Return inventory to player
        playerChar.SetInventory(inv);
        //Drop items in level
        DroppedItemsInLevel(itemsDropped);
    }
    void DroppedItemsInLevel(List<ItemBase> itemsDropped)
    {

    }
}
