using UnityEngine;
using System.Collections;

public class Shot_Script : MonoBehaviour {
	// Points de dégâts infligés
	public int damage = 1;
	/// Projectile ami ou ennemi ?
	public bool isEnemyShot = false;
	
	void Start()
	{
		//Destruction programmée
		Destroy(gameObject, 20); // 20sec
	}
}
