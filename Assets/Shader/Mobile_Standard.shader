Shader "Mobile/Standard" {
	Properties {
		_MainTex ("Albedo", 2D) = "white" {}
		[Toggle(COLOR_ON)] _ColorToggle ("Color, Brightness, Contrast Toggle", Float) = 0
		_Color ("Color", Vector) = (1,1,1,1)
		_Brightness ("Brightness", Range(-10, 10)) = 0
		_Contrast ("Contrast", Range(0, 3)) = 1
		[Toggle(PHONG_ON)] _Phong ("Point Light Toggle", Float) = 0
		_PointLightColor ("Point Light Color", Vector) = (1,1,1,1)
		_PointLightPosition ("Point Light Position", Vector) = (0,0,0,1)
		_AmbiencePower ("Ambience intensity", Range(0, 2)) = 1
		_SpecularPower ("Specular intensity", Range(0, 2)) = 1
		_DiffusePower ("Diffuse intensity", Range(0, 2)) = 1
		[Toggle(DETAIL_ON)] _Detail ("Detail Map Toggle", Float) = 0
		_DetailMap ("Detail Map", 2D) = "white" {}
		_DetailStrength ("Detail Map Strength", Range(0, 2)) = 1
		[Toggle(DETAIL_MASK_ON)] _Mask ("Detail Mask Toggle", Float) = 0
		_DetailMask ("Detail Mask", 2D) = "white" {}
		[Toggle(EMISSION_ON)] _Emission ("Emission Map Toggle", Float) = 0
		_EmissionMap ("Emission", 2D) = "white" {}
		_EmissionStrength ("Emission Strength", Range(0, 10)) = 1
		[Toggle(NORMAL_ON)] _Normal ("Normal Map Toggle", Float) = 0
		_NormalMap ("Normal Map", 2D) = "bump" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Mobile/VertexLit"
}