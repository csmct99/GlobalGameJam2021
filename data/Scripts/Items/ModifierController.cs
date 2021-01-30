using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "15e3ff0217cfb279a0e839848d08771366299156")]
public class ModifierController : Component
{

	//Array of player mods
	//Array of enemy mods
	//Array of world mods
	//Array of weapon mods

	//Array of player actions
	//Array of enemy actions
	//Array of world actions
	//Array of weapon actions
	[ShowInEditor]
	private List<ItemBase> items = new List<ItemBase>();
	
	[ShowInEditor]
    private static ModifierController instance = null;  
    public static ModifierController Instance  
    {  
        get  
        {  
            return instance;  
        }  
    } 

	private void Init()
	{
		// write here code to be called on component initialization
		instance = node.GetComponent<ModifierController>();
		
	}
	
	private void Update()
	{

	}


	public void GetNewItem(ItemBase item){
		items.Add(item);
		Log.Warning("\nDebug info:" + items.Count);
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