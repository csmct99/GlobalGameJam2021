using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthUpgrade : ItemBase {
	[SerializeField]
	private int healthIncrease = 15;

	private void Start()
	{
		
	}
	
	private void Update()
	{
	
	}

    protected override void ItemEquip()
    {
		base.ItemEquip();
		//TODO player.getCurrentHP += healthIncrease;
		//TODO player.getMaxHP += healthIncrease;
     
    }

    protected override void ItemUnequip()
    {
		base.ItemEquip();
		//TODO player.getCurrentHP -= healthIncrease;
		//TODO player.getMaxHP -= healthIncrease;
    
    }

}
