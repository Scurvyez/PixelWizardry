Shader "Unlit/BlendRGBToHSV"
{
    Properties 
	{
		_MainTex ("Main texture", 2D) = "white" {}
		_Color ("Color", Vector) = (1,1,1,1)
		_OscillationSpeed ("Pulse Speed", Range(0.0, 20.0)) = 0
		[ShowAsVector2] _HueLerp("Hue Lerp", Vector) = (1, 1, 0, 0)
		[ShowAsVector2] _SaturationLerp("Saturation Lerp", Vector) = (1, 1, 0, 0)
		[ShowAsVector2] _ValueLerp("Value Lerp", Vector) = (1, 1, 0, 0)
	}

	SubShader 
	{
		Tags 
		{ 
			"IGNOREPROJECTOR" = "true" 
			"QUEUE" = "Transparent+150" 
			"RenderType" = "Transparent" 
		}

		Pass 
		{
			Tags 
			{ 
				"IGNOREPROJECTOR" = "true" 
				"QUEUE" = "Transparent+150" 
				"RenderType" = "Transparent" 
			}

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite Off
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			float4 _MainTex_ST;
			float4 _Color;
			sampler2D _MainTex;
			float _GameSeconds;
			float _OscillationSpeed;
			float2 _HueLerp;
			float2 _SaturationLerp;
			float2 _ValueLerp;

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

			// Function to convert RGB to HSV
            float3 rgb2hsv(float3 c)
            {
                float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 p = lerp(float4(c.bg, K.wz), float4(c.gb, K.xy), step(c.b, c.g));
                float4 q = lerp(float4(p.xyw, c.r), float4(c.r, p.yzx), step(p.x, c.r));

                float d = q.x - min(q.w, q.y);
                float e = 1.0e-10;
                return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
            }

            // Function to convert HSV to RGB
            float3 hsv2rgb(float3 c)
            {
                float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
                float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
                return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
            }

			fout frag(v2f inp)
			{
                fout o;
				float4 finalColor = tex2D(_MainTex, inp.texcoord.xy);
				finalColor = finalColor * _Color;

				// Calculate the time-based oscillation value
				float oscillation = abs(sin(_GameSeconds * _OscillationSpeed));

				// Interpolate between the minimum and maximum hue values based on oscillation
				float3 hsv = rgb2hsv(finalColor.rgb);

				// Apply oscillation as an offset to the hue, saturation, and value
				float hueOffset = lerp(_HueLerp.x, _HueLerp.y, oscillation);
				float saturationOffset = lerp(_SaturationLerp.x, _SaturationLerp.y, oscillation);
				float valueOffset = lerp(_ValueLerp.x, _ValueLerp.y, oscillation);

				hsv.x = frac(hsv.x + hueOffset); // Ensuring hue remains in [0, 1] range
				hsv.y *= saturationOffset;
				hsv.z *= valueOffset;

				// Convert back to RGB
				finalColor.rgb = hsv2rgb(hsv) * finalColor.a;

				o.sv_target = finalColor * inp.color;
				return o;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
