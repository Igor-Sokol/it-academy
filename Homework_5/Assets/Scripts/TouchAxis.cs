using UnityEngine;
using UnityEngine.EventSystems;

public class TouchAxis : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 _previousPosition;
    private bool _isDrag;
    private int _touchId;
    public Vector2 Axis { get; private set; }

    private void Update()
    {
        if (_isDrag)
        {
            Touch touch = Input.GetTouch(_touchId);

            Axis = (_previousPosition - touch.position) * -1;
            _previousPosition = touch.position;
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        _touchId = eventData.pointerId;
        _previousPosition = eventData.position;
        _isDrag = true;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        _isDrag = false;
        Axis = Vector2.zero;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
    }
}
