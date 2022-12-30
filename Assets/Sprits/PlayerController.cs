using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1.0f;
    public float RotationSpeed = 1.0f;
    private Rigidbody gravedad;
    public float JumpForce = 1.0f;
    AudioSource[] audioSources;
    AudioSource audioSalto;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gravedad = GetComponent<Rigidbody>();

        audioSources = GetComponents<AudioSource>();
        audioSalto = audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);
    
        //Rotacion
        float rotacionY = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0, rotacionY * Time.deltaTime * RotationSpeed, 0));
    
        //Salto
        if(Input.GetKeyDown(KeyCode.Space)) {
            gravedad.AddForce(new Vector3(0,JumpForce,0), ForceMode.Impulse);
            audioSalto.Play();
        }else{
            audioSalto.Pause();
        }
    }
}
