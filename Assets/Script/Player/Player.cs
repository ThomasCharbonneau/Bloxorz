using System.Collections;
using UnityEngine;

public class Player : Entity
{
    private enum PlayerDirection
    {
        North,
        South,
        West,
        East,
        Neutral
    }

    private float _row = 0;
    private float _column = 0;
    private bool _movementLocked = true;
    private PlayerDirection _currentDirection = PlayerDirection.Neutral;

    private Vector2 _initialPosition = default;

    private static Player _player = null;
    public static Player Instance()
    {
        return _player;
    }

    public void Awake()
    {
        _player = this;
    }

    public void ResetPosition()
    {
        _row = (int)_initialPosition.x;
        _column = (int)_initialPosition.y;

        switch (_currentDirection)
        {
            case PlayerDirection.North:
            case PlayerDirection.South:
            case PlayerDirection.East:
            case PlayerDirection.West:
                // If the player was laying down when he died, reset the Y coordinate for the standing position
                gameObject.transform.position = new Vector3(_row, gameObject.transform.position.y + 0.5f, _column);
                break;
            case PlayerDirection.Neutral:
                gameObject.transform.position = new Vector3(_row, gameObject.transform.position.y, _column);
                break;
        }

        _currentDirection = PlayerDirection.Neutral;
    }

    public void SetInitialPosition(int x, int y)
    {
        _initialPosition = new Vector2(x, y);
        _row = x;
        _column = y;
        gameObject.transform.position = new Vector3(_row, gameObject.transform.position.y, _column);
        StartCoroutine(SpawnPlayer());
    }
    
    public void MovePlayer(float x, float y)
    {
        if (!_movementLocked)
        {
            Vector3 rotationPoint =  Vector3.zero;
            switch (_currentDirection)
            {
                case PlayerDirection.North:
                case PlayerDirection.South:
                    rotationPoint = new Vector3(x != 0 ? transform.position.x + 0.5f * x : transform.position.x, transform.position.y - 0.5f, y != 0 ? transform.position.z + 1f * y : transform.position.z);
                    y += 0.5f * y;
                    _currentDirection = y != 0 ? PlayerDirection.Neutral : _currentDirection;
                    break;
                case PlayerDirection.East:
                case PlayerDirection.West:
                    rotationPoint = new Vector3(x != 0 ? transform.position.x + 1f * x : transform.position.x, transform.position.y - 0.5f, y != 0 ? transform.position.z + 0.5f * y : transform.position.z);
                    x += 0.5f * x;
                    _currentDirection = x != 0 ? PlayerDirection.Neutral : _currentDirection;
                    break;
                case PlayerDirection.Neutral:
                    rotationPoint = new Vector3(x != 0 ? transform.position.x + 0.5f * x : transform.position.x, transform.position.y - 1f, y != 0 ? transform.position.z + 0.5f * y : transform.position.z);
                    if (x == 1)
                    {
                        _currentDirection = PlayerDirection.East;
                    }
                    else if (x == -1)
                    {
                        _currentDirection = PlayerDirection.West;
                    }
                    else if (y == 1)
                    {
                        _currentDirection = PlayerDirection.North;
                    }
                    else if (y == -1)
                    {
                        _currentDirection = PlayerDirection.South;
                    }
                    x += 0.5f * x;
                    y += 0.5f * y;
                    break;
            }

            Vector3 rotationAxis = Vector3.zero;
            if (x != 0)
            {
                rotationAxis = new Vector3(0, 0, 1);
            } 
            else
            {
                rotationAxis = y > 0 ? Vector3.right : Vector3.left;
            }

            int angle = x > 0 ? -90 : 90;
            transform.RotateAround(rotationPoint, rotationAxis, angle);

            _row += x;
            _column += y;
            int currentRow = (int)_row;
            int currentColumn = (int)_column;

            if (_column % 1 != 0)
            {
                GameScene.CurrentLevel.BoardTiles[currentRow][currentColumn].OnPressed();
                GameScene.CurrentLevel.BoardTiles[currentRow][currentColumn + 1].OnPressed();
            }
            else if (_row % 1 != 0)
            {
                GameScene.CurrentLevel.BoardTiles[currentRow][currentColumn].OnPressed();
                GameScene.CurrentLevel.BoardTiles[currentRow + 1][currentColumn].OnPressed();
            }
            else
            {
                GameScene.CurrentLevel.BoardTiles[currentRow][currentColumn].OnStand();
            }
        }
    }

    public IEnumerator OnDeath()
    {
        _movementLocked = true;
        transform.rotation = Quaternion.identity;
        float animationLength = _entityAnimatorController.PlayAnimation(EntityAnimatorController.AnimationAction.Death);
        yield return new WaitForSeconds(animationLength);
        ResetPosition();
        StartCoroutine(SpawnPlayer());
    }

    public IEnumerator SpawnPlayer()
    {
        float animationLength = _entityAnimatorController.PlayAnimation(EntityAnimatorController.AnimationAction.Spawn);
        yield return new WaitForSeconds(animationLength);
        _movementLocked = false;
    }
}
