using UnityEngine;
using System.Collections;

public class Ennemy_Script : MonoBehaviour {
	private Weapon_Script[] weapons;
	
	void Awake()
	{
		// Récupération de toutes les armes de l'ennemi
		weapons = GetComponentsInChildren<Weapon_Script>();
	}
	
	void Update()
	{
		foreach (Weapon_Script weapon in weapons)
		{
			// On fait tirer toutes les armes automatiquement
			if (weapon != null && weapon.CanAttack)
			{
				weapon.Attack(true);
			}
		}
	}
}
