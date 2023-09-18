using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class Virus : MonoBehaviour
{
    // public float moveDistance = 4.0f;
    // public LayerMask obstacleLayer;
        public int life = 4;
    public LayerMask obstacleLayer;
    public LayerMask foodLayer;
     public LayerMask endLayer;
    public float moveDistance = 4.0f;
    public Vector3 plateAPosition; 
    public Vector3 plateBPosition; 
    public Vector3 cameraOffset;
    public TextMeshProUGUI endGameText;
    //  public Transform playerTransform;  // Reference to the player's Transform
    // public Transform endPoint;  
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
         float moveX = 0.0f;
        float moveZ = 0.0f;

        if (Input.GetKeyDown(KeyCode.UpArrow)) moveZ = moveDistance;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) moveZ = -moveDistance;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) moveX = -moveDistance;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) moveX = moveDistance;

        Vector3 targetPosition = transform.position + new Vector3(moveX, 0, moveZ);
        if(moveX==0.0&&moveZ==0.0){
            return;
        }

        if (!Physics.Raycast(transform.position, new Vector3(moveX, 0, moveZ), moveDistance, obstacleLayer))
        {
            transform.position = targetPosition;
            life--;
            Debug.Log("Life: " + life);
            Debug.Log(gameObject.name + " Position: " + transform.position);
        }
        if (Vector3.Distance(transform.position, plateAPosition) < 0.5f)
                {
                    transform.position = plateBPosition; // Transport to plate B
                     Camera.main.transform.position = transform.position + cameraOffset;
                     Debug.Log(gameObject.name + " Position: " + transform.position);
                }

        Collider[] foodColliders = Physics.OverlapSphere(targetPosition, 0.5f, foodLayer);
        foreach (Collider food in foodColliders)
        {
            Destroy(food.gameObject);
            life += 3;
            Debug.Log("Food collected! Life: " + life);
        }
        Collider[] endColliders = Physics.OverlapSphere(targetPosition, 3.0f, endLayer);
        if(endColliders!=null){
            PlayerWon();
            return;
        }
        if(life<=0){
            PlayerLost();
            return;
        }
    }
     public void PlayerWon()
    {  Debug.Log("You Win!!! ");
        endGameText.text = "You Win!";
    }

    public void PlayerLost()
    {Debug.Log("You Lose!!! ");
        endGameText.text = "You Lose!";
    }
}
