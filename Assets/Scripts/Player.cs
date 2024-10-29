using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    public GameObject _laserPrefab;

    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private float _canFire = -1f;


    // Start is called before the first frame update
    void Start()
    {
        //take current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + fireRate;

            Instantiate(_laserPrefab, transform.position + new Vector3(0, .78f, 0), Quaternion.identity);
            
        }
    }

    void CalculateMovement()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction* _speed * Time.deltaTime);

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, 0);
        }
        else if (transform.position.y <= -3.88f)
        {
             transform.position = new Vector3(transform.position.x, -3.88f, 0);
        }

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }

        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
