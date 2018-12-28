using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	private static Controller instance;

	public static Controller Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<Controller>();
			}
			return instance;
		}
	}
	
	//	Menggerakkan karakter
	public void Move(Transform _target, Vector3 _direction, float _speed)
	{
		_target.Translate(_direction * _speed * Time.deltaTime);
	}
	//	Karakter melompat
	public void Jump(Transform _target, float _high)
	{
		_target.position += Vector3.up * _high;
	}
	//	Karakter meluncur
	public void Slide(Transform _target, Vector3 _direction, float _speed)
	{
		_target.Translate(_direction * _speed);
	}
}
