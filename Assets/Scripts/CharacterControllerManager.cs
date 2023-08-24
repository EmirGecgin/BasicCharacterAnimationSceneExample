using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterControllerManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed=1,_speedTurn=100, _runSpeed;
    [SerializeField] private GameObject _character;
    [SerializeField] private TextMeshProUGUI _coinText;
    private int coin;
    [SerializeField] private GameObject _panel;

    void Start()
    {
        coin = 0;
        _coinText.text = "COIN= 0";
    }
    void Update()
    {
        
        Movement();
    }

    
    private void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * _speedTurn;
        transform.Rotate(Vector3.up * horizontalMovement);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * _runSpeed;
            transform.Translate(0, 0, verticalMovement);

            _animator.SetBool("isRunning", true);
        }

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            _animator.SetBool("isRunning", false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            Time.timeScale = 0;
            Destroy(_character);
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coin+=1;
            _coinText.text = "COIN= " + coin;
            if (coin >= 2)
            {
                Time.timeScale = 0;
                _panel.gameObject.SetActive(true);
            }
        }
    }
    


}
