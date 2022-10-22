using System;
using System.Linq;
using UnityEngine;

public class Cube
{
    private readonly Mesh _mesh;
    public Mesh Mesh => _mesh;

    public Cube(Vector3 scale)
    {
        _mesh = Cube.GenerateMesh(scale);
    }

    public void MoveSide(Side side, Vector3 offset)
    {
        int[] verticesIndex;
        switch (side)
        {
            case Side.Up:
                verticesIndex = new int[] { 4, 5, 6, 7 };
                break;
            case Side.Down:
                verticesIndex = new int[] { 0, 1, 2, 3 };
                break;
            case Side.Right:
                verticesIndex = new int[] { 1, 2, 5, 6 };
                break;
            case Side.Left:
                verticesIndex = new int[] { 0, 3, 4, 7 };
                break;
            case Side.Forward:
                verticesIndex = new int[] { 2, 3, 6, 7 };
                break;
            case Side.Back:
                verticesIndex = new int[] { 0, 1, 4, 5 };
                break;
            default:
                throw new ArgumentException("Side not found.", nameof(side));
        }

        Vector3[] tempVertices = _mesh.vertices;
        foreach (var index in verticesIndex)
        {
            tempVertices[index] += offset;
        }

        _mesh.vertices = tempVertices;
    }

    public Vector3 CenterPivot()
    {
        Vector3[] temp = _mesh.vertices;
        Vector3 offset = default;
        
        foreach (var vector3 in temp)
        {
            offset += vector3;
        }

        offset /= temp.Length;
        
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] -= offset;
        }

        _mesh.vertices = temp;

        return offset;
    }
    
    private static Mesh GenerateMesh(Vector3 scale)
    {
        Vector3[] vertices = new[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // 0
            new Vector3(0.5f, -0.5f, -0.5f), // 1
            new Vector3(0.5f, -0.5f, 0.5f), // 2
            new Vector3(-0.5f, -0.5f, 0.5f), // 3
            new Vector3(-0.5f, 0.5f, -0.5f), // 4
            new Vector3(0.5f, 0.5f, -0.5f), // 5
            new Vector3(0.5f, 0.5f, 0.5f), // 6
            new Vector3(-0.5f, 0.5f, 0.5f), // 7
        };
        
        int[] triangles = new[]
        {
            3, 0, 1,
            3, 1, 2,
            0, 4, 5,
            0, 5, 1,
            1, 5, 6,
            1, 6, 2,
            2, 6, 7,
            2, 7, 3,
            3, 7, 4,
            3, 4, 0,
            4, 7, 6,
            4, 6, 5,
        };
        
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = Vector3.Scale(vertices[i], scale);
        }

        Mesh mesh = new Mesh()
        {
            vertices = vertices,
            triangles = triangles,
        };
        mesh.RecalculateNormals();
        return mesh;
    }
    
    public enum Side
    {
        Up,
        Down,
        Right,
        Left,
        Forward,
        Back,
    }
}
