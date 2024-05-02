using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BloomController : MonoBehaviour
{
    public KeyCode bloomToggleKey;

    private PostProcessVolume postProcessVolume;
    private Bloom bloomLayer;
 
    private void Start()
    {
        // Get the Post Process Volume component
        postProcessVolume = GetComponent<PostProcessVolume>();

        // Check if Post Process Volume exists
        if (postProcessVolume != null)
        {
            // Check if Bloom effect exists
            if (postProcessVolume.profile.TryGetSettings(out bloomLayer))
            {
                // Disable bloom initially
                bloomLayer.enabled.value = false;
            }
            else
            {
                Debug.LogWarning("Bloom effect not found in the Post Processing stack.");
            }
        }
        else
        {
            Debug.LogWarning("Post Processing Volume not found on this object.");
        }
    }

    private void Update()
    {
        // Turn on bloom effect when the specified key is pressed
        if (Input.GetKeyDown(bloomToggleKey))
        {
            EnableBloom();
        }
        // Turn off bloom effect when the specified key is released
        else if (Input.GetKeyUp(bloomToggleKey))
        {
            DisableBloom();
        }
    }

    private void EnableBloom()
    {
        // Enable bloom effect
        if (bloomLayer != null)
        {
            bloomLayer.enabled.value = true;
        }
    }

    private void DisableBloom()
    {
        // Disable bloom effect
        if (bloomLayer != null)
        {
            bloomLayer.enabled.value = false;
        }
    }
}
