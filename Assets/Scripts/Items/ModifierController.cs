using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{

	//Array of player mods
	//Array of enemy mods
	//Array of world mods
	//Array of weapon mods

	//Array of player actions
	//Array of enemy actions
	//Array of world actions
	//Array of weapon actions
	[SerializeField]
	private List<ItemBase> items = new List<ItemBase>();
	
	[SerializeField]
    private static ModifierController instance = null;  
    public static ModifierController Instance {get;} //I condensed this to the proper shorthand - Connor

	private void Init() {
		// write here code to be called on component initialization
		instance = this; //Wtf? bro this is straight up redundent - Connor <3
		
	}
	
	private void Update() {

	}


	public void GetNewItem(ItemBase item){
		items.Add(item);
        print("\nDebug info:" + items.Count);
	}

	public void ClearAllItems(){

	}

	//Return values
	//->player mods
	//->players actions
	//->
	//->
	//->
	//->
	//->
}
