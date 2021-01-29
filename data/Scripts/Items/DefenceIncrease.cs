using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "bc63ae7b8f06d19eafba8c6532b552801d0323df")]
public class DefenceIncrease : ItemBase
{
	[ShowInEditor]
	private int defenceIncrease = 3;

	private void Init()
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