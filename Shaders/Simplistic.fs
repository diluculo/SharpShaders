﻿namespace SharpShaders.Shaders

open SharpDX
open SharpShaders.Math
open SharpShaders

module Simplistic =
    //===================================================
    [<Struct>]
    type ObjectConstants =
        val WorldViewProjection : float4x4
        new (wvp) = { WorldViewProjection = wvp }

    [<Struct>]
    type VSInput =
        val Position : float4
        new (pos) = { Position = pos }

    [<Struct>]
    type PSInput =
        val PositionHS : float4
        new (pos) = { PositionHS = pos }

    [<Struct>]
    type MaterialConstants =
        val MaterialDiffuse : Color4
        new (color) = { MaterialDiffuse = color }

    type Shader(obj:ObjectConstants, mat:MaterialConstants) =

        [<ShaderEntry>]
        member m.vertex(input:VSInput) =
            PSInput(input.Position * obj.WorldViewProjection)

        [<ShaderEntry>]
        member m.pixel(input:PSInput) =
            float4(1.0f, 0.0f, 1.0f,1.0f)