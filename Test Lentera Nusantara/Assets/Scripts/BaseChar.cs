using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseChar : MonoBehaviour
{
	[SerializeField]
	protected Animator animator;
	[SerializeField]
	private float speed = 5.0f, slideSpeed = 8.0f, highJump = 2.0f;
	public bool leftSide = false;

	public float GetSpeed()
	{
		return speed;
	}
	public float GetSlideSpeed()
	{
		return slideSpeed;
	}
	public float GetHighJump()
	{
		return highJump;
	}

	//	Animasi dasar
	public void Idle()
	{
		animator.Play("Idle", -1, 0f);
	}
	public void Run()
	{
		animator.CrossFade("Run", 0f);
	}
	public void Attack()
	{
		animator.CrossFade("Attack", 0f);
	}
	public void Dead()
	{
		animator.CrossFade("Dead", 0f);
	}

	//	Mengubah arah karakter
	public void CurrentSide()
	{
		if (leftSide)
		{
			transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
		}
		else
		{
			transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
		}
	}
}
