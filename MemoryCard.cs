using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{


public int id;
public float targetHeight = 0.11f;
public float targetRotation = -90;  



    public void OnMouseDown() {
        FindObjectOfType<Game_Manager>().CardClicked(this);
        
    }
    public void Awake() {
        targetHeight = 0.01f;
        targetRotation = -90;
    }
    public void Update() {
        float heightValue = Mathf.MoveTowards(transform.position.y, targetHeight, 1 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, heightValue, transform.position.z);

        //rotate x
        Quaternion rotationValue = Quaternion.Euler(targetRotation, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationValue, 10 * Time.deltaTime);

    }

}
