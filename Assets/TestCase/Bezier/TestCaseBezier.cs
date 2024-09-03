using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestCaseBezier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        var p1 = new Vector3(x, y, 0);
        var p2 = new Vector3(x - 20, y + 200);
        var p3 = new Vector3(x + 180, y + 220);
        var p4 = new Vector3(x + 400, y);
        Debug.DrawLine(p1,p2,Color.green);
        Debug.DrawLine(p2,p3,Color.green);
        Debug.DrawLine(p3,p4,Color.green);

        var ctrlPos = new List<Vector3>();
        ctrlPos.Add(p1);
        ctrlPos.Add(p2);
        ctrlPos.Add(p3);
        ctrlPos.Add(p4);

        var result = ToolsBezier.GetBezierPos(ctrlPos, 30);
        for (int i = 0; i < result.Count - 1; i++)
        {
            Debug.DrawLine(result[i], result[i + 1], Color.red);
        }

        var temp = result.ToArray();
        transform.DOPath(temp, 3f).SetLookAt(0, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
