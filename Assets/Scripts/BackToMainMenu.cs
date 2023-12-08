using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public Button m_button;
	public int scene = 0;

    void Start()
    {
        m_button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}