using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public GameObject bulletBoss;
    private SpriteRenderer sprite;
	Rigidbody2D rb;
    private float fireRate = 0.5f, nextFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
		
    }
    // Update is called once per frame
    void Update()
	{
		Vector3 pos = transform.position;
		Vector3 posPlayer = player.transform.position;
		if (posPlayer.x <= 13) {
			sprite.flipX = true;
		}

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (sprite.flipX == true) {
				if (pos.x - posPlayer.x < 12) {
					Vector3 posBullet = transform.position;
					pos.x -= 1.5f;
					Instantiate(bulletBoss, posBullet, Quaternion.Euler(new Vector3(0, 0, 180)));
				}
			}
		}
		if (posPlayer.x > 13) {
			sprite.flipX = false;
		}
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (sprite.flipX == false) {
				if (posPlayer.x - pos.x < 12) {
					Vector3 posBullet = transform.position;
					pos.x += 1.5f;
					Instantiate(bulletBoss, posBullet, Quaternion.Euler(new Vector3(0, 0, 0)));
				}
			}
		}
	}
	
}
