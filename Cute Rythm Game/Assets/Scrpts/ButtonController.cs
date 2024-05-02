using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    public Sprite buttondefault;
    public Sprite buttonpressed;
    public KeyCode keytopress;
    private Bloom bloom;
    private float targetBloomIntensity = 0f;
    private float currentBloomIntensity = 0f;
    public float bloomChangeSpeed = 10f;

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keytopress))
        {
            spriterenderer.sprite = buttonpressed;
            targetBloomIntensity = 50f;
        }
        if (Input.GetKeyUp(keytopress))
        {
            spriterenderer.sprite = buttondefault;
            targetBloomIntensity = 0f;
        }
        currentBloomIntensity = Mathf.MoveTowards(currentBloomIntensity, targetBloomIntensity, bloomChangeSpeed * Time.deltaTime);
        bloom.intensity.value = currentBloomIntensity;  
    }
}
