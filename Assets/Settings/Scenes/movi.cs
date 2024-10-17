using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movi : MonoBehaviour
{
    [SerializeField] private RawImage bgImg;
    [SerializeField] private float xSpeed, ySpeed;
    private void Update()
    {
        bgImg.uvRect = new Rect(bgImg.uvRect.position + new Vector2(xSpeed, ySpeed) * Time.deltaTime,
            bgImg.uvRect.size);
    }
}