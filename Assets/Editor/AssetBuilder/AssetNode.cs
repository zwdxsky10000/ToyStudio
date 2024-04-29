namespace Editor.AssetBuilder
{
    public enum EAssetType
    {
        None = 0,
        Prefab = 1,
        SpriteAtlas = 2,
        Shader = 3,
        Font = 4,
        Texture = 5,
        Scene = 6,
        Animation = 7,
    }

    public enum ENodeType
    {
        None = 0,
        Root = 1,
        Branch = 2,
        Leaf = 3,
    }
    
    public class AssetNode
    {
        public string AssetPath { get; set; }
        public EAssetType AssetNodeType { get; set; } = EAssetType.None;
        public ENodeType NodeType { get; set; } = ENodeType.None;
    }
}