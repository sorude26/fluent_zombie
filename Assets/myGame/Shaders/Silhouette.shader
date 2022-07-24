// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Silhouette"
{
	Properties{
		_MainTex("Main Texture", 2D) = "white" { }
		_SilhouetteColor("Silhouette Color", Color) = (0.0, 0.0, 0.0, 1.0)
		//_Cutoff("Cutoff", Range(0,1)) = 0.5
		//_Color("Color", Color) = (1,1,1,1)
		//_MainTex("Albedo (RGB)", 2D) = "white" {}
		//_Glossiness("Smoothness", Range(0,1)) = 0.5
		//_Metallic("Metallic", Range(0,1)) = 0.0
	}

		SubShader{
			// Render queue +1 to render after all solid objects
			//Tags { "Queue" = "Geometry+1" "RenderType" = "Opaque" }
		    Tags { "Queue" = "AlphaTest" "RenderType" = "TransparentCutout" }
				LOD 200
				Cull Off
			Pass {
				// Don't write to the depth buffer for the silhouette pass
				ZWrite Off
				ZTest Always

				// First Pass: Silhouette
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				float4 _SilhouetteColor;

				struct vertInput {
					float4 vertex:POSITION;
					float3 normal:NORMAL;
				};

				struct fragInput {
					float4 pos:SV_POSITION;
				};

				fragInput vert(vertInput i) {
					fragInput o;
					o.pos = UnityObjectToClipPos(i.vertex);
					return o;
				}

				float4 frag(fragInput i) : COLOR {
					return _SilhouetteColor;
				}
				ENDCG
			}
			///*
			// Second Pass: Standard
			CGPROGRAM

			#pragma surface surf Lambert
			#include "UnityCG.cginc"

			sampler2D _MainTex;

			struct Input {
				float2 uv_MainTex;
			};

			//half _Glossiness;
			//half _Metallic;
			//fixed4 _Color;

			void surf(Input IN, inout SurfaceOutput o) {
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
				o.Albedo = c.rgb;
				//o.Metallic = _Metallic;
				//o.Smoothness = _Glossiness;
				//o.Alpha = c.a;
			}

			ENDCG
			//*/
			/*
			CGPROGRAM
			#pragma surface surf Lambert
			#include "UnityCG.cginc"

			sampler2D _MainTex;

			struct Input {
				float2 uv_MainTex;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			void surf(Input IN, inout SurfaceOutputStandard o) {
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}
			ENDCG
			*/
		}			
		FallBack "Diffuse"
}
