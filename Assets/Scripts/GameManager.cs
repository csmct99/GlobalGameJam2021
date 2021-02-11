using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject itemSpawnPrefab;
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } } // public static property that gets the instance.

    //Temp ref until levels have players in em
    CharactorController playerChar = new CharactorController();
    
    void Awake() {
        
        if(instance != null && instance != this) { // If instance does not equal null and instance does not equal self, destroy.
            Destroy(gameObject);
            return;
        }
        else {

            instance = this; //if it is null make instance, this
        }
    }

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

    private void DroppedItemsInLevel(List<ItemBase> itemsDropped)
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        List<GameObject> itemSpawnPoints = new List<GameObject>();
        //Find all the scene's spawn points
        foreach (GameObject obj in allObjects)
        {
            if(obj.GetComponent<ItemSpawnPoint>() != null){
                itemSpawnPoints.Add(obj);
            }
        }

        //Place an item in those spots
        foreach (ItemBase droppedItem in itemsDropped)
        {
            //m_CurrentWave = waves [Random.Range(0, waves.Count)];
            int RandomlyChosenSpawn = Random.Range(0, itemSpawnPoints.Count);

            Vector3 spawnLocation = itemSpawnPoints[RandomlyChosenSpawn].transform.position;
            itemSpawnPoints.RemoveAt(RandomlyChosenSpawn);

            //TODO; Feed droppedItem into itemSpawnPrefab
            Instantiate(itemSpawnPrefab, spawnLocation, Quaternion.identity);
        }
        //TODO; Add more items to spawnable items. 

    }

    public void EndLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCount > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
