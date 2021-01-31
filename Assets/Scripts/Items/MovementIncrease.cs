using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIncrease : ItemBase
{
	[SerializeField]
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
