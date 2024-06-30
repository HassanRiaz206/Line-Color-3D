Shader "ShallotStudio/ColorAndBrightnessUVAnim" {
	Properties {
		_MainColor ("MainColor", Vector) = (1,1,1,1)
		_MainTex ("MainTex", 2D) = "white" {}
		_Brightness ("Brightness", Range(-1, 1)) = 0
		_ColorIntensity ("ColorIntensity", Float) = 0
		_XYSpeed ("XYSpeed", Vector) = (0,0,0,0)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ShaderForgeMaterialInspector"
}