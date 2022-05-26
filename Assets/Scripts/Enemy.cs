using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 50f;
	[SerializeField] public Text text_2;
	[SerializeField] public int die = 10;

	public void TakeDamage(float amoant)
	{
		health -= amoant;
		if (health <= 0f)
		{
			die--;
			Die();
		}
	}
	private void Die()
	{
		Destroy(gameObject);
		die--;
	}

	public void Update()
	{
		text_2.text = die.ToString();
	}
}
