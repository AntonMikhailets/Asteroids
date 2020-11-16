using UnityEngine;

public interface IAsteroid
{
	void SetDirection();
	void Crash();
	void Collision(GameObject collisionObject);
}