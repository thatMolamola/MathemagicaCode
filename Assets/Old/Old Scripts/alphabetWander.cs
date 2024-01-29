using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphabetWander : MonoBehaviour
{
    public Transform alphabet;
    public Transform alphabetRB;
    Vector2 direction;
    float speed;

    
    // Start is called before the first frame update
    void Start()
    {
        speed = 50.0f;
        for (int i=0; i< alphabet.childCount; i++) {
            var direction = Random.insideUnitCircle.normalized;
            var oneChild = alphabet.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
            oneChild.velocity = speed * direction;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
