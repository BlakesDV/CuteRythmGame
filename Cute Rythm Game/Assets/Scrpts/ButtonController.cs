using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public VolumeProfile volumeProfile;
    private Bloom bloom;
    private float targetBloomIntensity = 0f;
    private float currentBloomIntensity = 0f;
    public float bloomChangeSpeed = 10f;

    void Start()
    {
        if (!volumeProfile)
        {
            Debug.LogError("Volume Profile not assigned!");
            enabled = false;
            return;
        }

        volumeProfile.TryGet(out bloom);
        if (bloom == null)
        {
            Debug.LogError("Bloom not found in the Volume Profile!");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetBloomIntensity = 50f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            targetBloomIntensity = 0f;
        }

        currentBloomIntensity = Mathf.MoveTowards(currentBloomIntensity, targetBloomIntensity, bloomChangeSpeed * Time.deltaTime);
        bloom.intensity.value = currentBloomIntensity;
    }

    //private SpriteRenderer spriteRenderer;
    //public Sprite buttonDefault;
    //public Sprite buttonPressed;
    //public KeyCode keyToPress;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(keyToPress))
    //    {
    //        spriteRenderer.sprite = buttonPressed;
    //    }
    //    if (Input.GetKeyUp(keyToPress))
    //    {
    //        spriteRenderer.sprite = buttonDefault;
    //    }
    //}
}
