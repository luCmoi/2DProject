using UnityEngine;
using System.Collections;

public class Weapon_Script : MonoBehaviour {
	// Prefab du projectile
	public Transform shotPrefab;
	// Temps de rechargement entre deux tirs
	public float shootingRate = 0.25f;
	// Rechargement	
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	
	/// Création d'un projectile si possible
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			// Création d'un objet copie du prefab
			var shotTransform = Instantiate(shotPrefab) as Transform;
			// Position
			shotTransform.position = transform.position;
			// Propriétés du script
			Shot_Script shot = shotTransform.gameObject.GetComponent<Shot_Script>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			// On saisit la direction pour le mouvement
			/*Move_Script move = shotTransform.gameObject.GetComponent<Move_Script>();
			if (move != null)
			{
				move.direction = this.transform.right; // ici la droite sera le devant de notre objet
			}*/
		}
	}

	/// L'arme est chargée ?
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}

}
