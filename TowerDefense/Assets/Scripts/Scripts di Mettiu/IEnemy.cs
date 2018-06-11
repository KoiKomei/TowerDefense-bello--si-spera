using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {

	void Hurt(int damage);
	void Die();
	void Attack();
}
