Shader "Unlit/UVMaskRect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _UVXMaskLeft("UVXMask_Left",Range(0,1))=0
        _UVXMaskRight("UVXMask_Right",Range(0,1))=0

        _UVYMaskTop("UVYMask_Top",Range(0,1))=0
        _UVYMaskBottom("UVYMask_Bottom",Range(0,1))=0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull back

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

            float _UVXMask;
            float _UVXMaskRight;

            float _UVYMaskTop;
            float _UVYMaskBottom;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                if (i.uv.x<_UVXMask||i.uv.x>_UVXMaskRight)
                    col.a=0;
                if (i.uv.y>_UVYMaskTop||i.uv.y<_UVYMaskBottom)
                    col.a=0;   
                return col;
            }
            ENDCG
        }
    }
}
