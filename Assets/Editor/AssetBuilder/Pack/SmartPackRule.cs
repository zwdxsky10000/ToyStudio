using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SmartAssetBuilderEditor
{
    public enum EPackRuleType
    {
        Single = 0,
        Dir = 1,
        Group = 2,
    }
    
    [CreateAssetMenu(menuName = "SmartPack/PackAssetRule", fileName = "PackAssetRule")]
    public class SmartPackRule : ScriptableObject
    {
        public string PackRulePath;
        public EPackRuleType PackRuleType;
        public bool QueryRef;
        public List<PackedAssetGroup> CustomPackGroups = new List<PackedAssetGroup>();
        
        public bool AddPackedAssetGroup(PackedAssetGroup packedGroup, ref string errorGuid)
        {
            if(CheckGroupValid(packedGroup, ref errorGuid) == false)
            {
                return false;
            }
            
            errorGuid = String.Empty;
            CustomPackGroups.Add(packedGroup);
            return true;
        }

        private bool CheckGroupValid(PackedAssetGroup packedGroup, ref string errorGuid)
        {
            errorGuid = String.Empty;
            var allGuids = CollectCustomGroupGUID();
            if (allGuids.Count > 0)
            {
                var groupGUIDs = packedGroup.GetPackedAssetGroupGUIDs();
                foreach (var guid in groupGUIDs)
                {
                    if (allGuids.Contains(guid))
                    {
                        errorGuid = guid;
                        return false;
                    }
                }
            }

            return true;
        }

        private List<string> CollectCustomGroupGUID()
        {
            List<string> guids = new List<string>();
            foreach (var packGroup in CustomPackGroups)
            {
                guids.AddRange(packGroup.GetPackedAssetGroupGUIDs());
            }

            return guids;
        }
    }

    /// <summary>
    /// 描述一个自定义打包最小结构
    /// </summary>
    public class PackedAssetGroup
    {
        public string BundleName;
        public List<PackedAsset> PackedAssets;
        public List<string> AssetGUIDs;

        public PackedAssetGroup(string bundleName, List<PackedAsset> packedAssets)
        {
            BundleName = bundleName;
            PackedAssets = packedAssets;
        }

        public List<string> GetPackedAssetGroupGUIDs()
        {
            List<string> guids = new List<string>();
            if (PackedAssets != null)
            {
                foreach (var packedAsset in PackedAssets)
                {
                    guids.Add(packedAsset.Guid);
                }
            }

            return guids;
        }
    }

    /// <summary>
    /// 描述一个unity的asset打包数据结构
    /// </summary>
    public sealed class PackedAsset
    {
        public string AssetPath;
        public string Guid;
        public List<string> AssetLabels;

        public PackedAsset(string assetPath)
        {
            AssetPath = assetPath;
            Guid = AssetDatabase.AssetPathToGUID(assetPath);
            AssetLabels = new List<string>();
        }

        public void SetLabels(string[] labels)
        {
            AssetLabels.Clear();
            AssetLabels.AddRange(labels);
        }

        public List<string> GetLabels()
        {
            return AssetLabels;
        }
    }
}