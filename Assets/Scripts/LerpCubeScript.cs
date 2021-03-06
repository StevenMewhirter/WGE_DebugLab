﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCubeScript : MonoBehaviour {

    public GameObject _cube;
    public Vector3 _leftPosition;
    public Vector3 _rightPosition;

    public void StartLerp()
    {
        _cube.transform.position = _leftPosition;
        StartCoroutine(LerpCube());
    }
    public override string ToString()
    {
        string s;
        s = (_cube ? "Cube positon = " + _cube.transform.position : "Cube not instantiated ") + "\n"
+ "Left Position = " + _leftPosition + "\n" + "Right Poistion = " + _rightPosition;
        return s;
    }

    IEnumerator LerpCube()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            Debug.Log(t);
            _cube.transform.position = Vector3.Lerp(_leftPosition, _rightPosition, t);
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            if (t >=1)
            {
                _cube.transform.position = _rightPosition;
            }
            stopWatch.Stop();
            Debug.Log("Time taken: " + (stopWatch.Elapsed));
            yield return null;
        }

    }

    public void PrintDebugString()
    {
        Debug.Log(this.ToString());
    }
   
}
