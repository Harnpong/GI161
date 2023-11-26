using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    public int PlayerScore { get { return playerScore; }set{playerScore = value;} }
    [SerializeField] 
    private GameObject ballPrefab;
    
    [SerializeField] private GameObject[] ballPositions;
    [SerializeField] private GameObject cueBall;
    [SerializeField] private float xInput;
    [SerializeField] private GameObject ballLine;
    [SerializeField] private GameObject camera;
    
    public static GameManager Instance;
    
    public Ball myBall; 
    
// Start is called before the first frame update
    void Start()
    {
        Instance = this;

        camera = Camera.main.gameObject;
        CameraBehindCueBall();
        
        SetBall(BallColor.White, 0); 
        SetBall(BallColor.Red, 1);  
        SetBall(BallColor.Red, 2);  
        SetBall(BallColor.Red, 3);  
        SetBall(BallColor.Red, 4);
        SetBall(BallColor.Red, 5);  
        SetBall(BallColor.Red, 6);  
        SetBall(BallColor.Yellow, 7);
        SetBall(BallColor.Green, 8);
        SetBall(BallColor.Brown, 9);
        SetBall(BallColor.Blue, 10);
        SetBall(BallColor.Pink, 11);
        SetBall(BallColor.Black, 12);
       
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();
        if(Input.GetKeyDown(KeyCode.W))ShootBall();
        if (Input.GetKeyDown(KeyCode.S))StopBall();
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab,
            ballPositions[i].transform.position,Quaternion.identity);
        
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void ShootBall()
    {
        camera.transform.parent = null;
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
        ballLine.SetActive(false);
    }

    private void CameraBehindCueBall()
    {
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(0f, 15f, -20f);
    }

    private void StopBall()
    {
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;
        
        CameraBehindCueBall();
        camera.transform.eulerAngles = new Vector3(30f, 0f, 0f);
        ballLine.SetActive(true);
    }
}