

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float forwardSpeed= 5000f,strafeSpeed=7.5f, hoverSpeed=5f;
    private float activeForwardSpeed,activeStrafeSpeed,activeHoverSpeed;
    private float forwardAcceleration=2.5f,strafeAcceleration=2f,hoverAcceleration=2f;
    public float lookRateSpeed=90f;
    private Vector2 lookInput,screenCentre,mouseDistance; 

    // Start is called before the first frame update
    void Start()
    {
        screenCentre.x = Screen.width * .5f;
        screenCentre.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance,1f);

        mouseDistance.x = (lookInput.x - screenCentre.x) / screenCentre.x ;
        mouseDistance.y = (lookInput.y - screenCentre.y) / screenCentre.y;

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime,0f, Space.Self);


        activeForwardSpeed= Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical")*forwardSpeed,forwardAcceleration*Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal")*strafeSpeed,strafeAcceleration*Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover")*hoverSpeed,hoverAcceleration*Time.deltaTime);
        transform.position+=transform.forward*activeForwardSpeed* Time.deltaTime;
        transform.position+=transform.right*activeStrafeSpeed*Time.deltaTime;
        transform.position+=transform.up*activeHoverSpeed*Time.deltaTime;
    }
}
