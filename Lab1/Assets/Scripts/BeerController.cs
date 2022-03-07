using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerController : MonoBehaviour
{
    public GameObject ball;
    float m_spawTime;
    public float spawTime;
    
    private bool m_isGameOver;
    PlayerController m_pc;
    // Start is called before the first frame update
    void Start()
    {
        m_spawTime = 0;
        m_pc = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if (m_isGameOver) {
            m_spawTime = 0;
            return;
		}
        m_spawTime -= Time.deltaTime;
        if (m_spawTime <= 0) {
            SpawBall();
            m_spawTime = spawTime;
        }
    }
    public void SpawBall()
	{
        Vector2 spawpos = new Vector2(Random.Range(-8.2f, 4f), 6.2f);
		if (ball) {
            Instantiate(ball, spawpos, Quaternion.identity);
		}
	}
}
