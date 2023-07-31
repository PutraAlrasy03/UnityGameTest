using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private float _scaleChangeRate = 11f; // Rate of scale change when pressing 'q'

    [SerializeField]
    private float _scaleChangeRateE = 6f; // Rate of scale change when pressing 'e'

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // Check if 'q' key is held down to make the cube bigger
        if (Input.GetKey(KeyCode.Q))
        {
            ScaleCube(_scaleChangeRate);
        }

        // Check if 'e' key is held down to make the cube smaller
        if (Input.GetKey(KeyCode.E))
        {
            ScaleCube(-_scaleChangeRateE);
        }

        // Check if '1' key is pressed to change the color to red
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeColor(Color.red);
        }

        // Check if '2' key is pressed to change the color to blue
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeColor(Color.blue);
        }
    }

    private void ScaleCube(float scaleChangeRate)
    {
        // Calculate the new scale based on the current scale and the scale change rate
        Vector3 newScale = transform.localScale + (Vector3.one * scaleChangeRate * Time.deltaTime);

        // Ensure the new scale does not go below zero
        transform.localScale = Vector3.Max(newScale, Vector3.zero);
    }

    private void ChangeColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newColor;
        }
    }
}
