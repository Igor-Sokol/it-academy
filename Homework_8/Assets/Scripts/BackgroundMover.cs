using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private float _xPositionOffset;
    
    [SerializeField] private float objectLength;
    [SerializeField] private float speed;
    [SerializeField] private Player player;

    private void Update()
    {
        int direction = player.Direction * -1;
        
        float newXPositionOffset = direction * speed * Time.deltaTime;
        _xPositionOffset += newXPositionOffset;
        transform.position += new Vector3(newXPositionOffset, 0, 0);

        if (_xPositionOffset * direction >= objectLength)
        {
            transform.position -= new Vector3(objectLength * direction, 0, 0);
            _xPositionOffset -= objectLength * direction;
        }
    }
}
