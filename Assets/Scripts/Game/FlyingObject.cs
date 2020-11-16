using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class FlyingObject : MonoBehaviour
{
  private float _screenTop;
  private float _screenBottom;
  private float _screenLeft;
  private float _screenRight;
  private RectTransform _rectTransform;

  private void Start()
  {
    SetBordersAndPrivateObjects();
  }
   
  public void SetBordersAndPrivateObjects()
  {
      _rectTransform = gameObject.GetComponent<RectTransform>();
      Vector2 size = _rectTransform.sizeDelta;
      Vector2 scale = transform.localScale;

      _screenTop = Screen.height * 0.5f + size.y * 0.5f * scale.y;
      _screenBottom = -_screenTop;
      _screenRight = Screen.width * 0.5f + size.x * 0.5f * scale.x;
      _screenLeft = -_screenRight;
  }

	public virtual void Update()
	{
		BorderCheck();
	}

	public void BorderCheck()
	{
		Vector2 spaceshipPos = transform.localPosition;

  		if(transform.localPosition.y > _screenTop)
  		{
  			spaceshipPos.y = _screenBottom;
  		}

  		if(transform.localPosition.y < _screenBottom)
  		{
  			spaceshipPos.y = _screenTop;
  		}

  		if(transform.localPosition.x < _screenLeft)
  		{
        HorizontalBorder();
  			spaceshipPos.x = _screenRight;
  		}

  		if(transform.localPosition.x > _screenRight)
  		{
         HorizontalBorder();
  			spaceshipPos.x = _screenLeft;
  		}

  		transform.localPosition = spaceshipPos;
	}

  public virtual void HorizontalBorder(){}

}
