using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed;
    public int point = 0;
    public Text pointText;
    public AudioClip au_clip;
    public AudioSource au_source;
    
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "Score:" + point;
        
    }

    // Update is called once per frame
    void Update()
    {   
        float movement = Input.GetAxisRaw("Horizontal");
		
        if(transform.position.x <= -7.1f && movement < 0 || transform.position.x >= 2.9f && movement > 0) {
            return;
		}
        if (movement != 0) {
            transform.position += new Vector3(movement, 0, 0) * moveSpeed * Time.deltaTime;
        }
    }
	private void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.CompareTag("Beer")) {
            if(au_source && au_clip) {
                au_source.PlayOneShot(au_clip);
			}
            point += 200;
            pointText.text = "Score:" + point;
            Destroy(col.gameObject);
        }
    }
}
