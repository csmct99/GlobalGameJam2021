using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "9ef3252ad0b092817e5ec9ec23bf3c5b241445fe")]
public class DamageIncrease : ItemBase
{
	[ShowInEditor]
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