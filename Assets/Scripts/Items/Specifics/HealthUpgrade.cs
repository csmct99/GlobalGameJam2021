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
		player.SetCurrentHealth(player.GetCurrentHealth() + healthIncrease);
	    player.SetMaxHealth(player.GetMaxHealth() + healthIncrease);
     
    }

    protected override void ItemUnequip()
    {
		base.ItemEquip();
		player.SetCurrentHealth(player.GetCurrentHealth() - healthIncrease);
	    player.SetMaxHealth(player.GetMaxHealth() - healthIncrease);
    
    }

}
