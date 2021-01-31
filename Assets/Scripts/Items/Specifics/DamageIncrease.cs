using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrease : ItemBase
{
	[SerializeField]
	private int attackIncrease = 5;

	private void Start()
	{
		
	}
	
	private void Update()
	{
	
	}

    protected override void ItemEquip()
    {
		base.ItemEquip();
		player.SetSwordDamage(player.GetSwordDamage() + attackIncrease);
		
     
    }

    protected override void ItemUnequip()
    {
		base.ItemEquip();
		player.SetSwordDamage(player.GetSwordDamage() - attackIncrease);
		
    
    }
}
