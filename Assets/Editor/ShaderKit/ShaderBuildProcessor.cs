using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace ShaderKit
{
    public class ShaderBuildProcessor : IPreprocessShaders
    {
        readonly ShaderKeyword m_GlobalKeywordBlue;

        public ShaderBuildProcessor()
        {
            m_GlobalKeywordBlue = new ShaderKeyword("_BLUE");
        }

        public int callbackOrder => 0;

        public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
        {
            ShaderKeyword localKeywordRed = new ShaderKeyword(shader, "_RED");
            for (int i = data.Count - 1; i >= 0; --i)
            {
                if (!data[i].shaderKeywordSet.IsEnabled(m_GlobalKeywordBlue))
                    continue;
                if (!data[i].shaderKeywordSet.IsEnabled(localKeywordRed))
                    continue;

                data.RemoveAt(i);
            }
        }
    }
}


