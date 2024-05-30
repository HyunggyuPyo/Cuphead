//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Sprites/KitchenBasementPlayer" {
Properties {
_MainTex ("Sprite Texture", 2D) = "white" { }
_ColorA ("ColorA", Color) = (1,1,1,1)
_ColorB ("ColorB", Color) = (1,1,1,1)
_AmountA ("AmountA", Float) = 0
_AmountB ("AmountB", Float) = 0
[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
_RendererColor ("RendererColor", Color) = (1,1,1,1)
_Flip ("Flip", Vector) = (1,1,1,1)
_AlphaTex ("External Alpha", 2D) = "white" { }
_EnableExternalAlpha ("Enable External Alpha", Float) = 0
_Level ("Level", Float) = 0.3
_MaskTex ("Mask Texture", 2D) = "white" { }
}
SubShader {
 Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
 Pass {
  Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
  Blend One OneMinusSrcAlpha, One OneMinusSrcAlpha
  ZWrite Off
  Cull Off
  GpuProgramID 40909
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "ETC1_EXTERNAL_ALPHA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "PIXELSNAP_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "ETC1_EXTERNAL_ALPHA" "PIXELSNAP_ON" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "ETC1_EXTERNAL_ALPHA" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "PIXELSNAP_ON" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "ETC1_EXTERNAL_ALPHA" "PIXELSNAP_ON" }
"// shader disassembly not supported on DXBC"
}
}
}
}
}