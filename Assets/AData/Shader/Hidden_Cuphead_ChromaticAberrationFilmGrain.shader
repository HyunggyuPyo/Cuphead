//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Hidden/Cuphead/ChromaticAberrationFilmGrain" {
Properties {
_MainTex ("Screen Blended", 2D) = "" { }
_Overlay ("Color", 2D) = "grey" { }
}
SubShader {
 Pass {
  ColorMask RGB 0
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 10698
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  ColorMask RGB 0
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 127674
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  ColorMask RGB 0
  ZTest Always
  ZWrite Off
  Cull Off
  GpuProgramID 133725
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
}
}