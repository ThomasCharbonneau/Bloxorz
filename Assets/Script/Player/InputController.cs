using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
     [SerializeField] Player _player = default;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _player.MovePlayer(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _player.MovePlayer(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _player.MovePlayer(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _player.MovePlayer(-1, 0);
        }
    }
}
