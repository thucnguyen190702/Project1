using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosssssss : MonoBehaviour
{
    
   
    public GameObject boss2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
        

    }
	private void Update()
	{
        transform.Translate(Vector3.right * 10 * Time.deltaTime);
    }
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Wall1")) {
            boss2.SetActive(true);
            gameObject.SetActive(false);
		}
	}
}
