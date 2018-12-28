using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
	public Ninja player;

	private void Start()
	{
		Input.multiTouchEnabled = true;
	}
	
	private void Update ()
	{
		//	Mengubah arah hadap karakter
		player.CurrentSide();

		if(player.transform.position.x == Vector3.zero.x)
		{
			player.Idle();
		}

		if ( (EventSystem.current.IsPointerOverGameObject() || Input.touchCount > 0) || Input.anyKeyDown )
		{
			//	Bergerak kekanan / kekiri
			if ((EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.leftBtn.name && Input.GetMouseButton(0)) || Input.GetKey(KeyCode.LeftArrow) )
			{
				player.leftSide = true;
				Controller.Instance.Move(player.GetComponent<Transform>(), UIManager.Instance.Movebtn(), player.GetSpeed());
				if (Mathf.Abs(player.transform.position.x) > 0.001f)
				{
					player.Run();
				}
			}
			else if ((EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.rightBtn.name && Input.GetMouseButton(0)) || Input.GetKey(KeyCode.RightArrow))
			{
				player.leftSide = false;
				Controller.Instance.Move(player.GetComponent<Transform>(), UIManager.Instance.Movebtn(), player.GetSpeed());
				if (Mathf.Abs(player.transform.position.x) > 0.001f)
				{
					player.Run();
				}
			}

			//	Melompat, meluncur, menyerang, melempar kunai
			//	Melompat
			if ((Input.GetMouseButtonDown(0) && (EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.jumpBtn.name)) || Input.GetKey(KeyCode.Space))
			{
				Controller.Instance.Move(player.GetComponent<Transform>(), UIManager.Instance.JumpBtn(), player.GetSpeed());
				if (Mathf.Abs(UIManager.Instance.targetPosition.y) > Vector3.zero.y)
				{
					Controller.Instance.Jump(player.GetComponent<Transform>(), player.GetHighJump());
					if ((EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.attackBtn.name) || Input.GetKey(KeyCode.A))
					{
						player.JumpAttack();
					}
					else if ((EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.throwBtn.name) || Input.GetKey(KeyCode.RightShift))
					{
						player.JumpThrow();
					}
					else
					{
						player.Jump();
					}
				}
			}
			//	Meluncur
			else if ((Input.GetMouseButtonDown(0) && (EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.slideBtn.name)) || Input.GetKey(KeyCode.LeftShift))
			{
				Controller.Instance.Slide(player.GetComponent<Transform>(), UIManager.Instance.Movebtn(), player.GetSlideSpeed());
				player.Slide();
			}
			//	Menyerang
			if ((Input.GetMouseButtonDown(0) && (EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.attackBtn.name)) || Input.GetKey(KeyCode.A))
			{
				player.Attack();
			}
			//	Melempar kunai
			else if ((Input.GetMouseButtonDown(0) && (EventSystem.current.currentSelectedGameObject.name == UIManager.Instance.throwBtn.name)) || Input.GetKey(KeyCode.RightShift))
			{
				player.Throw();
			}
		}
		else
		{
			Controller.Instance.Move(player.GetComponent<Transform>(), Vector3.zero, 0f);
		}
	}
	//	Event untuk button isi kiri
	private void LeftController()
	{

	}
	//	Event untuk button sisi kanan
	private void RightController()
	{

	}
}
