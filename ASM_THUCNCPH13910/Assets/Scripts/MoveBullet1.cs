using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 vtold;
    public GameObject bullet2;
    void Start()
    {
        vtold = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vtnew = transform.position;
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
        if(vtnew.y - vtold.y > 13) {
            Instantiate(bullet2, transform.position, Quaternion.identity);
            bullet2.transform.Translate(Vector3.down * 10 * Time.deltaTime);
            Destroy(gameObject);
		}
    }
}
