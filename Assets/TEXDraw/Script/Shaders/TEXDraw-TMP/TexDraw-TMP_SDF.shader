﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Copyright (C) 2014 - 2016 Stephan Schaem - All Rights Reserved
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

// Derivation of original Distance Field with some modification for TEXDraw compatibility

Shader "TEXDraw/TextMeshPro/Distance Field" {

	Properties{
		[MiniThumbTexture] _Font0("Font 0", 2D) = "white" {}
		[MiniThumbTexture] _Font1("Font 1", 2D) = "white" {}
		[MiniThumbTexture] _Font2("Font 2", 2D) = "white" {}
		[MiniThumbTexture] _Font3("Font 3", 2D) = "white" {}
		[MiniThumbTexture] _Font4("Font 4", 2D) = "white" {}
		[MiniThumbTexture] _Font5("Font 5", 2D) = "white" {}
		[MiniThumbTexture] _Font6("Font 6", 2D) = "white" {}
		[MiniThumbTexture] _Font7("Font 7", 2D) = "white" {}
		[Space]
		[MiniThumbTexture] _Font8("Font 8", 2D) = "white" {}
		[MiniThumbTexture] _Font9("Font 9", 2D) = "white" {}
		[MiniThumbTexture] _FontA("Font A", 2D) = "white" {}
		[MiniThumbTexture] _FontB("Font B", 2D) = "white" {}
		[MiniThumbTexture] _FontC("Font C", 2D) = "white" {}
		[MiniThumbTexture] _FontD("Font D", 2D) = "white" {}
		[MiniThumbTexture] _FontE("Font E", 2D) = "white" {}
		[MiniThumbTexture] _FontF("Font F", 2D) = "white" {}
		[Space]
		[MiniThumbTexture] _Font10("Font 10", 2D) = "white" {}
		[MiniThumbTexture] _Font11("Font 11", 2D) = "white" {}
		[MiniThumbTexture] _Font12("Font 12", 2D) = "white" {}
		[MiniThumbTexture] _Font13("Font 13", 2D) = "white" {}
		[MiniThumbTexture] _Font14("Font 14", 2D) = "white" {}
		[MiniThumbTexture] _Font15("Font 15", 2D) = "white" {}
		[MiniThumbTexture] _Font16("Font 16", 2D) = "white" {}
		[MiniThumbTexture] _Font17("Font 17", 2D) = "white" {}
		[Space]
		[MiniThumbTexture] _Font18("Font 18", 2D) = "white" {}
		[MiniThumbTexture] _Font19("Font 19", 2D) = "white" {}
		[MiniThumbTexture] _Font1A("Font 1A", 2D) = "white" {}
		[MiniThumbTexture] _Font1B("Font 1B", 2D) = "white" {}
		[MiniThumbTexture] _Font1C("Font 1C", 2D) = "white" {}
		[MiniThumbTexture] _Font1D("Font 1D", 2D) = "white" {}
		[MiniThumbTexture] _Font1E("Font 1E", 2D) = "white" {}
		[Space] 
		_FaceTex("Face Texture", 2D) = "white" {}
		_FaceUVSpeedX("Face UV Speed X", Range(-5, 5)) = 0.0
		_FaceUVSpeedY("Face UV Speed Y", Range(-5, 5)) = 0.0
		_FaceColor("Face Color", Color) = (1,1,1,1)
		_FaceDilate("Face Dilate", Range(-1,1)) = 0

		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineTex("Outline Texture", 2D) = "white" {}
		_OutlineUVSpeedX("Outline UV Speed X", Range(-5, 5)) = 0.0
		_OutlineUVSpeedY("Outline UV Speed Y", Range(-5, 5)) = 0.0
		_OutlineWidth("Outline Thickness", Range(0, 1)) = 0
		_OutlineSoftness("Outline Softness", Range(0,1)) = 0

		_Bevel("Bevel", Range(0,1)) = 0.5
		_BevelOffset("Bevel Offset", Range(-0.5,0.5)) = 0
		_BevelWidth("Bevel Width", Range(-.5,0.5)) = 0
		_BevelClamp("Bevel Clamp", Range(0,1)) = 0
		_BevelRoundness("Bevel Roundness", Range(0,1)) = 0

		_LightAngle("Light Angle", Range(0.0, 6.2831853)) = 3.1416
		_SpecularColor("Specular", Color) = (1,1,1,1)
		_SpecularPower("Specular", Range(0,4)) = 2.0
		_Reflectivity("Reflectivity", Range(5.0,15.0)) = 10
		_Diffuse("Diffuse", Range(0,1)) = 0.5
		_Ambient("Ambient", Range(1,0)) = 0.5

		_BumpMap("Normal map", 2D) = "bump" {}
		_BumpOutline("Bump Outline", Range(0,1)) = 0
		_BumpFace("Bump Face", Range(0,1)) = 0

		_ReflectFaceColor("Reflection Color", Color) = (0,0,0,1)
		_ReflectOutlineColor("Reflection Color", Color) = (0,0,0,1)
		_Cube("Reflection Cubemap", Cube) = "black" { /* TexGen CubeReflect */ }
		_EnvMatrixRotation("Texture Rotation", vector) = (0, 0, 0, 0)


		_UnderlayColor("Border Color", Color) = (0,0,0, 0.5)
		_UnderlayOffsetX("Border OffsetX", Range(-1,1)) = 0
		_UnderlayOffsetY("Border OffsetY", Range(-1,1)) = 0
		_UnderlayDilate("Border Dilate", Range(-1,1)) = 0
		_UnderlaySoftness("Border Softness", Range(0,1)) = 0

		_GlowColor("Color", Color) = (0, 1, 0, 0.5)
		_GlowOffset("Offset", Range(-1,1)) = 0
		_GlowInner("Inner", Range(0,1)) = 0.05
		_GlowOuter("Outer", Range(0,1)) = 0.05
		_GlowPower("Falloff", Range(1, 0)) = 0.75

		_WeightNormal("Weight Normal", float) = 0
		_WeightBold("Weight Bold", float) = 0.5

		_ShaderFlags("Flags", float) = 0
		_ScaleRatioA("Scale RatioA", float) = 1
		_ScaleRatioB("Scale RatioB", float) = 1
		_ScaleRatioC("Scale RatioC", float) = 1

		_MainTex("Font Atlas", 2D) = "white" {}
		_TextureWidth("Texture Width", float) = 512
		_TextureHeight("Texture Height", float) = 512
		_GradientScale("Gradient Scale", float) = 5.0
		_ScaleX("Scale X", float) = 1.0
		_ScaleY("Scale Y", float) = 1.0
		_PerspectiveFilter("Perspective Correction", Range(0, 1)) = 0.875

		_VertexOffsetX("Vertex OffsetX", float) = 0
		_VertexOffsetY("Vertex OffsetY", float) = 0

		_MaskCoord("Mask Coordinates", vector) = (0, 0, 10000, 10000)
		_ClipRect("Clip Rect", vector) = (-10000, -10000, 10000, 10000)
		_MaskSoftnessX("Mask SoftnessX", float) = 0
		_MaskSoftnessY("Mask SoftnessY", float) = 0

		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255

		_ColorMask("Color Mask", Float) = 15
	}

	SubShader{

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"TexMaterialType"="Standard"
		}

		Stencil
		{
			Ref[_Stencil]
			Comp[_StencilComp]
			Pass[_StencilOp]
			ReadMask[_StencilReadMask]
			WriteMask[_StencilWriteMask]
		}

		Cull[_CullMode]
		ZWrite Off
		Lighting Off
		Fog{ Mode Off }
		ZTest[unity_GUIZTestMode]
		Blend One OneMinusSrcAlpha
		ColorMask[_ColorMask]

		CGINCLUDE
		#pragma target 3.0
		#pragma shader_feature __ BEVEL_ON
		#pragma shader_feature __ UNDERLAY_ON UNDERLAY_INNER
		#pragma shader_feature __ GLOW_ON
		#pragma shader_feature __ MASK_OFF
		#define SDF_STANDARD
		#include "UnityCG.cginc"
		#include "UnityUI.cginc"
		#include "TMPro_Properties.cginc"
		#include "TMPro.cginc"

		
		struct vertex_t {
			float4	position		: POSITION;
			float3	normal			: NORMAL;
			fixed4	color 			: COLOR;
			float2	texcoord0		: TEXCOORD0;
			float2	texcoord1		: TEXCOORD1; // This is UV2 for TMP (X is unpacked, y is moved to z tangent)
			float3	texcoord2		: TEXCOORD2;	// Used internally for TEXDraw
		};
		
		struct pixel_t {
			float4	position		: SV_POSITION;
			fixed4	color			: COLOR;
			float4	texcoords		: TEXCOORD0;		// Atlas & Texture
			float3	indexcoords		: TEXCOORD1;		// Used internally for TEXDraw
			float4	param			: TEXCOORD2;		// alphaClip, scale, bias, weight
			float4	mask			: TEXCOORD3;		// Position in object space(xy), pixel Size(zw)
			float3	viewDir			: TEXCOORD4;

			#if (UNDERLAY_ON || UNDERLAY_INNER)
			float4	texcoord2		: TEXCOORD5;		// u,v, scale, bias
			fixed4	underlayColor : COLOR1;
			#endif
		};
		

		half determineIndex(half2 uv1)
		{
			half x, y;
			x = floor(uv1.x*8+0.5h);
			y = floor(uv1.y*4+0.5h);
			return (y * 8) + x;
		}
		
		pixel_t VertShader(vertex_t input)
		{
			float bold = step(input.texcoord1.y, 0);

			float4 vert = input.position;
			vert.x += _VertexOffsetX;
			vert.y += _VertexOffsetY;
			float4 vPosition = UnityObjectToClipPos(vert);

			float2 pixelSize = vPosition.w;
			pixelSize /= float2(_ScaleX, _ScaleY) * abs(mul((float2x2)UNITY_MATRIX_P, _ScreenParams.xy));
			float scale = rsqrt(dot(pixelSize, pixelSize));
			scale *= abs(input.texcoord1.y) * _GradientScale * 1.5;
			if (UNITY_MATRIX_P[3][3] == 0) scale = lerp(abs(scale) * (1 - _PerspectiveFilter), scale, abs(dot(UnityObjectToWorldNormal(input.normal.xyz), normalize(WorldSpaceViewDir(vert)))));

			float weight = (lerp(_WeightNormal, _WeightBold, bold)) / _GradientScale;
			weight += _FaceDilate * _ScaleRatioA * 0.5;

			float bias =(.5 - weight) + (.5 / scale);

			float alphaClip = (1.0 - _OutlineWidth*_ScaleRatioA - _OutlineSoftness*_ScaleRatioA);
		
		#if GLOW_ON
			alphaClip = min(alphaClip, 1.0 - _GlowOffset * _ScaleRatioB - _GlowOuter * _ScaleRatioB);
		#endif

			alphaClip = alphaClip / 2.0 - ( .5 / scale) - weight;

		#if (UNDERLAY_ON || UNDERLAY_INNER)
			float4 underlayColor = _UnderlayColor;
			underlayColor.rgb *= underlayColor.a;

			float bScale = scale;
			bScale /= 1 + ((_UnderlaySoftness*_ScaleRatioC) * bScale);
			float bBias = (0.5 - weight) * bScale - 0.5 - ((_UnderlayDilate * _ScaleRatioC) * 0.5 * bScale);

			float x = -(_UnderlayOffsetX * _ScaleRatioC) * _GradientScale / _TextureWidth;
			float y = -(_UnderlayOffsetY * _ScaleRatioC) * _GradientScale / _TextureHeight;
			float2 bOffset = float2(x, y);
		#endif

			// Generate UV for the Masking Texture
			float4 clampedRect = clamp(_ClipRect, -2e10, 2e10);
			float2 maskUV = (vert.xy - clampedRect.xy) / (clampedRect.zw - clampedRect.xy);

			pixel_t output = {
				vPosition,
				input.color,
				float4(input.texcoord0, input.texcoord2.xy),
				float3(input.texcoord1.x,0,0),
				float4(alphaClip, scale, bias, weight),
				half4(vert.xy * 2 - clampedRect.xy - clampedRect.zw, 0.25 / (0.25 * half2(_MaskSoftnessX, _MaskSoftnessY) + pixelSize.xy)),
				mul((float3x3)_EnvMatrix, _WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, vert).xyz),
			#if (UNDERLAY_ON || UNDERLAY_INNER)
				float4(input.texcoord0 + bOffset, bScale, bBias),
				underlayColor,
			#endif
			};

			return output;
		}
		
		
		fixed4 PixShaderSubset(pixel_t input, half4 color, half4 height, half uvAlpha) : SV_Target
			{
				float c = color.a;

#ifndef UNDERLAY_ON
				clip(c - input.param.x);
#endif

				float	scale = input.param.y;
				float	bias = input.param.z;
				float	weight = input.param.w;
				float	sd = (bias - c) * scale;

				float outline = (_OutlineWidth * _ScaleRatioA) * scale;
				float softness = (_OutlineSoftness * _ScaleRatioA) * scale;

				half4 faceColor = _FaceColor;
				half4 outlineColor = _OutlineColor;

				faceColor.rgb *= input.color.rgb;

				faceColor *= tex2D(_FaceTex, input.texcoords.zw + float2(_FaceUVSpeedX, _FaceUVSpeedY) * _Time.y);
				outlineColor *= tex2D(_OutlineTex, input.texcoords.zw + float2(_OutlineUVSpeedX, _OutlineUVSpeedY) * _Time.y);

				faceColor = GetColor(sd, faceColor, outlineColor, outline, softness);

#if BEVEL_ON
				//float3 n = GetSurfaceNormal(input.texcoords.xy, weight, dxy);
				float3 n = GetSurfaceNormal(height, weight);
				float3 bump = UnpackNormal(tex2D(_BumpMap, input.texcoords.zw)).xyz;
				bump *= lerp(_BumpFace, _BumpOutline, saturate(sd + outline * 0.5));
				n = normalize(n - bump);

				float3 light = normalize(float3(sin(_LightAngle), cos(_LightAngle), -1.0));

				float3 col = GetSpecular(n, light);
				faceColor.rgb += col*faceColor.a;
				faceColor.rgb *= 1 - (dot(n, light)*_Diffuse);
				faceColor.rgb *= lerp(_Ambient, 1, n.z*n.z);

				fixed4 reflcol = texCUBE(_Cube, reflect(input.viewDir, -n));
				faceColor.rgb += reflcol.rgb * lerp(_ReflectFaceColor.rgb, _ReflectOutlineColor.rgb, saturate(sd + outline * 0.5)) * faceColor.a;
#endif

#if UNDERLAY_ON
				//float d = tex2D(fontTex, input.texcoord2.xy).a * input.texcoord2.z;
				float d = uvAlpha * input.texcoord2.z;
				faceColor += input.underlayColor * saturate(d - input.texcoord2.w) * (1 - faceColor.a);
#endif

#if UNDERLAY_INNER
				//float d = tex2D(fontTex, input.texcoord2.xy).a * input.texcoord2.z;
				float d = uvAlpha * input.texcoord2.z;
				faceColor += input.underlayColor * (1 - saturate(d - input.texcoord2.w)) * saturate(1 - sd) * (1 - faceColor.a);
#endif

#if GLOW_ON
				float4 glowColor = GetGlowColor(sd, scale);
				faceColor.rgb += glowColor.rgb * glowColor.a;
#endif

				// #if !MASK_OFF
#if UNITY_VERSION < 530
				// Unity 5.2 2D Rect Mask Support
				if (_UseClipRect)
				faceColor *= UnityGet2DClipping(input.mask.xy, _ClipRect);
#else
				// Alternative implementation to UnityGet2DClipping with support for softness.
				half2 m = saturate((_ClipRect.zw - _ClipRect.xy - abs(input.mask.xy)) * input.mask.zw);
				faceColor *= m.x * m.y;
#endif
				//#endif


				return faceColor * input.color.a;
			}
		
		ENDCG
		
		Pass
		{
			Name "SecondaryPass"
			CGPROGRAM
			#pragma vertex VertShader
			#pragma fragment PixShader
			#define TEX_4_2
			#include "TexDraw-TMPIncludes.cginc"
						
			fixed4 PixShader(pixel_t input) : SV_Target
			{ return PixShaderSDFInternal(input); }

			ENDCG
		}
		
		Pass
		{
			Name "ThirdPass"
			CGPROGRAM
			#pragma vertex VertShader
			#pragma fragment PixShader
			#define TEX_4_3
			#include "TexDraw-TMPIncludes.cginc"
			
			fixed4 PixShader(pixel_t input) : SV_Target
			{
				return PixShaderSDFInternal(input);
			}

		ENDCG
		}
		
		Pass
		{
			Name "FourthPass"
			CGPROGRAM
			#pragma vertex VertShader
			#pragma fragment PixShader
			#define TEX_4_4
			#include "TexDraw-TMPIncludes.cginc"
			
			fixed4 PixShader(pixel_t input) : SV_Target
			{
				return PixShaderSDFInternal(input);
			}

		ENDCG
		}
		Pass
		{
			Name "FirstPass"
			CGPROGRAM
			#pragma vertex VertShader
			#pragma fragment PixShader
			#define TEX_4_1
			#include "TexDraw-TMPIncludes.cginc"
						
			fixed4 PixShader(pixel_t input) : SV_Target
			{
				return PixShaderSDFInternal(input);
			}

			ENDCG
		}
	}

	Fallback "TextMeshPro/Mobile/Distance Field"
	CustomEditor "TMPro.EditorUtilities.TMP_SDFShaderGUI"
}
