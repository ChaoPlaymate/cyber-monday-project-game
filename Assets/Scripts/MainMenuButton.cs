using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public Button m_button;
	public int scene;

    void Start()
    {
        m_button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}