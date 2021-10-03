using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    public Transform player;
    Vector3 tempVec3 = new Vector3();
    private float offset = 0.5f;
    public Text ScorePanel;
    public Text FinalScorePanel;
    private float InitialYPosition;
    private float PreviousYPosition;
    private float score = 0f;


    public void ResetScore()
    {
        score = 0f;
    }
    void Start()
    {
        InitialYPosition = this.transform.position.y;
        PreviousYPosition = this.transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if ((player.position.y + offset) > this.transform.position.y)
        {
            tempVec3.y = player.position.y + offset;
        }
        else tempVec3.y = this.transform.position.y;

        tempVec3.x = this.transform.position.x;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;

        if (PreviousYPosition < this.transform.position.y)
        {
            score += (this.transform.position.y - PreviousYPosition) * 1000;
            PreviousYPosition = this.transform.position.y;

            ScorePanel.text = "Score: " + Mathf.Floor(score);
            FinalScorePanel.text = "Score: " + Mathf.Floor(score);
        }
    }

    public void resetPosition() {
        this.transform.position = new Vector3(0, InitialYPosition, -10);
    }
}
