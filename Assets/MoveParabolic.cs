using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParabolic : MonoBehaviour
{
    private Vector3 StartPosition;
    public Vector3 EndPosition;
    public float height;
    public float Duration;
    private float startTime;
    public GameObject Targetprefab;

    /*void Start()
    {
      
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            startTime = Time.time;
            EndPosition = new Vector3(Random.Range(35, -35), Random.Range(35, -35), Random.Range(8, -18));

            GameObject destinationPoint = Instantiate(Targetprefab, EndPosition, Quaternion.identity); // clone of the cube Object

            Destroy(destinationPoint, Duration);// destory the clone cube
        }

        float timeFraction = Mathf.Clamp01((Time.time - startTime) / Duration);
        float currentheight = height*(timeFraction - timeFraction * timeFraction);
        //move Object smooth position
        transform.position = Vector3.Lerp(StartPosition, EndPosition, timeFraction) + Vector3.up * currentheight;

        

        if (transform.position == EndPosition)// sphere position start from cube always when we press "space" keyword... 
        {
            StartPosition = EndPosition;
        }

    }
}