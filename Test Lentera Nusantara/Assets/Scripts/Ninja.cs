using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : BaseChar
{
	[SerializeField]
	private Transform kunaiSpawn;
	[SerializeField]
	private GameObject kunaiPrefab;
	[SerializeField]
	private float kunaiSpeed = 5.0f, delayCreateKunai;
	private static Ninja instance;
	private bool throwingKunai = false;

	public static Ninja Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType<Ninja>();
			}
			return instance;
		}
	}

	//	Animasi Ninja
	public void Slide()
	{
		animator.Play("Slide", -1, 0f);
	}
	public void Throw()
	{
		if (!throwingKunai)
		{
			animator.Play("Throw", -1, 0f);
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
			{
				throwingKunai = false;
			}
			else
			{
				Invoke("CreateKunai", delayCreateKunai);
			}
		}
		else
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Throw") && throwingKunai)
			{
				throwingKunai = false;
			}
		}
	}
	public void Jump()
	{
		animator.Play("Jump", -1, 0f);
	}
	public void JumpAttack()
	{
		animator.Play("Jump_Attack", -1, 0f);
	}
	public void JumpThrow()
	{
		if (!throwingKunai)
		{
			animator.Play("Jump_Throw", -1, 0f);
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump_Throw"))
			{
				throwingKunai = false;
			}
			else
			{
				Invoke("CreateKunai", delayCreateKunai);
			}
		}
		else
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump_Throw") && throwingKunai)
			{
				throwingKunai = false;
			}
		}
	}
	public void CreateKunai()
	{
		//	Melempar kunai
		Vector3 kunaiRotation = (leftSide) ? new Vector3(0f, 0f, 90f) : new Vector3(0f, 0f, -90f);
		Vector3 kunaiDirection = (leftSide) ? Vector3.left : Vector3.right;
		GameObject kunai = Instantiate(kunaiPrefab, kunaiSpawn.position, Quaternion.Euler(kunaiRotation));
		kunai.GetComponent<Rigidbody2D>().velocity = kunaiDirection * kunaiSpeed;
		Destroy(kunai, 2.5f);
	}
}
