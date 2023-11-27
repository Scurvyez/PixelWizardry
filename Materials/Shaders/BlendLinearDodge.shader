Shader "Unlit/BlendLinearDodge"
{
    Properties 
	{
		_MainTex ("Main texture", 2D) = "white" {}
		_Color ("Color", Vector) = (1,1,1,1)
	}

	SubShader {
		
		Tags 
		{ 
			"IGNOREPROJECTOR" = "true" 
			"QUEUE" = "Transparent+150" 
			"RenderType" = "Transparent" 
		}
		
		Pass {
			
			Tags 
			{ 
				"IGNOREPROJECTOR" = "true" 
				"QUEUE" = "Transparent+150" 
				"RenderType" = "Transparent" 
			}
			
			BlendOp Add
			Blend SrcAlpha One
			ZWrite Off
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			float4 _MainTex_ST;
			float4 _Color;
			sampler2D _MainTex;

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

				// OBJECT SPACE
				// objects have their very own coordinate system, called object space
				// we need to transform our object from object space to world space before the camera can render it properly

				// Let's start!
				// Transform vertex position to world space 

				// worldPos = final transformed vertex position in world space
				// v.vertex.yyyy = y-component of vertex position in the local object space
				// v.vertex.xxxx = x-component of vertex position in the local object space
				// v.vertex.zzzz = z-component of vertex position in the local object space
				// "yyyy", "xxxx", and "zzzz" means the corresponding value is being replicated across all four components of a float4 vector
				// specific numerical values of x, y, z, and w depend on the geometry and how it's defined in the scene
				// unity_ObjectToWorld = matrix from Unity to transform vertex position from local object space to world space
				// _m01_m11_m21_m31 = swizzle operator used to access specific elements of the unity_ObjectToWorld matrix required for transformation

				// lets break down the swizzel op...
				// _m01 = (0,0), _m11 = (1,1), _m21 (2,1), and _m31 (3,1)
				// so the elements in the unity_ObjectToWorld matrix we are getting first are...
				// unity_ObjectToWorld[0,1]
				// unity_ObjectToWorld[1,1]
				// unity_ObjectToWorld[2,1]
				// unity_ObjectToWorld[3,1]
				// this gives us the y-component of our vertex position 

				// so...
				// multiply the y-component of the vertex position (v.vertex.yyyy) in local space with the corresponding transformation matrix component
				// these elements correspond to the scaling and rotation components of the transformation matrix affecting the x-axis
				// this multiplication is applied to each component of the resulting float4 vector worldPos, giving us the transformed vertex position in world space
				float4 worldPos = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
				// like above, we have more elements to access, starting with the x-component
				worldPos += v.vertex.xxxx * unity_ObjectToWorld._m00_m10_m20_m30;
				worldPos += v.vertex.zzzz * unity_ObjectToWorld._m02_m12_m22_m32;
				// now that we've handled our x, y, and z components, lets translate the vertex position from object space to world space
				// _m03_m13_m23_m33 represents our displacement of the object in world space
				worldPos += unity_ObjectToWorld._m03_m13_m23_m33;
				// there we go, we've just transformed our vertex position from object space to world space with scaling, rotation, and translation


				//---------------------------------------------------------------------------------------------------------------------------------------------------//
				//---------------------------------------------------------------------------------------------------------------------------------------------------//


				// CLIP SPACE
				// clip space is a normalized coordinate system, ranging from -1 to 1
				// we need to now transform our object from world space to clip space for proper perspective projection and rasterization

				// Transform world position to clip space

				// worldPos.yyyy = y-component of vertex position in world space

				// clipPos = final vertex position in clip space
				// unity_MatrixVP = represents the combined effect of the camera's view transformation and the projection transformation
				// just like above, we need to access certain elements for our transformations...
				float4 clipPos = worldPos.yyyy * unity_MatrixVP._m01_m11_m21_m31;
				clipPos += worldPos.xxxx * unity_MatrixVP._m00_m10_m20_m30;
				clipPos += worldPos.zzzz * unity_MatrixVP._m02_m12_m22_m32;
				clipPos += worldPos.wwww * unity_MatrixVP._m03_m13_m23_m33;

				// Set the vertex position in the output struct
				// clipPos is what what will be used for perspective division, viewport mapping, and rasterization later on
				o.position = clipPos;

				// Transform the texture coordinates
				o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;

				// Pass through the vertex color
				o.color = v.color;

				return o;
			}

			fout frag(v2f inp)
			{
                fout o;
                float4 finalColor = tex2D(_MainTex, inp.texcoord.xy);
                finalColor = finalColor * _Color;
				finalColor.rgb *= finalColor.a;
                o.sv_target = finalColor * inp.color;
                return o;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
