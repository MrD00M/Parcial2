using UnityEngine;

namespace Parcial2.Game
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
	public class BulletExplosiva : MonoBehaviour
	{
		private Rigidbody _myRigidBody;
		private float _speed;
		private int _damage;

		private GameObject _instigator;

		public void SetParams(float expBulletSpeed, int expBulletDamage, GameObject instanceInstigator)
		{
			_instigator = instanceInstigator;
			_speed = expBulletSpeed;
			_damage = expBulletDamage;
		}

		public void Toss()
		{
			_myRigidBody.AddForce(transform.forward * _speed, ForceMode.VelocityChange);
		}

		private void OnTriggerEnter(Collider _other)
		{
			if (_other.gameObject == Player.Instance.gameObject)
			{
				//Collided with player
			}
			else
			{
				Enemy enemy = _other.GetComponent<Enemy>();

				if (enemy != null)
				{
					enemy.ReceiveExplosiveDamage(_damage);
				}
			}

			if (_instigator != _other.gameObject)
			{
				Destroy(gameObject); 
			}
		}

		// Use this for initialization
		private void Awake()
		{
			_myRigidBody = GetComponent<Rigidbody>();
		}

		private void OnDestroy()
		{
			_myRigidBody = null;
		}
	} 
}