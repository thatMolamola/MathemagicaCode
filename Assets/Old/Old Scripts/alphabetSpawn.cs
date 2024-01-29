using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphabetSpawn : MonoBehaviour
{
    public GameObject prefab; 
    private GameObject letter;
    private char[] alpha;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        for (var i = 0; i < 26; i++)
        {
            GameObject letter = Instantiate(prefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            letter.transform.SetParent(gameObject.transform, false);
            letter.GetComponent<UnityEngine.UI.Text>().text = alpha[i].ToString();
            letter.GetComponent<Rigidbody2D>().velocity = RandomUnitVector() * speed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public Vector2 RandomUnitVector()
    {
        float random = Random.Range(0f, 260f);
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }
}
