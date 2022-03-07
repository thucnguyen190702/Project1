using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    
    public GameObject fire;
    public GameObject fizeBin;
    //public Text textScore;
    PlayerController m_cl;
    public GameObject posBoss;
    public GameObject fireBoss;
    public AudioClip au_clip;
    // Start is called before the first frame update
    void Start()
    {
        
        m_cl = FindObjectOfType<PlayerController>();
        Destroy(gameObject, 1.3f);
        //textScore.text = "Score:" + m_cl.point;
    }

    // Update is called once per frame
    void Update()
    {
        


    }
	private void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.CompareTag("Wall")) {
            Debug.Log("Bullet move out wall");
            Destroy(gameObject);
			//Destroy(col.gameObject);
			Instantiate(fire, transform.position, Quaternion.identity);
		}
        if (col.gameObject.CompareTag("Bin")) {
            Debug.Log("Bullet move out wall");
           
            m_cl.hitNumbers++;
            if(m_cl.hitNumbers % 3 == 0) {
                Destroy(col.gameObject);
                m_cl.point += 10;
                Text textScore = GameObject.Find("ScoreText").GetComponent<Text>();
                textScore.text = "Score:" + m_cl.point;
                if(au_clip && m_cl.m_as) {
                    m_cl.m_as.PlayOneShot(au_clip);
                }
                Instantiate(fizeBin, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
			Instantiate(fire, transform.position, Quaternion.identity);
        }
        if (col.gameObject.CompareTag("Wall1")) {
            Debug.Log("Bullet move out wall1");
            Destroy(gameObject);
            //Destroy(col.gameObject);
            Instantiate(fire, transform.position, Quaternion.identity);
        }
        if (col.gameObject.CompareTag("Boss") || col.gameObject.CompareTag("Boss2")) {
            Debug.Log("Bullet move out boss");
            m_cl.hitNumbers++;
            if (m_cl.hitNumbers % 2 == 0) {
                Destroy(col.gameObject);
                Instantiate(fireBoss, transform.position, Quaternion.identity);
                m_cl.point += 20;
                Text textScore = GameObject.Find("ScoreText").GetComponent<Text>();
                textScore.text = "Score:" + m_cl.point;
                
                
            }
            Destroy(gameObject);
            //Destroy(col.gameObject);
            Instantiate(fire, transform.position, Quaternion.identity);
        }
    }
}
