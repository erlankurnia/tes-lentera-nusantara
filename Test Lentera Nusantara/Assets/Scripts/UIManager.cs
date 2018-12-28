using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private static UIManager instance;
	public static UIManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<UIManager>();
			}
			return instance;
		}
	}

	public Vector3 targetPosition { get; private set; }
	public Button leftBtn, rightBtn, jumpBtn, slideBtn, attackBtn, throwBtn;

	//	Arah gerakan
	public Vector3 Movebtn()
	{
		targetPosition = Vector3.right;
		return Vector3.right;
	}
	public Vector3 JumpBtn()
	{
		targetPosition = Vector3.up;
		return Vector3.up;
	}
}
