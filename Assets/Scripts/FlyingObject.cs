using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Image))]
public class FlyingObject : MonoBehaviour
{
  private float screenTop;
  private float screenBottom;
  private float screenLeft;
  private float screenRight;

  //private Rigidbody2D rigidbody;
  private RectTransform Image;

  void Start()
  {
    SetBordersAndPrivateObjects();
  }


  public void SetBordersAndPrivateObjects()
  {
      //rigidbody = gameObject.GetComponent<Rigidbody2D>();
      Image = gameObject.GetComponent<RectTransform>();

      Vector2 size = Image.sizeDelta;

      screenTop = Screen.height/2f + size.y/2f;
      screenBottom = -screenTop;
      screenRight = Screen.width/2f + size.x/2f;
      screenLeft = -screenRight;
  }

	private void Update()
	{
		BorderCheck();
	}

	public void BorderCheck()
	{
		Vector2 spaceshipPos = transform.localPosition;

  		if(transform.localPosition.y > screenTop)
  		{
  			spaceshipPos.y = screenBottom;
  		}

  		if(transform.localPosition.y < screenBottom)
  		{
  			spaceshipPos.y = screenTop;
  		}

  		if(transform.localPosition.x < screenLeft)
  		{
  			spaceshipPos.x = screenRight;
  		}

  		if(transform.localPosition.x > screenRight)
  		{
  			spaceshipPos.x = screenLeft;
  		}

  		transform.localPosition = spaceshipPos;
	}
}
