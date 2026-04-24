using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // ゲーム停止
        isPaused = true;
    }

    void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // 再開
        isPaused = false;
    }
}
