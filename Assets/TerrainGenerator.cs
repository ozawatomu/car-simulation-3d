using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator:MonoBehaviour
{
	public int depth = 20;
	public int width = 256;
	public int height = 256;
	public float scale = 20f;

	public int octaves = 3;
	public float lacunarity = 2f;
	[Range(0, 1)]
	public float persistance = 0.5f;

	void Update() {
		Terrain terrain = GetComponent<Terrain>();
		terrain.terrainData = GenerateTerrain(terrain.terrainData);
	}

	TerrainData GenerateTerrain(TerrainData terrainData) {
		terrainData.heightmapResolution = width + 1;
		terrainData.size = new Vector3(width, depth, height);
		terrainData.SetHeights(0, 0, GenerateHeights());
		return terrainData;
	}

	float[,] GenerateHeights() {
		float[,] heights = new float[width, height];

		float maxNoiseHeight = float.MinValue;
		float minNoiseHeight = float.MaxValue;

		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				float amplitude = 1;
				float frequency = 1;
				float noiseHeight = 0;

				for(int i = 0; i < octaves; i++) {
					float xCoord = (float)x/width*scale*frequency;
					float yCoord = (float)y/height*scale*frequency;
					float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);
					noiseHeight += perlinValue*amplitude;
					amplitude *= persistance;
					frequency *= lacunarity;
				}

				if(noiseHeight > maxNoiseHeight) {
					maxNoiseHeight = noiseHeight;
				}

				if(noiseHeight < minNoiseHeight) {
					minNoiseHeight = noiseHeight;
				}

				heights[x, y] = noiseHeight;
			}
		}

		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				heights[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, heights[x, y]);
			}
		}

		return heights;
	}

	float CalculateHeight(int x, int y) {
		float amplitude = 1;
		float frequency = 1;
		float noiseHeight = 0;

		for(int i = 0; i < octaves; i++) {
			float xCoord = (float)x/width*scale*frequency;
			float yCoord = (float)y/height*scale*frequency;
			float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);
			noiseHeight += perlinValue*amplitude;
			amplitude *= persistance;
			frequency *= lacunarity;
		}

		return noiseHeight;
	}
}
