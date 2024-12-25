using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotHandler : MonoBehaviour
{
    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;

    [Header("Transform References")]
    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _rightStartPosition;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;

    [Header("SlingShot Stats")]
    [SerializeField] private float _maxDistance = 3.5f;

    [Header("Scripts")]
    [SerializeField] private SlingShotArea _slingShotArea;

    [Header("Bird")]
    [SerializeField] private GameObject _angieBirdPrefab;


    private Vector2 _slingShotLinesPosition;

    private bool _clickedWithinArea;

    private void Awake()
    {
        _leftLineRenderer.enabled = false;
        _rightLineRenderer.enabled = false;

        SpawnAngieBird();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed && _slingShotArea.IsWithinSlingshotArea())
        {
            _clickedWithinArea = true;
// || = or
        }

        if(Mouse.current.leftButton.isPressed && _clickedWithinArea)
        {
            DrawSlingShot();
    // short for _clickedWithinArea == true
        }

        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            _clickedWithinArea = false;
        }
    }

    #region SlingShot Methods

    private void DrawSlingShot()
    {
        if(!_leftLineRenderer.enabled && !_rightLineRenderer.enabled)
        {
            _leftLineRenderer.enabled = true;
            _rightLineRenderer.enabled = true;
        }
// enabled laat een bool werken ig
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        _slingShotLinesPosition = _centerPosition.position + Vector3.ClampMagnitude(touchPosition - _centerPosition.position, _maxDistance);

        SetLines(_slingShotLinesPosition);
    }
// de touchPosition wordt hier dus je Vector2 die je vervolgens gebruikt voor de Setposition van leftLineRendere en rightLineRenderer
    private void SetLines(Vector2 position)
    {
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);
        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position);
    }

#endregion

    #region Angie Bird Methods
    private void SpawnAngieBird();
    {
        SetLines(_idlePosition.position)
        Instantiate(_angieBirdPrefab)
    }
    #endregion
}
