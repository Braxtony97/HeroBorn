 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
        public GameBehavior gg;

        void Start()
        {
        gg = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        }

        void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {
                Destroy(this.transform.parent.gameObject);
                Debug.Log("Item collected!");
                gg.Items += 1;
                
            }
        }
    
}

