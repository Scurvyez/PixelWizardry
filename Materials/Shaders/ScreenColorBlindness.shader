Shader "Unlit/ScreenColorBlindness"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _R ("Red mixing", Color) = (1,0,0,1)
        _G ("Green mixing", Color) = (0,1,0,1)
        _B ("Blue mixing", Color) = (0,0,1,1)
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _R;
            float4 _G;
            float4 _B;

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

            v2f vert (appdata IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;
                return OUT;
            }

            fixed4 frag (v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.uv); // Initialize 'c' with the texture color

                // Use color blind modes
                c.rgb = fixed3(
                           c.r * _R[0] + c.g * _R[1] + c.b * _R[2],
                           c.r * _G[0] + c.g * _G[1] + c.b * _G[2],
                           c.r * _B[0] + c.g * _B[1] + c.b * _B[2]);

                return c;
            }
            ENDCG
        }
    }
}
