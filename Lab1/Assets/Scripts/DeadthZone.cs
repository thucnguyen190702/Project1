using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadthZone : MonoBehaviour
{
    public GameObject heart1, heart2, heart3;
    int upBeer = 3;
    public GameObject gameOverPanel;
    PlayerController m_pc;
    public AudioClip au_fall;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        m_pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Beer")) {
            upBeer -= 1;
            if(upBeer == 2) {
                m_pc.au_source.PlayOneShot(au_fall);
                Destroy(heart3);
			}else if (upBeer == 1) {
                m_pc.au_source.PlayOneShot(au_fall);
                Destroy(heart2);
            }
            if (upBeer == 0) {
                Destroy(heart1);
                m_pc.au_source.PlayOneShot(au_fall);
                gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
               
			}
            Debug.Log(upBeer);
		}
	}
    public void Replay()
    {
        SceneManager.LoadScene("Lab7");
        Time.timeScale = 1f;
    }

    public void OutGame()
	{
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
