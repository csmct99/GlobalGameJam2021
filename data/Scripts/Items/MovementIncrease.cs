using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "9b37904d5944f54832b218071dbbf5baa20c89d1")]
public class MovementIncrease : ItemBase
{
	[ShowInEditor]
	private float movementIncrease = 15f;

	private void Init()
	{
		
	}
	
	private void Update()
	{
	
	}

    protected override void ItemEquip()
    {
		base.ItemEquip();
		//TODO player.currentSpeed += movementIncrease;
		
     
    }

    protected override void ItemUnequip()
    {
		base.ItemEquip();
		//TODO player.currentSpeed -= movementIncrease;
		
    
    }

}