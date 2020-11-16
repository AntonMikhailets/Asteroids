using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private int health;
    [SerializeField] private List<Image> healthImages;

    public void ShowHealth(int newHealth)
    {
    	if(health < newHealth)
    	{
    		//создание иконок при изменении параметра health в большую сторону
            if(newHealth > 0)
            {
    		  for(int i = health; i < newHealth; i++)
    		  {
    			Image newHealthImage = Instantiate (healthImage, transform.position, transform.rotation);
    			newHealthImage.gameObject.transform.transform.SetParent(gameObject.transform);
    			healthImages.Add(newHealthImage);
    		  }
            }
    	}else{
    		if(health > newHealth)
    		{
    			//удаление иконки при получение урона
    			for(int i = health; i > newHealth; i--)
    			{
    				if(healthImages.Count != 0)
    				{
    					Destroy((healthImages[0]).gameObject);
    					healthImages.Remove(healthImages[0]);
    				}
    			}
    		}
    	}
    	health = newHealth;
    }

    public int Health
    {
    	set{
    		health = value;
    	}
    }

    /*#region MonoBehaviour

    private void OnValidate()
    {
        if(health < 0) health = 0;
    }

    #endregion */
}
