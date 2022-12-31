using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Enemy : MonoBehaviour
{
    Transform player;
    public float MoveSpeed = 4;
    public int currentNumber;
    public TextMesh text;
    // Start is called before the first frame update
    void Awake() 
    {

        currentNumber = Random.Range(1,6);
        text.text = currentNumber.ToString();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        var step =  MoveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, player.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            player.position *= -1.0f;
        }
    }
}
