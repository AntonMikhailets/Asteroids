using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image HealthImage;
    public int _health;
    public List<Image> HealthImages;

    public void ShowHealth(int newHealth)
    {
    	if(_health < newHealth)
    	{
    		//создаем иконки
    		for(int i =_health; i < newHealth; i++)
    		{
    			Image newHealthImage = Instantiate (HealthImage, transform.position, transform.rotation);
    			newHealthImage.gameObject.transform.transform.SetParent(gameObject.transform);
    			HealthImages.Add(newHealthImage);
    		}
    	}else{
    		if(_health > newHealth)
    		{
    			//удаляем иконки
    			for(int i =_health; i > newHealth; i--)
    			{
    				if(HealthImages.Count > 0)
    				{
    					Destroy((HealthImages[0]).gameObject);
    					HealthImages.Remove(HealthImages[0]);
    				}
    			}
    		}
    	}
    	_health = newHealth;
    }

    public int Health
    {
    	set{
    		_health = value;
    	}
    }
}
