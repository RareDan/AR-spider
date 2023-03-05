using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpiderMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform gamePad;
    public float moveSpeed = 0.5f;
    private GameObject arObject;
    private Vector3 move;
    private bool walking;

    void Start()
    {
        arObject = GameObject.FindGameObjectWithTag("Spider");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;

        //Vector2 gamePadPosXY = gamePad.position;//new Vector2(gamePad.position.x, gamePad.position.y);
        transform.localPosition = Vector2.ClampMagnitude
            (eventData.position - (Vector2)gamePad.position, 
            gamePad.rect.width * 0.5f);
        //Find length of vector between points eventData.position and gamePad.position
        //Return vector with length less than gamePad.rect.width * 0.5f
        //Debug.Log(transform.localPosition);

        move = new Vector3(
            transform.localPosition.x, 
            0, 
            transform.localPosition.y
        ).normalized;

        if(!walking)
        {
            walking = true;
            arObject.GetComponent<Animator>().SetBool("Walk", true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PlayerMovement());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;

        move = Vector3.zero;
        StopCoroutine(PlayerMovement());
        walking = false;
        arObject.GetComponent<Animator>().SetBool("Walk", false);
    }

    IEnumerator PlayerMovement()
    {
        while (true)
        {
            arObject.transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if(move != Vector3.zero)
            {
                arObject.transform.rotation = Quaternion.Slerp(
                    arObject.transform.rotation,
                    Quaternion.LookRotation(move),
                    Time.deltaTime * 5
                );
            }

            yield return null;
        }
    }
}
