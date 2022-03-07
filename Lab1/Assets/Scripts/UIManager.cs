using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void ShowGameOver(bool isShow)
	{
		if (gameOverPanel) {
			gameOverPanel.SetActive(isShow);
		}
	}
}
