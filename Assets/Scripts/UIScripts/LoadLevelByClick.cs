using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelByClick : MonoBehaviour
{
	[SerializeField] private int level;

    public void LoadLevel()
    {
        Application.LoadLevel(level);
    }
}
