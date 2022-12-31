using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public float rotationAmount = .9f;
    public float delaySpeed = .001f;
    private bool isRotating = false;

    public GameManager gameManager;
    public CurrentSide currentSide;

    // Update is called once per frame
    void Update()
    {
        if(isRotating) {
            return;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            StartCoroutine(SlowSpin(new Vector3(0, -rotationAmount, 0)));
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            StartCoroutine(SlowSpin(new Vector3(0, rotationAmount, 0)));
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            StartCoroutine(SlowSpin(new Vector3(rotationAmount, 0, 0)));
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            StartCoroutine(SlowSpin(new Vector3(-rotationAmount, 0, 0)));
        }
    }

    IEnumerator SlowSpin(Vector3 vector){
        float count = 0;
        isRotating = true;
        while(count <= 90){
            gameObject.transform.Rotate(vector, Space.World);
            count += rotationAmount;

            if(count >= 90) {
                isRotating = false;
            }
            yield return new WaitForSeconds(delaySpeed);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")) {
            int number = other.gameObject.GetComponent<Enemy>().currentNumber;
            Destroy(other.gameObject);
            Debug.Log(number + " - " + currentSide.side);
            gameManager.score.text = (int.Parse(gameManager.score.text) + (number == currentSide.side ? 1 : -1)).ToString();
        }
        
    }

}
