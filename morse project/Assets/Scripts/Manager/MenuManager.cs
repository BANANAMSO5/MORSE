using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuManager : IMenuManager
{
    public Canvas _pausePanel;
    private bool isPaused = false;

    [Inject]
    public void Construct(Canvas pausePanel)
    {
        _pausePanel = pausePanel;
    }

    public void SwitchMenuMode()
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

    private void Pause()
    {
        _pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0f; // ゲーム停止
        isPaused = true;
    }

    private void Resume()
    {
        _pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1f; // 再開
        isPaused = false;
    }
}
