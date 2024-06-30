Shader "Water_Simple" {
	Properties {
		_WaterColor ("Water Color", Vector) = (1,1,1,0)
		_TextureVisibility ("Texture Visibility", Range(0, 1)) = 0.05
		_Tiling ("Tiling", Vector) = (0,0,0,0)
		[NoScaleOffset] _TextureBase ("Texture Base", 2D) = "white" {}
		_Speed ("Speed", Float) = 0
		_MoveDirection ("Move Direction", Vector) = (-0.1,0.1,0,0)
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}