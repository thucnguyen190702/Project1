using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArrays = new Sprite[5];
    PlayerController m_pc;
    public AudioClip au_clip;
    public AudioClip au_clipWin;
    public GameObject winGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_pc = FindObjectOfType<PlayerController>();
        winGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (m_pc.point == 2000) {
            spriteRenderer.sprite = spriteArrays[1];
            m_pc.au_source.PlayOneShot(au_clip);
        }else if (m_pc.point == 4000) {
            spriteRenderer.sprite = spriteArrays[2];
            m_pc.au_source.PlayOneShot(au_clip);
        } else if (m_pc.point == 6000) {
            spriteRenderer.sprite = spriteArrays[3];
            m_pc.au_source.PlayOneShot(au_clip);
        } else if (m_pc.point == 8000) {
            spriteRenderer.sprite = spriteArrays[4];
            m_pc.au_source.PlayOneShot(au_clip);
        } else if (m_pc.point == 10000) {
            m_pc.au_source.PlayOneShot(au_clipWin);
            winGamePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
