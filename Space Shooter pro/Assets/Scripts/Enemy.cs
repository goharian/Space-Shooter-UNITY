using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 meters pre sec
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        

        //if bottom of screen
        if (transform.position.y < -5.5f)
        {
            //respawn at top (bunos: with a new random x position)
            float randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(randomX, 7.0f, 0);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            Player player = other.transform.GetComponent<Player>();
            if(player != null){
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Laser")){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
