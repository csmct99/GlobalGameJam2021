using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIncrease : ItemBase
{
	[SerializeField]
	private float movementIncrease = 15f;

	private void Start()
	{
		
	}
	
	private void Update()
	{
	
	}

    protected override void ItemEquip()
    {
		base.ItemEquip();
		player.SetMovementSpeed(player.GetMovementSpeed() + movementIncrease);
		player.SetSprintingSpeed(player.GetSprintingSpeed() + movementIncrease);
     
    }

    protected override void ItemUnequip()
    {
		base.ItemEquip();
		player.SetMovementSpeed(player.GetMovementSpeed() - movementIncrease);
		player.SetSprintingSpeed(player.GetSprintingSpeed() - movementIncrease);
    
    }
}
