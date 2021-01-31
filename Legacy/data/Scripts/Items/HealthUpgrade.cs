using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "bc2eb2dddda7169845c3a9173ffcb38ab4470d61")]
public class HealthUpgrade : ItemBase
{
	[ShowInEditor]
	private int healthIncrease = 15;

	private void Init()
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