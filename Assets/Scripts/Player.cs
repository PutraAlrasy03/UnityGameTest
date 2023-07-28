using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private float _scaleChangeRate = 11f; // Rate of scale change when pressing 'q' or 'e'

    private Vector3 _currentScaleDirection = Vector3.one; // Used to store the scaling direction

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
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
            _currentScaleDirection = Vector3.one;
            transform.localScale = new Vector3(
                Mathf.Lerp(transform.localScale.x, transform.localScale.x + _scaleChangeRate, Time.deltaTime),
                Mathf.Lerp(transform.localScale.y, transform.localScale.y + _scaleChangeRate, Time.deltaTime),
                Mathf.Lerp(transform.localScale.z, transform.localScale.z + _scaleChangeRate, Time.deltaTime));

            Debug.Log($"Scale factor x: {transform.localScale.x}");
        }

        // Check if 'e' key is held down to make the cube smaller
        if (Input.GetKey(KeyCode.E))
        {
            _currentScaleDirection = -Vector3.one;
            transform.localScale = new Vector3(
                Mathf.Lerp(transform.localScale.x, transform.localScale.x + (_currentScaleDirection.x * _scaleChangeRate), Time.deltaTime),
                Mathf.Lerp(transform.localScale.y, transform.localScale.y + (_currentScaleDirection.y * _scaleChangeRate), Time.deltaTime),
                Mathf.Lerp(transform.localScale.z, transform.localScale.z + (_currentScaleDirection.z * _scaleChangeRate), Time.deltaTime));

            // Ensure the cube's scale doesn't go below zero
            transform.localScale = Vector3.Max(transform.localScale, Vector3.zero);

            Debug.Log($"Scale factor x: {transform.localScale.x}");
        }
    }
}
