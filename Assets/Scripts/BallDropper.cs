using UnityEngine;
using UnityEngine.InputSystem;

public class BallDropper : MonoBehaviour
{
    public GameObject BallPrefab; // capitalize public variables
    
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            DropBall();
        }
    }

    private void DropBall()
    {
        // pick a starting position
        Vector3 spawnPosition = GetSpawnPosition();
        
        // create ball at that position
        GameObject ball = Instantiate(BallPrefab, spawnPosition,
            Quaternion.identity); //what to create, where to create it, how to rotate it ?
        
        //Add Horizontal Force
        AddRandomForce(ball);
    }

    private void AddRandomForce(GameObject ball)
    {
        Rigidbody2D rigidbody = ball.GetComponent<Rigidbody2D>();

        float RandomHorizontalForce = Random.Range(-4f, 4f);
        rigidbody.AddForce(new Vector2(RandomHorizontalForce, 0), ForceMode2D.Impulse);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));
        
        float randomX = Random.Range(leftEdge.x + 1, rightEdge.x - 1);
        
        Vector3 spawnPosition = new Vector3(randomX ,4.5f, 0f);
        
        return spawnPosition;
    }
}
