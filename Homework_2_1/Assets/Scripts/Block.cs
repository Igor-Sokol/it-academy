using UnityEngine;
using UnityEngine.Serialization;

public class Block : MonoBehaviour
{
    private (MeshFilter filter, MeshCollider collider, Cube cube) _savedPart;
    private (MeshFilter filter, MeshCollider collider, Cube cube) _cutPart;

    [SerializeField] private float speed;
    [FormerlySerializedAs("direction")] [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 scale;
    [SerializeField] public GameObject savedPart;
    [SerializeField] private GameObject cutPart;

    public float Speed { get => speed; set => speed = value; }
    public Vector3 Scale { get => scale; set => scale = value; }
    public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }

    private void Start()
    {
        _savedPart = (savedPart.GetComponent<MeshFilter>(), savedPart.GetComponent<MeshCollider>(), new Cube(scale));
        _savedPart.filter.mesh = _savedPart.cube.Mesh;
        _savedPart.collider.sharedMesh = _savedPart.cube.Mesh;
        
        _cutPart = (cutPart.GetComponent<MeshFilter>(), cutPart.GetComponent<MeshCollider>(), new Cube(scale));
        _cutPart.filter.mesh = _cutPart.cube.Mesh;
        _cutPart.collider.sharedMesh = _cutPart.cube.Mesh;
    }

    private void Update()
    {
        transform.position += moveDirection * (Time.deltaTime * speed);
    }
    
    public void Cut(Vector3 center)
    {
        speed = 0f;

        Vector3 offsetPosition = transform.position - center;

        float rawCutSize = offsetPosition.x + offsetPosition.z;
        bool crossedPrevious = rawCutSize > 0;
        float cutSize = Mathf.Abs(rawCutSize);

        if (cutSize > scale.z)
        {
            savedPart.SetActive(false);
            cutPart.SetActive(true);
            return;
        }
        
        if (!crossedPrevious)
        {
            _savedPart.cube.MoveSide(Cube.Side.Back, new Vector3(0, 0, cutSize));
            _cutPart.cube.MoveSide(Cube.Side.Forward, new Vector3(0, 0, -(scale.z - cutSize)));
        }
        else
        {
            _savedPart.cube.MoveSide(Cube.Side.Forward, new Vector3(0, 0, -cutSize));
            _cutPart.cube.MoveSide(Cube.Side.Back, new Vector3(0, 0, (scale.z - cutSize)));
        }
        
        savedPart.transform.localPosition += _savedPart.cube.CenterPivot();
        cutPart.transform.localPosition += _cutPart.cube.CenterPivot();
        
        scale += new Vector3(0, 0, -cutSize);
        
        _savedPart.collider.sharedMesh = _savedPart.cube.Mesh;
        cutPart.SetActive(true);
    }
}
