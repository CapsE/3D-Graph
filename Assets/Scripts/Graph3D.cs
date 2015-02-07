using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Graph3D : Graph {

	void Start () {
		for(int i = 0; i < 10; i++){
			for(int h = 0; h < 10; h++){
				fields.Add(new Field(new Vector3(i*scale,Random.Range(0,10), h*scale), 1, "aaaaaa"));
			}
		}
		UpdateMesh();
	}

	public void UpdateMesh(){
		List<Vector3> verts = new List<Vector3>();
		
		List<int> triangles = new List<int>();
		List<Color> colors = new List<Color>();
		int counter = 0;
		Vector3 max = new Vector3(0,0,0);
		
		foreach(Field f in fields){
			//verts
			verts.Add(f.Position);
			verts.Add(f.Position + new Vector3(1,0,0));
			verts.Add(f.Position + new Vector3(1,1,0));
			verts.Add(f.Position + new Vector3(0,1,0));
			
			verts.Add(f.Position + new Vector3(0,0,1));
			verts.Add(f.Position + new Vector3(1,0,1));
			verts.Add(f.Position + new Vector3(1,1,1));
			verts.Add(f.Position + new Vector3(0,1,1));
			
			colors.Add(f.Color);
			colors.Add(f.Color);
			colors.Add(f.Color);
			colors.Add(f.Color);
			colors.Add(f.Color);
			colors.Add(f.Color);
			colors.Add(f.Color);
			colors.Add(f.Color);
			
			//Front
			if(f.Faces[1]){
				triangles.Add(counter + 2);
				triangles.Add(counter + 1);
				triangles.Add(counter + 0);
				
				triangles.Add(counter + 3);
				triangles.Add(counter + 2);
				triangles.Add(counter + 0);
			}
			//Left
			if(f.Faces[2]){
				triangles.Add(counter + 4);
				triangles.Add(counter + 3);
				triangles.Add(counter + 0);
				
				triangles.Add(counter + 7);
				triangles.Add(counter + 3);
				triangles.Add(counter + 4);
			}
			//Back
			if(f.Faces[3]){
				triangles.Add(counter + 5);
				triangles.Add(counter + 7);
				triangles.Add(counter + 4);
				
				triangles.Add(counter + 5);
				triangles.Add(counter + 6);
				triangles.Add(counter + 7);
			}
			//Right
			if(f.Faces[0]){
				triangles.Add(counter + 5);
				triangles.Add(counter + 2);
				triangles.Add(counter + 6);
				
				triangles.Add(counter + 1);
				triangles.Add(counter + 2);
				triangles.Add(counter + 5);
			}
			//Top
			if(f.Faces[4]){
				triangles.Add(counter + 3);
				triangles.Add(counter + 7);
				triangles.Add(counter + 2);
				
				triangles.Add(counter + 7);
				triangles.Add(counter + 6);
				triangles.Add(counter + 2);
			}
			//Bottom
			if(f.Faces[5]){
				triangles.Add(counter + 0);
				triangles.Add(counter + 1);
				triangles.Add(counter + 4);
				
				triangles.Add(counter + 1);
				triangles.Add(counter + 5);
				triangles.Add(counter + 4);
			}
			counter += 8;
		}
		
		Mesh m = new Mesh();
		m.name = "Mesh";
		
		m.vertices = verts.ToArray();
		//m.uv = uvs.ToArray();
		m.colors = colors.ToArray();
		
		m.triangles = triangles.ToArray();
		m.RecalculateNormals();
		
		gameObject.GetComponent<MeshFilter>().mesh = m;
		gameObject.GetComponent<MeshFilter>().sharedMesh = m;
	}
}
