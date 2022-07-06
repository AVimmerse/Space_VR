// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Stagit/Skybox 6 Sided" {
Properties {
	_StarTint ("Star Tint Color", Color) = (.5, .5, .5, .5)
	_EarthTint ("Earth Tint Color", Color) = (.5, .5, .5, .5)
	[Gamma] _StarExposure ("Star Exposure", Range(0, 8)) = 1.0
	[Gamma] _EarthExposure ("Earth Exposure", Range(0, 8)) = 1.0
	_Rotation ("Rotation", Range(0, 360)) = 0
	[NoScaleOffset] _FrontTex ("Front [+Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _FrontTex2 ("FrontAlpha [+Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _BackTex ("Back [-Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _BackTex2 ("BackAlpha [-Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _LeftTex ("Left [+X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _LeftTex2 ("LeftAlpha [+X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _RightTex ("Right [-X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _RightTex2 ("RightAlpha [-X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _UpTex ("Up [+Y]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _UpTex2 ("UpAlpha [+Y]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _DownTex ("Down [-Y]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _DownTex2 ("DownAlpha [-Y]   (HDR)", 2D) = "grey" {}
}

SubShader {
	Tags { "Queue"="Background" "RenderType"="Transparent" "PreviewType"="Skybox" }
	Cull Off ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha
	CGINCLUDE
	#include "UnityCG.cginc"

	half4 _StarTint;
	half4 _EarthTint;
	half _StarExposure;
	half _EarthExposure;
	float _Rotation;

	float3 RotateAroundYInDegrees (float3 vertex, float degrees)
	{
		float alpha = degrees * UNITY_PI / 180.0;
		float sina, cosa;
		sincos(alpha, sina, cosa);
		float2x2 m = float2x2(cosa, -sina, sina, cosa);
		return float3(mul(m, vertex.xz), vertex.y).xzy;
	}
	
	struct appdata_t {
		float4 vertex : POSITION;
		float2 texcoord : TEXCOORD0;
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};
	struct v2f {
		float4 vertex : SV_POSITION;
		float2 texcoord : TEXCOORD0;
		UNITY_VERTEX_OUTPUT_STEREO
	};
	v2f vert (appdata_t v)
	{
		v2f o;
		UNITY_SETUP_INSTANCE_ID(v);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
		float3 rotated = RotateAroundYInDegrees(v.vertex, _Rotation);
		o.vertex = UnityObjectToClipPos(rotated);
		o.texcoord = v.texcoord;
		return o;
	}
	half4 skybox_frag (v2f i, sampler2D smp,sampler2D smpAlpha, half4 smpDecode)
	{
		half4 texAlpha = tex2D (smpAlpha, i.texcoord);
		half4 tex = tex2D (smp, i.texcoord);


		half3 backTex = tex.rgb * (1 - texAlpha.a) *  (_StarTint.rgb * unity_ColorSpaceDouble.rgb) * _StarExposure;

		half3 frontTex = texAlpha.rgb * (texAlpha.a) * (_EarthTint.rgb * unity_ColorSpaceDouble.rgb) *_EarthExposure;

		half3 c = (backTex + frontTex);

		//half3 c = DecodeHDR (final, smpDecode);
		//c = c * _Tint.rgb * unity_ColorSpaceDouble.rgb;
		//c *= _Exposure;
		return half4(c, 1);
	}
	ENDCG
	
	Pass {
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _FrontTex;
		sampler2D _FrontTex2;
		half4 _FrontTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_FrontTex,_FrontTex2, _FrontTex_HDR); }
		ENDCG 
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _BackTex;
		sampler2D _BackTex2;
		half4 _BackTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_BackTex,_BackTex2, _BackTex_HDR); }
		ENDCG 
	}


			Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _LeftTex;
		sampler2D _LeftTex2;
		half4 _LeftTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_LeftTex,_LeftTex2, _LeftTex_HDR); }
		ENDCG
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _RightTex;
		sampler2D _RightTex2;
		half4 _RightTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_RightTex,_RightTex2, _RightTex_HDR); }
		ENDCG
	}	
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _UpTex;
		sampler2D _UpTex2;
		half4 _UpTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_UpTex,_UpTex2, _UpTex_HDR); }
		ENDCG
	}	
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _DownTex;
		sampler2D _DownTex2;
		half4 _DownTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_DownTex,_DownTex2, _DownTex_HDR); }
		ENDCG
	}
}
}
