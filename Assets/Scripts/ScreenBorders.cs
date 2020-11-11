using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorders : MonoBehaviour
{
	[SerializeField] private float screenTop;
	[SerializeField] private float screenBottom;
	[SerializeField] private float screenLeft;
	[SerializeField] private float screenRight;

	private void Update()
	{
		BorderCheck();
	}

	public void BorderCheck()
	{
		Vector2 spaceshipPos = transform.position;

  		if(transform.position.y > screenTop)
  		{
  			spaceshipPos.y = screenBottom;
  		}

  		if(transform.position.y < screenBottom)
  		{
  			spaceshipPos.y = screenTop;
  		}

  		if(transform.position.x < screenLeft)
  		{
  			spaceshipPos.x = screenRight;
  		}

  		if(transform.position.x > screenRight)
  		{
  			spaceshipPos.x = screenLeft;
  		}

  		transform.position = spaceshipPos;
	}
}
