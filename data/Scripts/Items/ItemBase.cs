using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "847afb64839b8f73e8b80e36c6b7301d03bcf2d8")]
public class ItemBase : Component
{
	protected bool isOnGround;
	protected bool isEquipped;
	protected string itemName;

	//TODO private DrewsPlayerClass player;


	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}

	public void CollisionCallback(Body body){
		if(body.Object !=null) {
			if(body.Object.GetComponent<ItemBase>() !=null){//is this a player?
				//player = body.Object.GetComponent<DrewsCharacterController>();
				ItemEquip();
				isEquipped = true;
			}

		}
	
	}

	protected virtual void ItemEquip(){
		//How the item Equips to the player
		
	}

	protected virtual void ItemUnequip(){
		//How the item unequips from the player

	}
}