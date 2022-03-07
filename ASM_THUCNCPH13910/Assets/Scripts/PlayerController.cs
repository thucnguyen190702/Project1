using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float jumpSpeed;
	public LayerMask groundLayer;
	public GameObject bullet;
	public GameObject bullet1;
	public GameObject fruit1;
	public GameObject fruit2;
	public GameObject fruit3;
	public GameObject fruit4;
	public GameObject bulletTransform;
	public GameObject gameOver;
	public GameObject paticle;
	public int hitNumbers;
	int hitNumbersBoss=0;
	int hitBoss=0;
	public AudioClip m_clip;
	public AudioClip m_clipJump;
	public AudioSource m_as;

	Image img1, img2, img3;
	bool isRight;
	bool isGround;
	bool isJump;
	//[SerializeField] bool isGround;
	//[SerializeField] Transform tranformGroundChecks;
	//const float groundCheckRadius = 0.2f;
	Rigidbody2D m_rb;
	Animator ani;
	SpriteRenderer sp;
	float fireRate = 0.2f, nextFire = 0;
	public int point = 0;
	public float max;
	
	//Collider2D[] colliders;

    void Start()
    {	
		isRight = true;
		isGround = true;
		isJump = true;
		m_rb = gameObject.GetComponent<Rigidbody2D>();
		ani = gameObject.GetComponent<Animator>();
		sp = gameObject.GetComponent<SpriteRenderer>();
		img1 = GameObject.Find("Heart1").GetComponent<Image>();
		img2 = GameObject.Find("Heart2").GetComponent<Image>();
		img3 = GameObject.Find("Heart3").GetComponent<Image>();
		gameOver.SetActive(false);
    }
	//void GroundCheck()
	//{
	//	isGround = false;
	//	colliders = Physics2D.OverlapCircleAll(tranformGroundChecks.position, groundCheckRadius, groundLayer);
	//	if (colliders.Length > 0) {
	//		isGround = true;
	//	}
	//}
    // Update is called once per frame
    void Update()
    {

		Vector3 vt = transform.position;
		var movement = Input.GetAxis("Horizontal");
		if (Input.GetKey(KeyCode.UpArrow) ) {
			if (isGround) {
				m_as.PlayOneShot(m_clipJump);
				Debug.Log("Ban dang an nut nhay");
				m_rb.velocity = Vector2.up * jumpSpeed;
				ani.SetBool("Run", false);
				ani.SetBool("Idle", false);
				ani.SetBool("Jump", true);
				ani.SetBool("Crouch", false);

				isGround = false;
			}
			//else {
			//	if (vt.y > max) {
			//		vt.y = max;
			//		Debug.Log(vt.y);
			//		for(int i = 0; i < 3; i++) {
			//			Thread.Sleep(TimeSpan.FromSeconds(1));
			//			m_rb.gravityScale = 0;
			//		}
			//		m_rb.gravityScale = 13;
			//	}
			//}
			
		}
		
		transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * runSpeed;

		if (movement == 0) {
			ani.SetBool("Run", false);
			ani.SetBool("Idle", true);
			ani.SetBool("Jump", false);
			ani.SetBool("Crouch", false);

		} else if (Input.GetKey(KeyCode.DownArrow)) {
			ani.SetBool("Run", false);
			ani.SetBool("Idle", false);
			ani.SetBool("Jump", false);
			ani.SetBool("Crouch", true);
		} else {
			
			ani.SetBool("Run", true);
			ani.SetBool("Idle", false);
			ani.SetBool("Jump", false);
			ani.SetBool("Crouch", false);
		}
		//ani.SetFloat("Speed", Mathf.Abs(movement));
		if (movement > 0 && !isRight) {
			Flip();
		}
		if (movement < 0 && isRight) {
			Flip();
		}
		
		//if (isGround) {
		//	ani.SetBool("Run", false);
		//	ani.SetBool("Idle", true);
		//	ani.SetBool("Jump", false);
		//	ani.SetBool("Crouch", false);
		//} else {
		//	ani.SetBool("Run", false);
		//	ani.SetBool("Idle", false);
		//	ani.SetBool("Jump", true);
		//	ani.SetBool("Crouch", false);
		//}
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(m_as  && m_clip) {
				m_as.PlayOneShot(m_clip);
			}
			
			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				if (transform.localScale.x < 0) {
					Instantiate(bullet, bulletTransform.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
				} else if (transform.localScale.x > 0) {
					Instantiate(bullet, bulletTransform.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

				}
			}
		}

		if (Input.GetKeyDown(KeyCode.P) && isJump) {
			m_rb.velocity = Vector2.up * (jumpSpeed*2);
			isJump = false;
		}
		if (Input.GetKeyDown(KeyCode.P) && !isJump) {
			m_rb.velocity = Vector2.up * jumpSpeed;
			isJump = true;
		}



		// ban len troi
		if (Input.GetKeyDown(KeyCode.K)) {
			Instantiate(bullet1, transform.position, Quaternion.identity);
			bullet1.transform.Translate(Vector3.up * 10 * Time.deltaTime);
			//m_rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
		}
		//random 30 boss
		if (Input.GetKeyDown(KeyCode.M)) {
			for (int i = 0; i < 12; i++) {
				RanDomBoss();
			}
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			gameObject.SetActive(false);
			Instantiate(paticle, transform.position, Quaternion.identity);
		}
		////xoay 90'
		//if (Input.GetKeyDown(KeyCode.L)) {
		//	transform.Rotate(new Vector3(0, 0, 90));
		//} else if (Input.GetKeyUp(KeyCode.L)) {
		//	transform.Rotate(new Vector3(0, 0, -90));
		//}
		////zooom
		//if (Input.GetKeyDown(KeyCode.O)) {
		//	transform.localScale= new Vector3(2,2,2);
		//} else if (Input.GetKeyUp(KeyCode.O)) {
		//	transform.localScale = new Vector3(1, 1, 1);
		//}
	}
	void Flip()
	{
		isRight = !isRight;
		Vector3 vector = transform.localScale;
		vector.x *= -1;
		transform.localScale = vector;
	}
	//private void OnCollisionEnter2D(Collision2D col)
	//{
	//	if (col.gameObject.CompareTag("Wall1")) {
	//		m_rb.bodyType = RigidbodyType2D.Static;
	//	} else {
	//		m_rb.bodyType = RigidbodyType2D.Dynamic;
	//	}
	//}
	void RanDomBoss()
	{
		Vector2 spawBoss = new Vector2(UnityEngine.Random.Range(-17f, 17f), 13f);
		Instantiate(fruit1, spawBoss, Quaternion.identity);
		Instantiate(fruit2, spawBoss, Quaternion.identity);
		Instantiate(fruit3, spawBoss, Quaternion.identity);
		Instantiate(fruit4, spawBoss, Quaternion.identity);
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Wall")) {
			isGround = true;
		}
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("FireBoss")) {
			hitNumbersBoss += 1;
			Debug.Log(hitNumbersBoss);
			if (hitNumbersBoss == 3) {
				Destroy(this.img3);
			}else if (hitNumbersBoss == 6) {
				Destroy(this.img2);
			} else if (hitNumbersBoss == 9) {
				Destroy(this.img1);
				gameOver.SetActive(true);
				Time.timeScale = 0f;
			}
		}
		if (col.gameObject.CompareTag("Bullet2")) {
			Destroy(col.gameObject);
		}
		if (col.gameObject.CompareTag("Boss")) {
			hitBoss += 1;
			Debug.Log(hitBoss);
			if (hitBoss == 1) {
				Destroy(this.img3);
			} else if (hitBoss == 2) {
				Destroy(this.img2);
			} else if (hitBoss == 3) {
				Destroy(this.img1);
				gameOver.SetActive(true);
				Time.timeScale = 0f;
			}
		}
		if (col.gameObject.CompareTag("Boss2")) {
			hitBoss += 1;
			Debug.Log(hitBoss);
			if (hitBoss == 1) {
				Destroy(this.img3);
			} else if (hitBoss == 2) {
				Destroy(this.img2);
			} else if (hitBoss == 3) {
				Destroy(this.img1);
				gameOver.SetActive(true);
				Time.timeScale = 0f;
			}
		}
		if (col.gameObject.CompareTag("Box")) {
			
		}
	}
	public void Reload()
	{
		SceneManager.LoadScene("Game");
		Time.timeScale = 1f;
	}
}
