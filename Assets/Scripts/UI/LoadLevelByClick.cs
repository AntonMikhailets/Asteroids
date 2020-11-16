using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevelByClick : MonoBehaviour
{
	[SerializeField] private int _level = 0;

    public void LoadLevel()
    {
         SceneManager.LoadScene(_level);
    }
}
