﻿Shader "Custom/Outline"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
		_OutlineColor("Outline Color", Color) = (0.5,0.5,0.5,1.0)
		_Outline("Outline width", Float) = 0.01
    }
    SubShader
    {
	    Tags { "RenderType" = "Opaque" }
		LOD 250

	    Pass
		{
			Cull Front
			ZWrite On
			CGPROGRAM
			#include "UnityCG.cginc"
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma glsl_no_auto_normalization
			#pragma vertex vert
			#pragma fragment frag

			struct appdata_t
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
			};

			fixed _Outline;


			v2f vert(appdata_t v)
			{
				v2f o;
				o.pos = v.vertex;
				o.pos.xyz += normalize(v.normal.xyz) *_Outline*0.01;
				o.pos = UnityObjectToClipPos(o.pos);
				return o;
			}

			fixed4 _OutlineColor;

			fixed4 frag(v2f i) :COLOR
			{
				return _OutlineColor;
			}

			ENDCG
		}



        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
