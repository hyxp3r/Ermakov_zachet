using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
	[SerializeField] private float ammo = 90; //perezarad
	[SerializeField] private float range = 100f;
	[SerializeField] private Camera fpsCams;
	
	//[SerializeField] private ParticleSystem muzzleFlash1;
	[SerializeField] private GameObject impactEffect;
	[SerializeField] private float impactForce = 30f;
	[SerializeField] private float fireRate = 15f;
	
	[SerializeField] Text text; //perezarad
	private float nextTimeToFire = 0f;
	private float kolvo = 3; //perezarad
	
	private void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextTimeToFire && ammo > 0)
		{
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();
		
		}
		//else
		//{
			//muzzleFlash1.Stop();
		//}
		if (ammo == 0 && kolvo != 0) 
		{
			Reload();
		}

		if (Input.GetKeyDown(KeyCode.R) && kolvo != 0)
		{
			Reload();
		}
		text.text = ammo.ToString() + '/' + kolvo.ToString();
	}
	
	
	private void Shoot()
	{
		//muzzleFlash1.Play();
		
		ammo --;
		RaycastHit hit;
		if (Physics.Raycast(fpsCams.transform.position, fpsCams.transform.forward, out hit, range))
		{
			Enemy enemy = hit.transform.GetComponent<Enemy>();
			
			if (enemy!=null)
			{
				enemy.TakeDamage(damage);
			}
			
			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal *impactForce);
			}
			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 1f);
		
		}
	}

	private void Reload() {
		ammo = 30;
		kolvo --;

	}
}
