﻿Shader "Unlit/ScreenPulse"
{
    Properties 
	{
		_MainTex ("Main texture", 2D) = "white" {}
		_Color ("Color", Vector) = (1,1,1,1)
		_PulseSpeed ("Pulse Speed", Range(0.1, 10.0)) = 1.0
		_PulseAmplitude ("Pulse Amplitude", Range(0.1, 2.0)) = 1.0
	}

	SubShader {
		
		Tags 
		{ 
			"IGNOREPROJECTOR" = "true" 
			"QUEUE" = "Transparent-100" 
			"RenderType" = "Transparent" 
		}
		
		Pass {
			
			Tags 
			{ 
				"IGNOREPROJECTOR" = "true" 
				"QUEUE" = "Transparent-100" 
				"RenderType" = "Transparent" 
			}
			
			Blend One OneMinusSrcColor
			ZWrite Off
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			float4 _MainTex_ST;
			float4 _Color;
			sampler2D _MainTex;

			float _GameSeconds;
			float _PulseSpeed;  // Adjust the speed of the pulse effect
            float _PulseAmplitude;  // Adjust the amplitude of the pulse effect

			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float4 color : COLOR0;
			};

			struct fout
			{
				float4 sv_target : SV_Target0;
			};

			v2f vert(appdata_full v)
			{
                v2f o;

				float4 worldPos = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
				worldPos += v.vertex.xxxx * unity_ObjectToWorld._m00_m10_m20_m30;
				worldPos += v.vertex.zzzz * unity_ObjectToWorld._m02_m12_m22_m32;
				worldPos += unity_ObjectToWorld._m03_m13_m23_m33;

				float4 clipPos = worldPos.yyyy * unity_MatrixVP._m01_m11_m21_m31;
				clipPos += worldPos.xxxx * unity_MatrixVP._m00_m10_m20_m30;
				clipPos += worldPos.zzzz * unity_MatrixVP._m02_m12_m22_m32;
				clipPos += worldPos.wwww * unity_MatrixVP._m03_m13_m23_m33;

				o.position = clipPos;
				o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				o.color = v.color;

                return o;
			}

			fout frag(v2f inp)
			{
                fout o;
                float4 finalColor = tex2D(_MainTex, inp.texcoord.xy);
                finalColor = finalColor * _Color;
				
                // Calculate the pulse factor based on time
                float pulseFactor = abs(sin(_GameSeconds * _PulseSpeed));

                // Increase the brightness of the pixels using the pulse factor
                finalColor.rgb += finalColor.rgb * pulseFactor * _PulseAmplitude;

				finalColor.rgb *= finalColor.a;
                o.sv_target = finalColor * inp.color;
                return o;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
