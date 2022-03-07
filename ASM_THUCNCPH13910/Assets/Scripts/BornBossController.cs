using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BornBossController : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    private SpriteRenderer sprite;
    private float fireRate = 0.5f, nextFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 posBoss = transform.position;
        Vector3 posPlayer = player.transform.position;
        if (posBoss.x - posPlayer.x < 15) {
            sprite.flipX = true;
            if (Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                    Instantiate(boss, transform.position, Quaternion.identity);
            }
        }
    }
}
