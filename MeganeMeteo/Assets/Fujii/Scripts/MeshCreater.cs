using UnityEngine;

/// <summary> メッシュの作成をする静的クラス </summary>
public static class MeshCreater
{
    /// <summary> 扇形のメッシュを作成します。 </summary>
    /// <param name="radian"> 角度(弧度法) </param>
    /// <param name="triangleCount"> メッシュを構築する三角形プリミティブの数 </param>
    public static Mesh CreateSectorMesh(float radian, int triangleCount)
    {
        var mesh = new Mesh();
        mesh.vertices = CreateSectorVertexBuffer(radian, triangleCount);
        mesh.triangles = CreateSectorIndexBuffer(triangleCount);
        mesh.RecalculateNormals();
        return mesh;
    }

    /// <summary> 扇形のインデックスバッファを作成します。 </summary>
    /// <param name="triangleCount"> インデックスバッファを構築する三角形プリミティブの数 </param>
    private static int[] CreateSectorIndexBuffer(int triangleCount)
    {
        int[] indexBuffer = new int[triangleCount * 6];

        for (int i = 0; i < triangleCount; i++) {
            int frontIndex = i * 3;
            int backIndex = triangleCount * 3 + frontIndex;

            // 表面
            indexBuffer[frontIndex + 1] = i + 1;
            indexBuffer[frontIndex + 2] = i + 2;

            // 裏面
            indexBuffer[backIndex + 1] = i + 2;
            indexBuffer[backIndex + 2] = i + 1;
        }
        return indexBuffer;
    }

    /// <summary> 扇形のメッシュを作成します。 </summary>
    private static Vector3[] CreateSectorVertexBuffer(float radian, int triangleCount)
    {
        Vector3[] vertexBuffer = new Vector3[triangleCount + 2];

        vertexBuffer[0] = Vector3.zero;

        float startRad = -radian / 2;
        float angleStep = radian / triangleCount;

        for (int i = 0; i < triangleCount + 1; i++) {
            float nowRad = (startRad + angleStep * i);
            vertexBuffer[i + 1] = new Vector3(Mathf.Sin(nowRad), 0f, Mathf.Cos(nowRad));
        }
        return vertexBuffer;
    }
}