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
	[ShowInEditor]
	public PhysicalTrigger physicalTrigger;

	private void Init()
	{
		physicalTrigger = node.GetChild(0) as PhysicalTrigger;

		if (physicalTrigger != null)
		{
			physicalTrigger.AddEnterCallback(EnterCallback);
		}
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}

	public void EnterCallback(Body body){
				//player = body.Object.GetComponent<DrewsCharacterController>();
				//ItemEquip();
				//isEquipped = true;
				Log.WarningLine("Debug info: HIT");
				ModifierController.Instance.GetNewItem(this);
				node.DeleteLater();
	}

	protected virtual void ItemEquip(){
		//How the item Equips to the player
	}

	protected virtual void ItemUnequip(){
		//How the item unequips from the player

	}
}