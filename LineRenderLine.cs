using UnityEngine;

public class LineRendererLine {
    private LineRenderer line;
    public LineRendererLine(Vector3 start, Vector3 end, Material ink
        , float width) {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.startWidth = width;
        line.endWidth = width;
        line.positionCount = 2;
        line.material = ink;
        line.SetPositions(new Vector3[] { start, end });
    }
    public Vector3 EndPoint {
        set { line.SetPosition(1, value); }
        get { return line.GetPosition(1); }
    }
    public Vector3 StartPoint {
        set { line.SetPosition(0, value); }
        get { return line.GetPosition(0); }
    }
    public float Length(){
        Vector3 v = line.GetPosition(0) - line.GetPosition(1);
        return v.magnitude;
    }
}

