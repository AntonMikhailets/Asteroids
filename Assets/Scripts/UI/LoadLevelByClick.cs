using UnityEngine;

public class LoadLevelByClick : MonoBehaviour
{
	[SerializeField] private int _level;

    public void LoadLevel()
    {
        Application.LoadLevel(_level);
    }
}
