Shader "Unlit/ScreenPositionEffects"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TrackedPosition ("Tracked position", Vector) = (0, 0, 0, 0)
    }

    SubShader
    {
        Cull Off 
        ZWrite Off 
        ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TrackedPosition;

            v2f vert (appdata IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;

                return OUT;
            }

            fixed4 frag (v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.uv);

                float2 posFactor = (IN.uv - 0.5f) * (unity_OrthoParams.xy * 2);
                float2 camWorldPos = posFactor + _WorldSpaceCameraPos.xz;

                float3 originalCol = c.rgb;
                c.rgb = lerp(c.rgb * 1, originalCol, distance(camWorldPos, _TrackedPosition.xz) * 0.5);

                return c;
            }
            ENDCG
        }
    }
}
