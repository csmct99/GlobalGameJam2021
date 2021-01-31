using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceIncrease : ItemBase
{
	[SerializeField]
	private int defenceIncrease = 3;

	private void Start()
	{
		
	}
	
	private void Update()
	{
	
	}

    protected override void ItemEquip()
    {
		base.ItemEquip();
		//TODO player.defence += defenceIncrease;
		
     
    }

    protected override void ItemUnequip()
    {
		base.ItemEquip();
		//TODO player.defence -= defenceIncrease;
		
    
    }
}
