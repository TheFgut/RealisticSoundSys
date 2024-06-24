using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSystem : MonoBehaviour
{
    [SerializeField] private Frame[] frames;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region drawing gizmos
    void OnDrawGizmos()
    {
        foreach (Frame frame in frames)
        {
            Vector3[] points = frame.positions;
            if (points == null) return;

            DrawFrameBounds(points);
            DrawFrameConnections(frame);
        }
    }

    private void DrawFrameBounds(Vector3[] points)
    {

        Vector3 firstP = points[0];
        Vector3 point = firstP;
        for (int i = 1; i < points.Length; i++)
        {
            Debug.DrawLine(point, points[i], Color.red);
            point = points[i];
        }
        Debug.DrawLine(point, firstP, Color.red);
    }

    private void DrawFrameConnections(Frame frame)
    {
        foreach(Frame connection in frame.connections)
        {
            Debug.DrawLine(frame.center, connection.center, Color.red);
        }
    }
    #endregion

    [System.Serializable]
    public class Frame
    {
        [SerializeField] private Vector3[] _positions;
        [SerializeField] private List<Frame> _connections = new List<Frame>();
        public Frame[] connections => _connections.ToArray();
        public Vector3[] positions => _positions;
        public Vector3 center
        {
            get
            {
                if (_positions == null) return Vector3.zero;
                Vector3 sum = Vector3.zero;
                foreach (Vector3 pos in _positions)
                {
                    sum += pos;
                }
                return sum / _positions.Length;
            }
        }

        public void Connect(Frame frame)
        {
            _connections.Add(frame);
        }

        public Frame()
        {
            _positions = new Vector3[] { new Vector3(1,0), new Vector3(-1, 0), new Vector3(-1, 2), new Vector3(2, 0) };
        }
    }
}
