﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public float Radius = 2.0f;
    public Vector3[] pointA;

    public float Length {
        get {
            return pointA.Length;
        }
    }

    public Vector3 GetPoint(int index)
    {
        return pointA[index];
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < pointA.Length; i++)
        {
            if (i + 1 < pointA.Length)
            {
                Debug.DrawLine(pointA[i], pointA[i + 1], Color.red);
            }   
        }
    }
}
