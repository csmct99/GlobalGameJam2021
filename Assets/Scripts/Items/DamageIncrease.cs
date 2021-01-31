using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrease : ItemBase
{
	[SerializeField]
	private int attackIncrease = 5;

	private void Init()
	{
		
	}
	
	private void Update()
	{
	
	}

    protected override void ItemEquip()
    {
		base.ItemEquip();
		//TODO player.attack += attackIncrease;
		
     
    }

    protected override void ItemUnequip()
    {
		base.ItemEquip();
		//TODO player.attack -= attackIncrease;
		
    
    }
}
