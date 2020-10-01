using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player main;
    private Vector3 lastTouchPlace;
    private Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public float borderX;

    // Start is called before the first frame update
    void Awake()
    {
        main = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastTouchPlace = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Helper.IsIdle() && Input.GetMouseButtonDown(0) && Helper.IsNotOnUI())
        {
            GameManager.main.ChangeGameState(GameStates.Playing);
            LevelManager.main.InitLevel(Level.Restart);
        }

        if (Helper.IsPlaying())
        {
            if (Input.GetMouseButton(0))
            {
                MoveHorizontally();
            }
        }

        // These can be UI function if needed.
        if (Helper.IsWin() && Input.GetMouseButtonDown(0))
        {
            LevelManager.main.InitLevel(Level.Pass);
            GameManager.main.ChangeGameState(GameStates.Playing);
        }
        if (Helper.IsFail() && Input.GetMouseButtonDown(0))
        {
            LevelManager.main.InitLevel(Level.Restart);
            GameManager.main.ChangeGameState(GameStates.Playing);
        }
    }

    void MoveHorizontally()
    {
        if (lastTouchPlace == Input.mousePosition)
            return;

        Vector3 dir = new Vector3(((Input.mousePosition - lastTouchPlace).x), 0, 0);
        float magnitude = dir.magnitude% maxSpeed;
        dir = dir.normalized;

        if (Mathf.Abs((transform.position + dir * magnitude * speed * Time.deltaTime).x) < borderX)
            rb.MovePosition(transform.position + dir *magnitude* speed * Time.deltaTime);
        lastTouchPlace = Input.mousePosition;
    }


}
