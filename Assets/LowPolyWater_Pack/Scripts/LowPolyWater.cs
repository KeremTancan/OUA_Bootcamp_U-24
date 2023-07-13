using UnityEngine;

namespace LowPolyWater
{
    public class LowPolyWater : MonoBehaviour
    {
        public float waveHeight = 0.5f;
        public float waveFrequency = 0.5f;
        public float waveLength = 0.75f;

        // Position where the waves originate from
        public Vector3 waveOriginPosition = new Vector3(0.0f, 0.0f, 0.0f);

        private MeshFilter meshFilter;
        private Mesh mesh;
        private Vector3[] vertices;

        private void Awake()
        {
            // Get the Mesh Filter of the gameobject
            meshFilter = GetComponent<MeshFilter>();
        }

        private void Start()
        {
            CreateMeshLowPoly(meshFilter);
        }

        /// <summary>
        /// Rearranges the mesh vertices to create a 'low poly' effect
        /// </summary>
        /// <param name="mf">Mesh filter of the gameobject</param>
        private void CreateMeshLowPoly(MeshFilter mf)
        {
            mesh = mf.sharedMesh;

            // Get the original vertices of the gameobject's mesh
            Vector3[] originalVertices = mesh.vertices;

            // Get the list of triangle indices of the gameobject's mesh
            int[] triangles = mesh.triangles;

            // Create a vector array for new vertices
            vertices = new Vector3[triangles.Length];

            // Assign vertices to create triangles out of the mesh
            for (int i = 0; i < triangles.Length; i++)
            {
                vertices[i] = originalVertices[triangles[i]];
                triangles[i] = i;
            }

            // Update the gameobject's mesh with new vertices
            mesh.vertices = vertices;
            mesh.SetTriangles(triangles, 0);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            this.vertices = mesh.vertices;
        }

        private void Update()
        {
            GenerateWaves();
        }

        /// <summary>
        /// Based on the specified wave height and frequency, generate 
        /// wave motion originating from waveOriginPosition
        /// </summary>
        private void GenerateWaves()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v = vertices[i];

                // Initially set the wave height to 0
                v.y = 0.0f;

                // Get the distance between wave origin position and the current vertex
                float distance = Vector3.Distance(v, waveOriginPosition);
                distance = (distance % waveLength) / waveLength;

                // Oscillate the wave height via sine to create a wave effect
                v.y = waveHeight * Mathf.Sin(Time.time * Mathf.PI * 2.0f * waveFrequency + (Mathf.PI * 2.0f * distance));

                // Update the vertex
                vertices[i] = v;
            }

            // Update the mesh properties
            mesh.vertices = vertices;
            mesh.RecalculateNormals();
            mesh.MarkDynamic();
            meshFilter.mesh = mesh;
        }

        private void OnTriggerEnter(Collider other)
        {
            // Check if the collided object should be able to swim
            if (other.CompareTag("SwimObject"))
            {
                // Add swimming behavior to the object
                Rigidbody swimObjectRigidbody = other.GetComponent<Rigidbody>();
                if (swimObjectRigidbody != null)
                {
                    swimObjectRigidbody.useGravity = false;
                    swimObjectRigidbody.drag = 2f;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // Check if the object is no longer colliding with the water
            if (other.CompareTag("SwimObject"))
            {
                // Remove swimming behavior from the object
                Rigidbody swimObjectRigidbody = other.GetComponent<Rigidbody>();
                if (swimObjectRigidbody != null)
                {
                    swimObjectRigidbody.useGravity = true;
                    swimObjectRigidbody.drag = 0f;
                }
            }
        }
    }
}
