Shader "Hidden/Pulse"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        [HDR]_EdgeColor ("Edge Color", Color) = (1,1,1,1)
        _BinaryTexture ("Albedo (RGB)", 2D) = "white" {}
        _BinarySize ("Binary size", Float) = 10
        _Scroll ("Scroll", Vector) = (1,0,0,0)
        _SplitOffset ("Split", Range(0,1)) = 0.2
        _Offset("Offset", Float) = 0.3
        [HDR]_GridColor ("GridColor", Color) = (1,1,1,1)
        [HDR]_TextureColor ("TextureColor", Color) = (1,1,1,1)
        _GridSize ("Grid Scale", Float) = 100
        _GridWidth ("Grid Width", Range(0,1)) = 0.1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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
                float4 screenPos : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _CameraDepthTexture;
            sampler2D _BinaryTexture;

            fixed4 _Color;
            half4 _EdgeColor;
            half4 _GridColor;
            half4 _TextureColor;

            float _BinarySize;

            fixed _SplitOffset;
            fixed _Offset;

            fixed _GridWidth;
            half _GridSize;

            half2 _Scroll;

            fixed _Amount;

            fixed pulse(float t, float linDepth)
            {
                float d = saturate(1 - (abs(t / 10 - linDepth) * 100));
                return d;
            }

            half4 frag (v2f i) : SV_Target
            {
                float t = saturate(_Amount);
                t *= t;
                float depth = UNITY_SAMPLE_DEPTH(tex2D(_CameraDepthTexture, i.uv).r);
                float linDepth = Linear01Depth(depth);
                float d = saturate((t / 20 - linDepth - 0.02f) * 1000);
                float g = saturate(saturate((t / 20 - linDepth - 0.01f) * 1000) - d);
                float2 gridUV = float2(i.uv.x, i.uv.y);
                fixed grid = step(_GridWidth, ((gridUV.x * _GridSize) % 1)) * step(_GridWidth, ((gridUV.y * _GridSize) % 1));

                half split = ceil((gridUV.x % 1) / _SplitOffset);
                half2 uv = gridUV * _BinarySize + _Scroll * _Time.y * sin(split) * _Offset;
                fixed tex = step(0.5, tex2D(_BinaryTexture, uv).b);

                half4 c = _GridColor * (1 - saturate(grid)) + tex * _TextureColor;
                half4 col = tex2D(_MainTex, i.uv);
                return lerp(col, col * float4(0.1f, 0.7f,0.1f,1), saturate(d + t * t)) + (c + _EdgeColor) * g * (1 - t);
            }
            ENDCG
        }
    }
}
